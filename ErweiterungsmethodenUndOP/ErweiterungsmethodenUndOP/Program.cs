using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErweiterungsmethodenUndOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl1 = 12;

            Erweiterungsmethoden.Verdoppeln(zahl1);
            zahl1.Verdoppeln();

            Bruch b1 = new Bruch(1, 2);
            Bruch b2 = new Bruch(1, 4);

            Bruch erg = b1 * b2;
            Bruch erg2 = b1 * 3;

            b1 *= 12;

            Console.WriteLine($"Das Ergebnis ist: {erg}");
            Console.WriteLine($"Das Ergebnis ist: {erg2}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
