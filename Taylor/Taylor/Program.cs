using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taylor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadej x: ");
            double x = double.Parse(Console.ReadLine());

            // s pevně zadanou přesností
            double y = Taylor.Exp(x);
            Console.WriteLine();
            Console.WriteLine("exp({0}) = {1, 20:F10}", x, y);
            Console.WriteLine();

            // s požadovanou přesností
            y = Taylor.Exp(x, 0.0000001);
            Console.WriteLine();
            Console.WriteLine("exp({0}) = {1, 20:F10}", x, y);
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Zadej uhel (ve °): ");
            double uhel = double.Parse(Console.ReadLine());

            // s požadovanou přesností
            // pro jednoduchost: x = 30° = pi*30°/180°
            x = Math.PI * uhel / 180.0;

            y = Taylor.Sinus(x, 0.0000001);
            Console.WriteLine();
            Console.WriteLine("sin({0}°) = {1, 20:F10}", uhel, y);
            Console.WriteLine();

            Console.WriteLine("stiskni ENTER");
            Console.ReadLine();
        }

    }
}
