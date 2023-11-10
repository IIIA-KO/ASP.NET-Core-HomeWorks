using GadgetsClassLibrary.Printers;

namespace GadgetsClassLibrary.Gadgets
{
    public abstract class Gadget
    {
        public abstract string Type { get; }
        public abstract string Description { get; }

        public virtual string ShortInfo => $"Name: {Type}";
        public virtual string FullInfo => $"Name: {Type} | Description: {Description}";

        public IGadgetPrinter GadgetPrinter { get; protected set; }

        public Gadget(IGadgetPrinter gadgetPrinter)
        {
            GadgetPrinter = gadgetPrinter;
        }

        public void PrintShortInfoToFile(string path)
        {
            if (GadgetPrinter == null)
            {
                throw new NullReferenceException($"Unable to print short info about {this.Type} character since the Character Printer reference is null.");
            }

            GadgetPrinter.PrintShortInfoToFile(path, ShortInfo);
        }

        public void PrintFullInfoToFile(string path)
        {
            if (GadgetPrinter == null)
            {
                throw new NullReferenceException($"Unable to print short info about {this.Type} character since the Character Printer reference is null.");
            }

            GadgetPrinter.PrintFullInfoToFile(path, FullInfo);
        }
    }
}
