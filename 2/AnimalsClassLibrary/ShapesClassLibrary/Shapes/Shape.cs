using ShapesClassLibrary.Printers;
using static System.Net.Mime.MediaTypeNames;

namespace ShapesClassLibrary.Shapes
{
    public abstract class Shape
    {
        public abstract string Name { get; }
        public abstract string OutputMessage { get; }

        public virtual string ShortInfo => $"Name: {Name}";
        public virtual string FullInfo => $"Name: {Name} | Output message: {OutputMessage}";

        public IShapePrinter ShapePrinter { get; protected set; }

        public Shape(IShapePrinter shapePrinter)
        {
            ShapePrinter = shapePrinter;
        }

        public void PrintShortInfoToFile(string path)
        {
            if (ShapePrinter == null)
            {
                throw new NullReferenceException($"Unable to print short info about {this.Name} character since the Character Printer reference is null.");
            }

            ShapePrinter.PrintShortInfoToFile(path, ShortInfo);
        }

        public void PrintFullInfoToFile(string path)
        {
            if (ShapePrinter == null)
            {
                throw new NullReferenceException($"Unable to print short info about {this.Name} character since the Character Printer reference is null.");
            }

            ShapePrinter.PrintFullInfoToFile(path, FullInfo);
        }
    }
}