using Newtonsoft.Json;
using AnimalsClassLibrary.Animals;
using AnimalsClassLibrary.Printers;

namespace AnimalAspCoreMvc.Services
{
    public class AnimalService : IAnimalService
    {
        private ICollection<Animal> _animals { get; set; }
        private IAnimalPrinter _printer;

        public AnimalService(IAnimalPrinter printer)
        {
            this._animals = new List<Animal>();
            this._printer = printer;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return this._animals;
        }

        public void AddAnimal(Animal animal)
        {
            this._animals.Add(animal);
        }

        #region Saving/Loading
        public void SaveAnimalsInfoToTxt(string filePath)
        {
            foreach(Animal animal in this._animals)
            {
                animal.PrintNameFile(filePath);
                animal.MakeSoundFile(filePath);
            }
        }

        public void SaveAnimalsToJson(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "Filepath cannot be null or empty");
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var json = JsonConvert.SerializeObject(this._animals);
            File.WriteAllText(filePath, json);
        }

        public void LoadAnimalsFromJson(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file.");
            }

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                string jsonString = reader.ReadToEnd();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new AnimalConverter(this._printer) }
                };

                IEnumerable<Animal> deserializedCollection = JsonConvert.DeserializeObject<IEnumerable<Animal>>(jsonString, settings);
                this._animals = new List<Animal>(deserializedCollection);
            }
        }

        public void SaveAnimalsToBinary(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(this._animals.Count);

                foreach (var animal in this._animals)
                {
                    writer.Write(animal.GetType().FullName);
                    writer.Write(animal.Name);
                    writer.Write(animal.Sound);
                }
            }
        }

        public void LoadAnimalsFromBinary(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file.");
            }

            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);

                using (BinaryReader reader = new BinaryReader(ms))
                {
                    int animalCount = reader.ReadInt32();

                    this._animals.Clear();

                    for (int i = 0; i < animalCount; i++)
                    {
                        string typeName = reader.ReadString();
                        string name = reader.ReadString();
                        string sound = reader.ReadString();

                        if (typeName == typeof(Cat).FullName)
                        {

                            this._animals.Add(new Cat(name, this._printer));
                        }
                        else if (typeName == typeof(Dog).FullName)
                        {
                            this._animals.Add(new Dog(name, this._printer));
                        }
                        else if (typeName == typeof(Parrot).FullName)
                        {
                            this._animals.Add(new Parrot(name, this._printer));
                        }
                        else
                        {
                            throw new InvalidOperationException("Unknown animal sound.");
                        }
                    }
                }
            }
        }
        #endregion
    }
}