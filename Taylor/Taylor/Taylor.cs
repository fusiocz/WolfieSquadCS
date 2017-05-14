using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taylor
{
    class Taylor
    {
        // metody třídy uvedeny jako:
        // - public => veřejně přístupné, jinak by se nedaly zavolat
        // - static => není potřeba před zavoláním metod vytvářet objekt, stačí pouze metody zavolat
        //              (jako se volá např. Math.Pow())

        // pevná přesnost výpočtu - 0,001
        public static double Exp(double x)
        {
            double rozdil;
            double clenPosledni = 1;        // 0. člen posloupnosti (n = 0)
            double soucetPosledni = clenPosledni;

            double clenNovy, soucetNovy;
            int n = 1;

            clenNovy = x / n;                 // 1. člen posloupnosti (n = 1)
            soucetNovy = soucetPosledni + clenNovy;

            rozdil = Math.Abs(soucetNovy - soucetPosledni);

            Console.WriteLine();
            Console.WriteLine("{0, 6} | {1, 20:F10} | {2, 20:F10} | {3, 20:F10}", n, clenNovy, soucetNovy, rozdil);

            clenPosledni = clenNovy;
            soucetPosledni = soucetNovy;

            n++;

            do
            {
                clenNovy = clenPosledni * x / n;
                soucetNovy = soucetPosledni + clenNovy;

                rozdil = Math.Abs(soucetNovy - soucetPosledni);

                Console.WriteLine();
                Console.WriteLine("{0, 6} | {1, 20:F10} | {2, 20:F10} | {3, 20:F10}", n, clenNovy, soucetNovy, rozdil);

                clenPosledni = clenNovy;
                soucetPosledni = soucetNovy;

                n++;
            } while (rozdil > 0.001);

            return soucetPosledni;
        }

        // libovolná přesnost výpočtu
        public static double Exp(double x, double presnost)
        {
            double rozdil;
            double clenPosledni = 1;        // 0. člen posloupnosti (n = 0)
            double soucetPosledni = clenPosledni;

            double clenNovy, soucetNovy;
            int n = 1;

            clenNovy = x / n;                 // 1. člen posloupnosti (n = 1)
            soucetNovy = soucetPosledni + clenNovy;

            rozdil = Math.Abs(soucetNovy - soucetPosledni);

            Console.WriteLine();
            Console.WriteLine("{0, 6} | {1, 20:F10} | {2, 20:F10} | {3, 20:F10}", n, clenNovy, soucetNovy, rozdil);

            clenPosledni = clenNovy;
            soucetPosledni = soucetNovy;

            n++;

            do
            {
                clenNovy = clenPosledni * x / n;
                soucetNovy = soucetPosledni + clenNovy;

                rozdil = Math.Abs(soucetNovy - soucetPosledni);

                Console.WriteLine();
                Console.WriteLine("{0, 6} | {1, 20:F10} | {2, 20:F10} | {3, 20:F10}", n, clenNovy, soucetNovy, rozdil);

                clenPosledni = clenNovy;
                soucetPosledni = soucetNovy;

                n++;
            } while (rozdil > presnost);

            return soucetPosledni;
        }

        // libovolná přesnost výpočtu
        public static double Sinus(double x, double presnost)
        {
            double rozdil;
            double clenPosledni = x;        // 0. člen posloupnosti (n = 0)
            double soucetPosledni = clenPosledni;

            double clenNovy, soucetNovy;
            int n = 1;

            do
            {
                // u jednotlivých členů se střídají znaménka + a -
                clenNovy = -clenPosledni * Math.Pow(x, 2) / ((2 * n + 0) * (2 * n + 1));
                soucetNovy = soucetPosledni + clenNovy;

                rozdil = Math.Abs(soucetNovy - soucetPosledni);

                Console.WriteLine();
                Console.WriteLine("{0, 6} | {1, 20:F10} | {2, 20:F10} | {3, 20:F10}", n, clenNovy, soucetNovy, rozdil);

                clenPosledni = clenNovy;
                soucetPosledni = soucetNovy;

                n++;
            } while (rozdil > presnost);

            return soucetPosledni;
        }

    }
}
