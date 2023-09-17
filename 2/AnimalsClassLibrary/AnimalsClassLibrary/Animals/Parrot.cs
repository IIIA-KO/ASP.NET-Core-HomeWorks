using AnimalsClassLibrary.Printers;

namespace AnimalsClassLibrary.Animals
{
    [Serializable]
    public class Parrot : Animal
    {
        public override string Sound { get => "Squawk!"; }

        public Parrot(string name, IAnimalPrinter animalPrinter) : base(name, animalPrinter) { }
    }
}