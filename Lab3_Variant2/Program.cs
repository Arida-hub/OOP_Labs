
using System;

namespace Lab3_Variant2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Расчёт объёма трёхмерных фигур");
            Console.WriteLine();

            // Ввод радиуса шара
            Console.WriteLine("Введите данные для шара:");
            double radius = ReadPositiveDouble("Радиус: ");

            // Ввод размеров пирамиды
            Console.WriteLine();
            Console.WriteLine("Введите данные для пирамиды:");
            double pyramidLength = ReadPositiveDouble("Длина основания: ");
            double pyramidWidth = ReadPositiveDouble("Ширина основания: ");
            double pyramidHeight = ReadPositiveDouble("Высота: ");

            // Ввод размеров параллелепипеда
            Console.WriteLine();
            Console.WriteLine("Введите данные для параллелепипеда:");
            double length = ReadPositiveDouble("Длина: ");
            double width = ReadPositiveDouble("Ширина: ");
            double height = ReadPositiveDouble("Высота: ");

            // Создание объектов
            IThreeDimensionalShape[] shapes =
            {
                new Sphere(radius),
                new Pyramid(pyramidLength, pyramidWidth, pyramidHeight),
                new Parallelepiped(length, width, height)
            };

            // Вычисление и вывод объёмов
            Console.WriteLine();
            Console.WriteLine("Результаты расчёта:");
            Console.WriteLine();

            foreach (IThreeDimensionalShape shape in shapes)
            {
                Console.WriteLine("Фигура: " + shape.Name);
                Console.WriteLine("Объём: " + shape.CalculateVolume());
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        // Метод для ввода и проверки положительных чисел
        static double ReadPositiveDouble(string message)
        {
            double value;

            while (true)
            {
                Console.Write(message);

                if (!double.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Ошибка! Необходимо ввести число.");
                }
                else if (value == 0)
                {
                    Console.WriteLine("Ошибка! Значение не может быть равно нулю.");
                }
                else if (value < 0)
                {
                    Console.WriteLine("Ошибка! Значение должно быть положительным.");
                }
                else
                {
                    return value;
                }
            }
        }
    }
}
