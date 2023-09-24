using Newtonsoft.Json;
using ShapesClassLibrary.Printers;
using ShapesClassLibrary.Shapes;

namespace AnimalAspCoreMvc.Services
{
    public class ShapeService : IShapeService
    {
        private ICollection<Shape> _shapes { get; set; }
        public IShapePrinter _printer;

        public ShapeService(IShapePrinter printer)
        {
            this._shapes = new List<Shape>();
            this._printer = printer;
        }

        public IEnumerable<Shape> GetShapes()
        {
            return this._shapes;
        }

        public void AddShape(Shape shape)
        {
            this._shapes.Add(shape);
        }

        #region Saving/Loading
        public void SaveShapesInfoToTxt(string filePath)
        {
            foreach (Shape shape in this._shapes)
            {
                shape.PrintNameFile(filePath);
                shape.PrintShapeFile(filePath);
            }
        }

        public void SaveShapesToJson(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "Filepath cannot be null or empty");
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var json = JsonConvert.SerializeObject(this._shapes);
            File.WriteAllText(filePath, json);
        }

        public void LoadShapesFromJson(IFormFile file)
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
                    Converters = new List<JsonConverter> { new ShapeConverter(this._printer) }
                };

                IEnumerable<Shape> deserializedCollection = JsonConvert.DeserializeObject<IEnumerable<Shape>>(jsonString, settings);
                this._shapes = new List<Shape>(deserializedCollection);
            }
        }

        public void SaveShapesToBinary(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(this._shapes.Count);

                foreach (Shape shape in this._shapes)
                {
                    writer.Write(shape.GetType().FullName);
                    if (shape is Circle)
                    {
                        writer.Write(((Circle)shape).Radius);
                    }
                    else if (shape is Rectangle)
                    {
                        writer.Write(((Rectangle)shape).Height);
                        writer.Write(((Rectangle)shape).Width);
                    }
                    else if (shape is Triangle)
                    {
                        writer.Write(((Triangle)shape).Side1);
                        writer.Write(((Triangle)shape).Side2);
                        writer.Write(((Triangle)shape).Side3);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unable to serialize to binary file. Unknow shape type.");
                    }
                }
            }
        }

        public void LoadShapesFromBinary(IFormFile file)
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
                    int shapeCount = reader.ReadInt32();

                    this._shapes.Clear();

                    for (int i = 0; i < shapeCount; i++)
                    {
                        string typeName = reader.ReadString();

                        if (typeName == typeof(Circle).FullName)
                        {
                            double radius = reader.ReadDouble();
                            this._shapes.Add(new Circle(radius, this._printer));
                        }
                        else if (typeName == typeof(Rectangle).FullName)
                        {
                            double height = reader.ReadDouble();
                            double width = reader.ReadDouble();
                            this._shapes.Add(new Rectangle(height, width, this._printer));
                        }
                        else if (typeName == typeof(Triangle).FullName)
                        {
                            double side1 = reader.ReadDouble();
                            double side2 = reader.ReadDouble();
                            double side3 = reader.ReadDouble();
                            this._shapes.Add(new Triangle(side1, side2, side3, this._printer));
                        }
                        else
                        {
                            throw new InvalidOperationException("Unable to deserialize from binary file. Unknown shape type.");
                        }
                    }
                }
            }
        }
        #endregion
    }
}