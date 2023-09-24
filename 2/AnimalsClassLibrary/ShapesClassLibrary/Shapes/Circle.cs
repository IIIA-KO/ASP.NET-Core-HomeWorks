using ShapesClassLibrary.Printers;

namespace ShapesClassLibrary.Shapes
{
    public class Circle : Shape
    {
        private double _radius;
        public double Radius
        {
            get => this._radius;

            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Radius must be positive.", nameof(value));
                }

                this._radius = value;
            }
        }

        public override string Name { get => "Circle"; }

        public override string OutputMessage { get => $"A circle with radius: {this._radius}"; }

        public Circle(double radius, IShapePrinter printer) : base(printer)
        {
            Radius = radius;
        }

        public override string PrintShapeHtml()
        {
            return $"<div style=\"height: {Radius}px; width: {Radius}px; background-color: #555; border-radius: 50%;\"></div>";
        }
    }
}
