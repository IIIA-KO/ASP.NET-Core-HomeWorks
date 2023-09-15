using AnimalsClassLibrary.Animals;

namespace AnimalAspCoreMvc.Services
{
    public class AnimalService : IAnimalService
    {
        private List<Animal> _animals { get; set; }

        public AnimalService()
        {
            this._animals = new List<Animal>();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return this._animals;
        }

        public void AddAnimal(Animal animal)
        {
            this._animals.Add(animal);
        }
    }
}
