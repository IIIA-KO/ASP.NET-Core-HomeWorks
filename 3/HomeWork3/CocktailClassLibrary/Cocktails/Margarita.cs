using CocktailClassLibrary.Printers;

namespace CocktailClassLibrary.Cocktails
{
    public class Margarita : Cocktail
    {
        public override string Name => "Margarita";

        public override int AlcoholPercentage => 20;

        public Margarita(ICocktailPrinter cocktailPrinter) : base(cocktailPrinter)
        {
        }

        public override string FullInfo => base.FullInfo + " | Ingredients: 1 tablespoon kosher salt, 1.5 fluid ounces tequila, 1 fluid ounce orange flavored liqueur (such as Cointreau), 1/2 fluid ounce lime juice, 1 cup ice, 1 lime wheel.";
    }
}