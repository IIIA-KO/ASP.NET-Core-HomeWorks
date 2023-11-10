using GadgetsClassLibrary.Gadgets;

namespace AspNetCoreMvcApp.Services.Interfaces
{
    public interface IGadgetService
    {
        public IEnumerable<Gadget> GetGadgets();

        public void AddGadget(Gadget gadget);

        public void SaveGadgetsInfoToTxt(string filePath);
    }
}
