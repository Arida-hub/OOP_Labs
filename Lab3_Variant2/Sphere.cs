
using System;

namespace Lab3_Variant2
{
    public class Sphere : IThreeDimensionalShape
    {
        public double Radius { get; }

        public string Name
        {
            get { return "Шар"; }
        }

        public Sphere(double radius)
        {
            Radius = radius;

            if (radius <= 0)
            {
                throw new ArgumentException(
                    "Размеры фигуры должны быть положительными.");
            }
        }

        public double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}

