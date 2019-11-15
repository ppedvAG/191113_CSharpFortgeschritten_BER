using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreading
{
    class Konto
    {
        public Konto(decimal startwert)
        {
            Kontostand = startwert;
        }
        private static int transaktionsNummer = 0;
        private readonly object lockObject = new object();
        public decimal Kontostand { get; set; }

        public void Einzahlen(decimal betrag)
        {
            Monitor.Enter(lockObject);
                Console.WriteLine($"{transaktionsNummer} Betrag vor dem Einzahlen: {Kontostand}");
                Kontostand += betrag;
                Console.WriteLine($"{transaktionsNummer} Betrag nach dem Einzahlen: {Kontostand}");
                transaktionsNummer++;
            Monitor.Exit(lockObject);
        }

        public void Abheben(decimal betrag)
        {
            lock (lockObject)
            {
                Console.WriteLine($"{transaktionsNummer} Betrag vor dem Abheben: {Kontostand}");
                Kontostand -= betrag;
                Console.WriteLine($"{transaktionsNummer} Betrag nach dem Abheben: {Kontostand}");
                transaktionsNummer++;
            }
        }



    }
}
