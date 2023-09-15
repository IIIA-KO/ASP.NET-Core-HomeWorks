using AnimalsClassLibrary.Printers;

namespace AnimalsClassLibrary.Animals
{
    public class Cat : Animal
    {
        public override string Sound { get => "Meow!"; }

        public Cat(string name, IAnimalPrinter animalPrinter) : base(name, animalPrinter) { }
    }
}
