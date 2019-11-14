using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreading
{
    class Program
    {
        // Delegate-Type
        public delegate void MachEtwas();
        public delegate void MachEtwas2(int Zahl);

        static void Main(string[] args)
        {
            // Delegaten und Events:
            #region Delegate - Alt
            ////MachEtwas del = new MachEtwas(A);
            ////del.Invoke();

            ////MachEtwas del2 = B; // Kurzschreibweise
            ////del2(); // Kurzschreibweise

            ////MachEtwas2 del3 = C;
            ////del3(12);

            ////Multicast-Delegaten

            ////MachEtwas del = A;
            ////del += B;

            ////del();

            ////del -= B;
            ////del();
            #endregion

            #region Action<T> und Func<T>

            //// Action: alles was void ist
            //Action del1 = A;
            //del1 += B;

            //Action<int> del2 = C;

            //// Func<T>: alles mit einer Rückgabe (letzter Eintrag: return-Type)
            //Func<int, int, int> rechner = Add; 
            #endregion

            // Für Oberflächen
            //EventHandler eh = MeinButton_Click;

            // Anwendungsfall:

            Button b = new Button();

            b.ClickEvent += MeinButton_Click;
            b.ClickEvent += Logger;

            b.Click();

            b.ClickEvent = null;             // absolut verboten !!!!! 

            b.Click();
            b.Click();
            b.ClickEvent -= Logger;
            b.Click();
            b.Click();

            b.ClickEvent.Invoke(null,null); // delegat auslösen : verboten !!!!
            b.ClickEvent.Invoke(null,null); // delegat auslösen : verboten !!!!
            b.ClickEvent.Invoke(null,null); // delegat auslösen : verboten !!!!


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now +  ": Button wurde geklickt");
        }

        private static void MeinButton_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        public static void A()
        {
            Console.WriteLine("A");
        }
        public static void B()
        {
            Console.WriteLine("B");
        }

        public static void C(int zahl)
        {
            Console.WriteLine($"C{zahl}");
        }


        public static int Add(int z1, int z2)
        {
            return z1 + z2;
        }
    }
}
