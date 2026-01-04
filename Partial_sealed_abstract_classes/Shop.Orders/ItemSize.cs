using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public struct ItemSize
    {
        public decimal WidthCm { get; }
        public decimal HeightCm { get; }
        public decimal DepthCm { get; }

        public ItemSize(decimal widthCm, decimal heightCm, decimal depthCm)
        {
            WidthCm = widthCm;
            HeightCm = heightCm;
            DepthCm = depthCm;
        }

        public decimal VolumeCm3
        {
            get { return WidthCm * HeightCm * DepthCm; }
        }

        public override string ToString()
        {
            return WidthCm + "x" + HeightCm + "x" + DepthCm + " cm";
        }
    }
}
