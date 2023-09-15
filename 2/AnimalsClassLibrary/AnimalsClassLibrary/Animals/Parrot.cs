using AnimalsClassLibrary.Printers;

namespace AnimalsClassLibrary.Animals
{
    public class Parrot : Animal
    {
        public override string Sound { get => "Squawk!"; }

        public Parrot(string name, IAnimalPrinter animalPrinter) : base(name, animalPrinter) { }
    }
}