using AnimalAspCoreMvc.Services;
using AnimalsClassLibrary.Printers;
using Microsoft.AspNetCore.Mvc;
using ShapesClassLibrary.Printers;
using ShapesClassLibrary.Shapes;
using System.Reflection;

namespace AnimalAspCoreMvc.Controllers
{
    public class ShapeController : Controller
    {
        private IShapeService _shapeService;

        private const string _txtFilePath = "wwwroot/files/shapes.txt";

        public ShapeController(IShapeService shapeService)
        {
            this._shapeService = shapeService;

            //For test:
            IShapePrinter printer = new ShapePrinter();
            this._shapeService.AddShape(new Circle(printer, 100));
            this._shapeService.AddShape(new Rectangle(printer, 100, 200));
            this._shapeService.AddShape(new Triangle(printer, 33, 44, 55));
        }

        public IActionResult Index()
        {
            return View(this._shapeService.GetShapes());
        }

        public IActionResult ExportShapesToFile()
        {
            try
            {
                if (!System.IO.File.Exists(_txtFilePath))
                {
                    System.IO.File.Create(_txtFilePath).Close();
                }
                else
                {
                    System.IO.File.WriteAllText(_txtFilePath, string.Empty);
                }

                this._shapeService.SaveShapesInfoToTxt(_txtFilePath);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create file: {ex.Message}");
            }

            var fileName = "shapes.txt";
            var mimeType = "text/plain";

            var fileBytes = System.IO.File.ReadAllBytes(_txtFilePath);
            return File(fileBytes, mimeType, fileName);
        }
    }
}