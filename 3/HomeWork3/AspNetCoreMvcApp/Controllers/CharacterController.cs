using AspNetCoreMvcApp.Services.Implementations;
using AspNetCoreMvcApp.Services.Interfaces;
using CharactersClassLibrary.Characters;
using CharactersClassLibrary.Printers;
using CocktailClassLibrary.Cocktails;
using CocktailClassLibrary.Printers;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcApp.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        private const string _txtFilePath = "wwwroot/files/characters.txt";

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;

            //For test:
            ICharacterPrinter printer = new CharacterPrinter();
            this._characterService.AddCharacter(new Infantry(printer, "Bob"));
            this._characterService.AddCharacter(new Spearman(printer, "John"));
            this._characterService.AddCharacter(new Archer(printer, "Max"));
        }

        public IActionResult Index()
        {
            return View(this._characterService.GetCharacters());
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

                this._characterService.SaveCharactersInfoToTxt(_txtFilePath);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create file: {ex.Message}");
            }

            var fileName = "characters.txt";
            var mimeType = "text/plain";

            var fileBytes = System.IO.File.ReadAllBytes(_txtFilePath);
            return File(fileBytes, mimeType, fileName);
        }
    }
}
