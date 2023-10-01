using AspNetCoreMvcApp.Services.Interfaces;
using CocktailClassLibrary.Cocktails;
using CocktailClassLibrary.Printers;

namespace AspNetCoreMvcApp.Services.Implementations
{
    public class CocktailService : ICocktailService
    {
        private ICollection<Cocktail> Cocktails { get; set; }
        public ICocktailPrinter _printer;

        public CocktailService(ICocktailPrinter printer)
        {
            Cocktails = new List<Cocktail>();
            this._printer = printer;
        }

        public IEnumerable<Cocktail> GetCocktails()
        {
            return Cocktails ?? new List<Cocktail>();
        }

        public void AddCocktail(Cocktail cocktail)
        {
            if (Cocktails == null)
            {
                throw new NullReferenceException("Unable to add cocktail due to null reference in Cocktail Service's collection.");
            }
            Cocktails.Add(cocktail);
        }

        public void SaveCocktailsInfoToTxt(string filePath)
        {
            if(Cocktails == null)
            {
                throw new NullReferenceException("Unable to output info about cocktails due to null reference in Cocktail Service's collection.");
            }

            foreach (Cocktail cocktail in Cocktails)
            {
                if (cocktail != null)
                {
                    cocktail.PrintShortInfoToFile(filePath);
                    cocktail.PrintFullInfoToFile(filePath);
                }
            }
        }
    }
}