using CocktailClassLibrary.Cocktails;

namespace AspNetCoreMvcApp.Services.Interfaces
{
    public interface ICocktailService
    {
        public IEnumerable<Cocktail> GetCocktails();

        public void AddCocktail(Cocktail cocktail);

        public void SaveCocktailsInfoToTxt(string filePath);
    }
}
