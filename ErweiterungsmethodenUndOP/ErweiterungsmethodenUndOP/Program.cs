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

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
