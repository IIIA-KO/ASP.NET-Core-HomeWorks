using GadgetsClassLibrary.Printers;

namespace GadgetsClassLibrary.Gadgets
{
    public class CoffeeMachine : Gadget
    {
        public override string Type => "Coffee Machine";

        public override string Description => "A small electrical machine that makes coffee";

        public CoffeeMachine(IGadgetPrinter gadgetPrinter) : base(gadgetPrinter)
        {
        }
    }
}