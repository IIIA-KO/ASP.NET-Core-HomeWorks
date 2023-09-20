using ShapesClassLibrary.Printers;

namespace ShapesClassLibrary.Shapes
{
    public abstract class Shape
    {
        public abstract string Name { get; }
        public abstract string OutputMessage { get; }
        public IShapePrinter ShapePrinter { get; protected set; }

        public Shape(IShapePrinter shapePrinter)
        {
            ShapePrinter = shapePrinter;
        }

        public void PrintNameConsole()
        {
            ShapePrinter.PrintNameConsole(Name);
        }

        public void PrintShapeConsole()
        {
            ShapePrinter.PrintShapeConsole(OutputMessage);
        }

        public void PrintNameFile(string path)
        {
            ShapePrinter.PrintNameFile(path, Name);
        }

        public void PrintShapeFile(string path)
        {
            ShapePrinter.PrintShapeFile(path, OutputMessage);
        }

        public string PrintNameHtml()
        {
            return ShapePrinter.PrintNameHtml(Name);
        }

        public virtual string PrintShapeHtml()
        {
            return ShapePrinter.PrintShapeHtml(OutputMessage);
        }
    }
}