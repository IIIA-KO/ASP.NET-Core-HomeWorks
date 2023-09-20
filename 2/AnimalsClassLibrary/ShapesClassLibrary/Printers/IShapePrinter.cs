namespace ShapesClassLibrary.Printers
{
    public interface IShapePrinter
    {
        void PrintNameConsole(string name);
        void PrintShapeConsole(string outputMessage);

        void PrintNameFile(string path, string name);
        void PrintShapeFile(string path, string outputMessage);

        string PrintNameHtml(string name);
        string PrintShapeHtml(string outputMessage);
    }
}