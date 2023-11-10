using GadgetsClassLibrary.Printers;

namespace GadgetsClassLibrary.Gadgets
{
    public class Heater : Gadget
    {
        public override string Type => "Heater";

        public override string Description => "A device that imparts heat or holds something to be heated";
        
        public Heater(IGadgetPrinter gadgetPrinter) : base(gadgetPrinter)
        {
        }
    }
}
