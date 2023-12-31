﻿using AnimalsClassLibrary.Printers;

namespace AnimalsClassLibrary.Animals
{
    [Serializable]
    public class Dog : Animal
    {
        public override string Sound { get => "Woof!"; }

        public Dog(string name, IAnimalPrinter animalPrinter) : base(name, animalPrinter) { }
    }
}