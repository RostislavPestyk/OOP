using System;

class Program
{
    static void Main()
    {
        double x, y, z, s;
        bool isXValid, isYValid, isZValid;

        Console.Write("Введіть значення x: ");
        isXValid = double.TryParse(Console.ReadLine(), out x);

        Console.Write("Введіть значення y: ");
        isYValid = double.TryParse(Console.ReadLine(), out y);

        Console.Write("Введіть значення z: ");
        isZValid = double.TryParse(Console.ReadLine(), out z);

        if (!isXValid || !isYValid || !isZValid)
        {
            Console.WriteLine("Некоректне значення параметрів. Введіть дійсні числа.");
            return;
        }

        double numerator = 2 * Math.Cos(Math.Pow(x, 2)) - (1 / Math.Sqrt(2)) + Math.Pow(Math.E, 2);
        double denominator = (2.0 / 3.0) + Math.Sin(Math.Pow(y, 2) - z);

        if (denominator == 0)
        {
            Console.WriteLine("Помилка: знаменник не може дорівнювати нулю.");
            return;
        }

        s = numerator / denominator;

        Console.WriteLine("Результат: s = {0:F3}", s);
    }
}
