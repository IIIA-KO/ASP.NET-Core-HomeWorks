using AspNetCoreMvcApp.Services.Interfaces;
using GadgetsClassLibrary.Gadgets;
using GadgetsClassLibrary.Printers;

namespace AspNetCoreMvcApp.Services.Implementations
{
    public class GadgetService : IGadgetService
    {
        private ICollection<Gadget> Gadgets { get; set; }
        public IGadgetPrinter _printer;

        public GadgetService(IGadgetPrinter printer)
        {
            Gadgets = new List<Gadget>();
            this._printer = printer;
        }

        public void AddGadget(Gadget gadget)
        {
            if (gadget == null)
            {
                throw new NullReferenceException("Unable to add gadget due to null reference in Gadget Service's collection.");
            }

            Gadgets.Add(gadget);
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            return Gadgets ?? new List<Gadget>();
        }

        public void SaveGadgetsInfoToTxt(string filePath)
        {
            if (Gadgets == null)
            {
                throw new NullReferenceException("Unable to output info about characters due to null reference in Character Service's collection.");
            }

            foreach (Gadget gadget in Gadgets)
            {
                if (gadget != null)
                {
                    gadget.PrintShortInfoToFile(filePath);
                    gadget.PrintFullInfoToFile(filePath);
                }
            }
        }
    }
}
