namespace ShapesClassLibrary.Printers
{
    public class ShapePrinter : IShapePrinter
    {
        #region Console
        public void PrintNameConsole(string name)
        {
            Console.WriteLine(name);
        }
        public void PrintShapeConsole(string outputMessage)
        {
            Console.WriteLine(outputMessage);
        }
        #endregion

        #region File
        private void PrintStringToFile(string path, string str)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "Filepath cannot be null or empty");
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            File.AppendAllText(path, str);
        }

        public void PrintNameFile(string path, string name)
        {
            this.PrintStringToFile(path, $"Name: {name}\n");
        }
        public void PrintShapeFile(string path, string outputMessage)
        {
            this.PrintStringToFile(path, $"Shape: {outputMessage}\n");
        }
        #endregion

        #region Html
        public string PrintNameHtml(string name)
        {
            return $"<p>{name}</p>";
        }

        public string PrintShapeHtml(string outputMessage)
        {
            return $"<p>{outputMessage}</p>";
        }
        #endregion
    }
}