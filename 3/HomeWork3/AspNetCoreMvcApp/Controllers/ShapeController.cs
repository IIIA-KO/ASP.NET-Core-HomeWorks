using AspNetCoreMvcApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShapesClassLibrary.Printers;
using ShapesClassLibrary.Shapes;

namespace AspNetCoreMvcApp.Controllers
{
    public class ShapeController : Controller
    {
        private readonly IShapeService _shapeService;

        private const string _txtFilePath = "wwwroot/files/shapes.txt";

        public ShapeController(IShapeService shapeService)
        {
            this._shapeService = shapeService;

            // For test:
            IShapePrinter shapePrinter = new ShapePrinter();
            this._shapeService.AddShape(new Circle(5.78, shapePrinter));
            this._shapeService.AddShape(new Rectangle(3.22, 2.33, shapePrinter));
            this._shapeService.AddShape(new Triangle(3, 4, 5, shapePrinter));
        }

        public IActionResult Index()
        {
            return View(this._shapeService.GetShapes());
        }

        public IActionResult ExportDataToTxtFile()
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