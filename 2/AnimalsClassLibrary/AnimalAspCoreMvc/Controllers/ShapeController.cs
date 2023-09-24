using AnimalAspCoreMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAspCoreMvc.Controllers
{
    public class ShapeController : Controller
    {
        private IShapeService _shapeService;

        private const string _txtFilePath = "wwwroot/files/shapes.txt";
        private const string _jsonFilePath = "wwwroot/files/shapes.json";
        private const string _binFilePath = "wwwroot/files/shapes.bin";

        public ShapeController(IShapeService shapeService)
        {
            this._shapeService = shapeService;

            //For test:
            //IShapePrinter printer = new ShapePrinter();
            //this._shapeService.AddShape(new Circle(100, printer));
            //this._shapeService.AddShape(new Rectangle(100, 200, printer));
            //this._shapeService.AddShape(new Triangle(33, 44, 55, printer));
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

        public IActionResult ExportShapesToJson()
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

                this._shapeService.SaveShapesToJson(_jsonFilePath);

                var fileName = "shapes.json";
                var mimeType = "application/json";

                var fileBytes = System.IO.File.ReadAllBytes(_jsonFilePath);

                return File(fileBytes, mimeType, fileName);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to export list of Animals to JSON file: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult ImportShapesFromJson(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or missing.");
            }

            try
            {
                this._shapeService.LoadShapesFromJson(file);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to import list of Animals from JSON file: {ex.Message}");
            }
        }

        public IActionResult ExportShapesToBinary()
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

                this._shapeService.SaveShapesToBinary(_binFilePath);

                var fileName = "shapes.bin";
                var mimeType = "application/bin";

                var fileBytes = System.IO.File.ReadAllBytes(_binFilePath);

                return File(fileBytes, mimeType, fileName);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to export list of Animals to binary file: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult ImportShapesFromBinary(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or missing.");
            }

            try
            {
                this._shapeService.LoadShapesFromBinary(file);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to import list of Animals from binary file: {ex.Message}");
            }
        }
    }
}