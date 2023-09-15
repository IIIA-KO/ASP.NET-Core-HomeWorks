namespace AnimalsClassLibrary.Printers
{
    public interface IAnimalPrinter
    {
        void PrintNameConsole(string name);
        void PrintSoundConsole(string sound);

        void PrintNameFile(string path, string name);
        void PrintSoundFile(string path, string sound);

        string PrintNameHtml(string name);
        string PrintSoundHtml(string sound);
    }
}
