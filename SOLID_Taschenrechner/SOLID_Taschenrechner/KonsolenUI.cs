using Domain;
using System;

namespace SOLID_Taschenrechner
{
    public class KonsolenUI
    {
        public KonsolenUI(IParser parser, IRechner rechner)
        {
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
            this.rechner = rechner ?? throw new ArgumentNullException(nameof(rechner));
        }

        private IParser parser;
        private IRechner rechner;

        public void Start()
        {
            // I/O
            Console.WriteLine("Bitte geben Sie die Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            // Parsen
            var formel = parser.Parse(eingabe);

            // Rechnen
            int ergebnis = rechner.Berechne(formel);

            //I/O
            Console.WriteLine($"Das Ergebnis ist {ergebnis}");
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
