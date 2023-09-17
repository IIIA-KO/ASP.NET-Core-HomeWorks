using AnimalsClassLibrary.Printers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AnimalsClassLibrary.Animals
{
    public class AnimalConverter : JsonConverter<Animal>
    {
        private IAnimalPrinter _printer;

        public AnimalConverter(IAnimalPrinter printer)
        {
            this._printer = printer;
        }

        public override Animal ReadJson(JsonReader reader, Type objectType, Animal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (jsonObject.TryGetValue("Sound", StringComparison.OrdinalIgnoreCase, out var soundToken) && soundToken.Type == JTokenType.String)
            {
                var sound = soundToken.Value<string>();
                Animal animal;

                if (sound.Equals("Meow!", StringComparison.OrdinalIgnoreCase))
                {
                    animal = new Cat(jsonObject["Name"].Value<string>(), new AnimalPrinter());
                }
                else if (sound.Equals("Woof!", StringComparison.OrdinalIgnoreCase))
                {
                    animal = new Dog(jsonObject["Name"].Value<string>(), new AnimalPrinter());
                }
                else if (sound.Equals("Squawk!", StringComparison.OrdinalIgnoreCase))
                {
                    animal = new Parrot(jsonObject["Name"].Value<string>(), new AnimalPrinter());
                }
                else
                {
                    throw new InvalidOperationException("Unknown animal sound.");
                }

                serializer.Populate(jsonObject.CreateReader(), animal);
                return animal;
            }

            throw new InvalidOperationException("Unable to determine the animal type.");
        }

        public override void WriteJson(JsonWriter writer, Animal value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
