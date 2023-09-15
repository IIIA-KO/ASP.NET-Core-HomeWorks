using AnimalsClassLibrary.Animals;

namespace AnimalAspCoreMvc.Services
{
    public interface IAnimalService
    {
        public IEnumerable<Animal> GetAnimals();

        public void AddAnimal(Animal animal);
    }
}
