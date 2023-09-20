﻿using ShapesClassLibrary.Printers;

namespace ShapesClassLibrary.Shapes
{
    public class Rectangle : Shape
    {
        private double _height;
        public double Height
        {
            get => this._height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive.", nameof(value));
                }

                this._height = value;
            }
        }

        private double _width;
        public double Width
        {
            get => this._width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive.", nameof(value));
                }

                this._width = value;
            }
        }

        public override string Name { get => "Rectangle"; }

        public override string OutputMessage { get => $"A rectangle with height {Height} and width {Width}"; }

        public Rectangle(IShapePrinter printer, double height, double width) : base(printer)
        {
            Height = height;
            Width = width;
        }

        public override string PrintShapeHtml()
        {
            return $"<div style=\"height: {Height}px; width: {Width}px; background-color: #555;\"></div>";
        }
    }
}