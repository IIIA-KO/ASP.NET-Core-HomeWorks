using AnimalsClassLibrary.Animals;

namespace AnimalAspCoreMvc.Services
{
    public interface IAnimalService
    {
        public IEnumerable<Animal> GetAnimals();

        public void AddAnimal(Animal animal);

        public void SaveAnimalsToJson(string filePath);
        public void LoadAnimalsFromJson(IFormFile file);


        public void SaveAnimalsToBinary(string filePath);
        public void LoadAnimalsFromBinary(IFormFile file);
    }
}
