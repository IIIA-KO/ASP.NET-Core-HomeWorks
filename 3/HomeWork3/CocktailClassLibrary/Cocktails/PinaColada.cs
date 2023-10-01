using CocktailClassLibrary.Printers;

namespace CocktailClassLibrary.Cocktails
{
    public class PinaColada : Cocktail
    {
        public override string Name => "Pina Colada";

        public override int AlcoholPercentage => 13;

        public PinaColada(ICocktailPrinter cocktailPrinter) : base(cocktailPrinter)
        {
        }

        public override string FullInfo => base.FullInfo + " | Ingredients: Rum, Cream of coconut (not coconut cream), Pineapple juice, Ice, Frozen pineapple, Lime juice.";
    }
}