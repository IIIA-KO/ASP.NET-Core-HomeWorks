using AnimalAspCoreMvc.Services;
using AnimalsClassLibrary.Animals;
using AnimalsClassLibrary.Printers;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAspCoreMvc.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        private const string _txtFilePath = "wwwroot/files/animals.txt";
        private const string _jsonFilePath = "wwwroot/files/animals.json";
        private const string _binFilePath = "wwwroot/files/animals.bin";

        public AnimalController(IAnimalService service)
        {
            this._animalService = service;

            // For test:
            IAnimalPrinter animalPrinter = new AnimalPrinter();

            this._animalService.AddAnimal(new Cat("Meower", animalPrinter));
            this._animalService.AddAnimal(new Dog("Barker", animalPrinter));
            this._animalService.AddAnimal(new Parrot("Squeweker", animalPrinter));
        }

        public IActionResult Animals()
        {
            return View(this._animalService.GetAnimals());
        }

        public IActionResult ExportAnimalsToFile()
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

                this._animalService.SaveAnimalsInfoToTxt(_txtFilePath);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create file: {ex.Message}");
            }

            var fileName = "animals.txt";
            var mimeType = "text/plain";

            var fileBytes = System.IO.File.ReadAllBytes(_txtFilePath);
            return File(fileBytes, mimeType, fileName);
        }

        public IActionResult ExportAnimalsToJson()
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

                this._animalService.SaveAnimalsToJson(_jsonFilePath);

                var fileName = "animals.json";
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
        public IActionResult ImportAnimalsFromJson(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or missing.");
            }

            try
            {
                this._animalService.LoadAnimalsFromJson(file);
                return RedirectToAction("Animals");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to import list of Animals from JSON file: {ex.Message}");
            }
        }

        public IActionResult ExportAnimalsToBinary()
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

                this._animalService.SaveAnimalsToBinary(_binFilePath);

                var fileName = "animals.bin";
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
        public IActionResult ImportAnimalsFromBinary(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or missing.");
            }

            try
            {
                this._animalService.LoadAnimalsFromBinary(file);
                return RedirectToAction("Animals");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to import list of Animals from binary file: {ex.Message}");
            }
        }
    }
}