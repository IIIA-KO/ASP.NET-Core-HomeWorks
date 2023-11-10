using CharactersClassLibrary.Characters;
using ShapesClassLibrary.Shapes;

namespace AspNetCoreMvcApp.Services.Interfaces
{
    public interface IShapeService
    {
        public IEnumerable<Shape> GetShapes();

        public void AddShape(Shape shape);

        public void SaveShapesInfoToTxt(string filePath);
    }
}
