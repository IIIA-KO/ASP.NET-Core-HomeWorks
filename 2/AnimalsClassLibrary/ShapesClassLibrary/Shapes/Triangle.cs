using ShapesClassLibrary.Printers;

namespace ShapesClassLibrary.Shapes
{
    public class Triangle : Shape
    {
        private double _side1;
        public double Side1
        {
            get  => this._side1;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side1 must be positive.", nameof(value));
                }

                this._side1 = value;
            }
        }

        private double _side2;
        public double Side2
        {
            get => this._side2;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side2 must be positive.", nameof(value));
                }

                this._side2 = value;
            }
        }

        private double _side3;
        public double Side3
        {
            get => this._side3;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side3 must be positive.", nameof(value));
                }

                this._side3 = value;
            }
        }

        public override string Name { get => "Triangle"; }

        public override string OutputMessage { get => $"A triangle with sides {Side1}, {Side2}, {Side3}"; }

        public Triangle(IShapePrinter printer, double side1, double side2, double side3) : base(printer)
        {
            if (!IsValidTriangle(side1, side2, side3) || side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentException("Invalid side values for a triangle.");
            }

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        private bool IsValidTriangle(double side1, double side2, double side3)
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }

        public override string PrintShapeHtml()
        {
            return $"<div style=\"width: 0; height: 0; border-left: {Side1}px solid transparent; border-right: {Side2}px solid transparent; border-bottom: {Side3}px solid #555;\"></div>";
        }
    }
}