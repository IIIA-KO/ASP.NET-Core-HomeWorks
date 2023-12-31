﻿namespace ShapesClassLibrary.Printers
{
    public interface IShapePrinter
    {
        void PrintShortInfoToFile(string path, in string shortInfo);
        void PrintFullInfoToFile(string path, in string fullInfo);

        string PrintShortInfoToHtml(in string shortInfo);
        string PrintFullInfoToHtml(in string fullInfo);
    }
}