namespace CocktailClassLibrary.Printers
{
    public class CocktailPrinter : ICocktailPrinter
    {
        private void PrintStringToFile(string path, in string str)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "File path cannot be null or empty");
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            File.AppendAllText(path, str);
        }

        public void PrintShortInfoToFile(string path, in string shortInfo)
        {
            this.PrintStringToFile(path, shortInfo);
        }

        public void PrintFullInfoToFile(string path, in string fullInfo)
        {
            this.PrintStringToFile(path, fullInfo);
        }

        public string PrintShortInfoToHtml(in string shortInfo)
        {
            return $"<p>{shortInfo}</p>";
        }

        public string PrintFullInfoToHtml(in string fullInfo)
        {
            return $"<p>{fullInfo}</p>";
        }
    }
}
