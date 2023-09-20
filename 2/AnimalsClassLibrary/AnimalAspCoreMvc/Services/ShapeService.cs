using ShapesClassLibrary.Shapes;
using ShapesClassLibrary.Printers;

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
            throw new NotImplementedException();
        }

        public void LoadShapesFromJson(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void LoadShapesFromBinary(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void SaveShapesToBinary(string filePath)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}