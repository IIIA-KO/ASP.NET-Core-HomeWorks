using GadgetsClassLibrary.Printers;

namespace GadgetsClassLibrary.Gadgets
{
    public class Keyboard : Gadget
    {
        public override string Type => "Keyboard";

        public override string Description => "A group of systematically arranged keys by which a machine or device is operated";

        public Keyboard(IGadgetPrinter gadgetPrinter) : base(gadgetPrinter)
        {
        }
    }
}
