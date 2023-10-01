using AspNetCoreMvcApp.Services.Interfaces;
using CocktailClassLibrary.Cocktails;
using CocktailClassLibrary.Printers;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcApp.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailService _cocktailService;

        private const string _txtFilePath = "wwwroot/files/cocktails.txt";

        public CocktailController(ICocktailService cocktailService)
        {
            this._cocktailService = cocktailService;

            //For test:
            ICocktailPrinter printer = new CocktailPrinter();
            this._cocktailService.AddCocktail(new Margarita(printer));
            this._cocktailService.AddCocktail(new PinaColada(printer));
            this._cocktailService.AddCocktail(new Mojito(printer));
        }

        public IActionResult Index()
        {
            return View(this._cocktailService.GetCocktails());
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

                this._cocktailService.SaveCocktailsInfoToTxt(_txtFilePath);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create file: {ex.Message}");
            }

            var fileName = "cocktails.txt";
            var mimeType = "text/plain";

            var fileBytes = System.IO.File.ReadAllBytes(_txtFilePath);
            return File(fileBytes, mimeType, fileName);
        }
    }
}