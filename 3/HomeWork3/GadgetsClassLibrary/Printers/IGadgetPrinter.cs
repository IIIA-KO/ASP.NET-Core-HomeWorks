namespace GadgetsClassLibrary.Printers
{
    public interface IGadgetPrinter
    {
        void PrintShortInfoToFile(string path, in string shortInfo);
        void PrintFullInfoToFile(string path, in string fullInfo);

        string PrintShortInfoToHtml(in string shortInfo);
        string PrintFullInfoToHtml(in string fullInfo);
    }
}