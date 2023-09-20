using ShapesClassLibrary.Printers;
using ShapesClassLibrary.Shapes;

namespace AnimalAspCoreMvc.Services
{
    public interface IShapeService
    {
        public IEnumerable<Shape> GetShapes();

        public void AddShape(Shape shape);

        public void SaveShapesInfoToTxt(string filePath);

        public void SaveShapesToJson(string filePath);

        public void LoadShapesFromJson(IFormFile file);

        public void SaveShapesToBinary(string filePath);

        public void LoadShapesFromBinary(IFormFile file);
    }
}