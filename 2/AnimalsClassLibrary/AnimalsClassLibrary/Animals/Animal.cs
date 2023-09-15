using AnimalsClassLibrary.Printers;

namespace AnimalsClassLibrary.Animals
{
    public abstract class Animal
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _name = "Unnamed";
                }

                _name = value;
            }
        }

        public abstract string Sound { get; }

        public IAnimalPrinter AnimalPrinter { get; protected set; }

        public Animal(string name, IAnimalPrinter animalPrinter)
        {
            Name = name;
            AnimalPrinter = animalPrinter;
        }

        public void PrintNameСonsole()
        {
            AnimalPrinter.PrintNameConsole(Name);
        }

        public void PrintNameFile(string path)
        {
            AnimalPrinter.PrintNameFile(path, Name);
        }

        public void MakeSoundConsole()
        {
            AnimalPrinter.PrintSoundConsole(Sound);
        }

        public void MakeSoundFile(string path)
        {
            AnimalPrinter.PrintSoundFile(path, Sound);
        }
    }
}
