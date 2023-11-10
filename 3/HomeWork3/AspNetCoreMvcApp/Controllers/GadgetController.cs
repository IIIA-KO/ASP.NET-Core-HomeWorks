using AspNetCoreMvcApp.Services.Interfaces;
using GadgetsClassLibrary.Gadgets;
using GadgetsClassLibrary.Printers;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcApp.Controllers
{
    public class GadgetController : Controller
    {
        private readonly IGadgetService _gadgetService;

        private const string _txtFilePath = "wwwroot/files/gadgets.txt";

        public GadgetController(IGadgetService gadgetService)
        {
            this._gadgetService = gadgetService;

            // For test:
            IGadgetPrinter gadgetPrinter = new GadgetPrinter();
            this._gadgetService.AddGadget(new CoffeeMachine(gadgetPrinter));
            this._gadgetService.AddGadget(new Heater(gadgetPrinter));
            this._gadgetService.AddGadget(new Keyboard(gadgetPrinter));
        }

        public IActionResult Index()
        {
            return View(this._gadgetService.GetGadgets());
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

                this._gadgetService.SaveGadgetsInfoToTxt(_txtFilePath);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create file: {ex.Message}");
            }

            var fileName = "gadgets.txt";
            var mimeType = "text/plain";

            var fileBytes = System.IO.File.ReadAllBytes(_txtFilePath);
            return File(fileBytes, mimeType, fileName);
        }
    }
}
