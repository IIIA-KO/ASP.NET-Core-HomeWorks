using AnimalAspCoreMvc.Services;
using AnimalsClassLibrary.Animals;
using AnimalsClassLibrary.Printers;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAspCoreMvc.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IAnimalPrinter _animalPrinter;

        public AnimalController(IAnimalService service, IAnimalPrinter animalPrinter)
        {
            this._animalService = service;
            this._animalPrinter = animalPrinter;

            this._animalService.AddAnimal(new Cat("Meower", this._animalPrinter));
            this._animalService.AddAnimal(new Dog("Barker", this._animalPrinter));
            this._animalService.AddAnimal(new Parrot("Squawker", this._animalPrinter));
        }

        public IActionResult Animals()
        {
            return View(this._animalService.GetAnimals());
        }

        public IActionResult ExportAnimalsToFile()
        {
            var filePath = "wwwroot/files/animals.txt";

            try
            {
                using (var writer = new StreamWriter(filePath, false))
                {
                    foreach (Animal animal in this._animalService.GetAnimals())
                    {
                        writer.WriteLine($"Name: {animal.Name}");
                        writer.WriteLine($"Sound: {animal.Sound}");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create file: {ex.Message}");
            }

            var fileName = "animals.txt";
            var mimeType = "text/plain";

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, mimeType, fileName);
        }
    }
}
