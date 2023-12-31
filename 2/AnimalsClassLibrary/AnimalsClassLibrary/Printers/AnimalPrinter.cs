﻿namespace AnimalsClassLibrary.Printers
{
    public class AnimalPrinter : IAnimalPrinter
    {
        #region Console
        public void PrintNameConsole(string name)
        {
            Console.WriteLine($"Name: {name}");
        }

        public void PrintSoundConsole(string sound)
        {
            Console.WriteLine($"Sound: {sound}");
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

        public void PrintSoundFile(string path, string sound)
        {
            this.PrintStringToFile(path, $"Sound: {sound}\n");
        }
        #endregion

        #region Html
        public string PrintNameHtml(string name)
        {
            return $"<p>{name}</p>";
        }

        public string PrintSoundHtml(string sound)
        {
            return $"<p>{sound}</p>";
        }
        #endregion
    }
}