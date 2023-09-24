using ShapesClassLibrary.Printers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShapesClassLibrary.Shapes
{
    public class ShapeConverter : JsonConverter<Shape>
    {
        private readonly IShapePrinter _printer;

        public ShapeConverter(IShapePrinter printer)
        {
            this._printer = printer;
        }

        public override Shape? ReadJson(JsonReader reader, Type objectType, Shape? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (!jsonObject.TryGetValue("Name", StringComparison.OrdinalIgnoreCase, out var nameToken) || nameToken.Type != JTokenType.String)
            {
                throw new InvalidOperationException("Unable to determine the animal type.");
            }

            var name = nameToken.Value<string>();
            Shape shape;

            if (name.Equals("Circle", StringComparison.OrdinalIgnoreCase))
            {
                if (!jsonObject.TryGetValue("Radius", StringComparison.OrdinalIgnoreCase, out var radiusToken) || radiusToken.Type != JTokenType.Float)
                {
                    throw new InvalidOperationException("Unable to parce circle type from JSON.");
                }

                shape = new Circle(jsonObject["Radius"].Value<double>(), this._printer);
            }
            else if (name.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
            {
                if (!jsonObject.TryGetValue("Height", StringComparison.OrdinalIgnoreCase, out var heightToken) 
                    || heightToken.Type != JTokenType.Float
                    || !jsonObject.TryGetValue("Width", StringComparison.OrdinalIgnoreCase, out var widthToken) 
                    || widthToken.Type != JTokenType.Float)
                {
                    throw new InvalidOperationException("Unable to parce rectangle type from JSON.");
                }
                
                shape = new Rectangle(jsonObject["Height"].Value<double>(), jsonObject["Width"].Value<double>(), this._printer);
            }
            else if (name.Equals("Triangle", StringComparison.OrdinalIgnoreCase))
            {
                if (!jsonObject.TryGetValue("Side1", StringComparison.OrdinalIgnoreCase, out var side1Token)
                    || side1Token.Type != JTokenType.Float
                    || !jsonObject.TryGetValue("Side2", StringComparison.OrdinalIgnoreCase, out var side2Token)
                    || side2Token.Type != JTokenType.Float
                    || !jsonObject.TryGetValue("Side3", StringComparison.OrdinalIgnoreCase, out var side3Token)
                    || side3Token.Type != JTokenType.Float)
                {
                    throw new InvalidOperationException("Unable to parce rectangle type from JSON.");
                }

                shape = new Triangle(jsonObject["Side1"].Value<double>(), 
                                        jsonObject["Side2"].Value<double>(),
                                        jsonObject["Side3"].Value<double>(), this._printer);
            }
            else
            {
                throw new InvalidOperationException("Unknown shape name.");
            }

            serializer.Populate(jsonObject.CreateReader(), shape);
            return shape;
        }

        public override void WriteJson(JsonWriter writer, Shape? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
