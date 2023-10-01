using CocktailClassLibrary.Printers;

namespace CocktailClassLibrary.Cocktails
{
    public class Mojito : Cocktail
    {
        public override string Name => "Mojito";

        public override int AlcoholPercentage => 13;

        public Mojito(ICocktailPrinter cocktailPrinter) : base(cocktailPrinter)
        {
        }

        public override string FullInfo => base.FullInfo + " | Ingredients: 5 mint leaves, 2 ounces white rum, 1 ounce fresh lime juice, 1/2 ounce simple syrup, Ice, Club soda or sparkling water, Lime slices.";
    }
}