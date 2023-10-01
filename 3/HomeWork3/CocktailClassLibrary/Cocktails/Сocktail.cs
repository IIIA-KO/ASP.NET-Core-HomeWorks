using CocktailClassLibrary.Printers;

namespace CocktailClassLibrary.Cocktails
{
    public abstract class Cocktail
    {
        public abstract string Name { get; }
        public abstract int AlcoholPercentage { get; }

        public virtual string ShortInfo => $"Cocktail name: {Name}";
        public virtual string FullInfo => $"Cocktail name: {Name} | Alcohol percentage: {AlcoholPercentage}%";

        public ICocktailPrinter CocktailPrinter { get; protected set; }

        public Cocktail(ICocktailPrinter cocktailPrinter)
        {
            CocktailPrinter = cocktailPrinter;
        }

        public void PrintShortInfoToFile(string filePath)
        {
            if(CocktailPrinter == null)
            {
                throw new NullReferenceException($"Unable to print short info about {this.Name} cocktail since the Cocktail Printer reference is null.");
            }

            CocktailPrinter.PrintShortInfoToFile(filePath, ShortInfo);
        }

        public void PrintFullInfoToFile(string filePath)
        {
            if (CocktailPrinter == null)
            {
                throw new NullReferenceException($"Unable to print full info about {this.Name} cocktail since the Cocktail Printer reference is null.");
            }

            CocktailPrinter.PrintFullInfoToFile(filePath, FullInfo);
        }
    }
}