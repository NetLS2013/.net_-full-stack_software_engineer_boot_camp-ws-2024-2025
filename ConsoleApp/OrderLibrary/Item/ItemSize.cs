using System;
using System.Collections.Generic;
using System.Text;

namespace OrderLibrary.Item
{
    public struct ItemSize
    {
        public double LengthCm { get; }
        public double WidthCm { get; }
        public double HeightCm { get; }

        public ItemSize(double length, double width, double height)
        {
            LengthCm = length;
            WidthCm = width;
            HeightCm = height;
        }
    }
}
