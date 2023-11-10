using AspNetCoreMvcApp.Services.Interfaces;
using ShapesClassLibrary.Printers;
using ShapesClassLibrary.Shapes;

namespace AspNetCoreMvcApp.Services.Implementations
{
    public class ShapeService : IShapeService
    {
        private ICollection<Shape> Shapes { get; set; }
        public IShapePrinter _printer;

        public ShapeService(IShapePrinter printer)
        {
            Shapes = new List<Shape>();
            this._printer = printer;
        }

        public void AddShape(Shape shape)
        {
            if (shape == null)
            {
                throw new NullReferenceException("Unable to add shape due to null reference in Shape Service's collection.");
            }

            Shapes.Add(shape);
        }

        public IEnumerable<Shape> GetShapes()
        {
            return Shapes ?? new List<Shape>();
        }

        public void SaveShapesInfoToTxt(string filePath)
        {
            if (Shapes == null)
            {
                throw new NullReferenceException("Unable to output info about characters due to null reference in Character Service's collection.");
            }

            foreach (Shape shape in Shapes)
            {
                if (shape != null)
                {
                    shape.PrintShortInfoToFile(filePath);
                    shape.PrintFullInfoToFile(filePath);
                }
            }
        }
    }
}
