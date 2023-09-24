using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AnimalsClassLibrary.Printers;

namespace AnimalsClassLibrary.Animals
{
    public class AnimalConverter : JsonConverter<Animal>
    {
        private readonly IAnimalPrinter _printer;

        public AnimalConverter(IAnimalPrinter printer)
        {
            this._printer = printer;
        }

        public override Animal ReadJson(JsonReader reader, Type objectType, Animal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (!jsonObject.TryGetValue("Sound", StringComparison.OrdinalIgnoreCase, out var soundToken) || soundToken.Type != JTokenType.String)
            {
                throw new InvalidOperationException("Unable to determine the animal type.");
            }

            var sound = soundToken.Value<string>();
            Animal animal;

            if (sound.Equals("Meow!", StringComparison.OrdinalIgnoreCase))
            {
                animal = new Cat(jsonObject["Name"].Value<string>(), this._printer);
            }
            else if (sound.Equals("Woof!", StringComparison.OrdinalIgnoreCase))
            {
                animal = new Dog(jsonObject["Name"].Value<string>(), this._printer);
            }
            else if (sound.Equals("Squawk!", StringComparison.OrdinalIgnoreCase))
            {
                animal = new Parrot(jsonObject["Name"].Value<string>(), this._printer);
            }
            else
            {
                throw new InvalidOperationException("Unknown animal sound.");
            }

            serializer.Populate(jsonObject.CreateReader(), animal);
            return animal;
        }

        public override void WriteJson(JsonWriter writer, Animal value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
