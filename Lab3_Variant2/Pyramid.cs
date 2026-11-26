
namespace Lab3_Variant2
{
    public class Pyramid : IThreeDimensionalShape
    {
        public double Length { get; }
        public double Width { get; }
        public double Height { get; }

        public string Name
        {
            get { return "Пирамида"; }
        }

        public Pyramid(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;

            if (length <= 0 || width <= 0 || height <= 0)
            {
                throw new ArgumentException(
                    "Размеры фигуры должны быть положительными.");
            }
        }

        public double CalculateVolume()
        {
            return (Length * Width * Height) / 3.0;
        }
    }
}
