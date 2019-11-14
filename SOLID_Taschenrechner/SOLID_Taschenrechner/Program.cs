using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping -> Initialisieren der Logik
        static void Main(string[] args)
        {
            new KonsolenUI().Start();
        }
    }
    public struct Formel
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
    }

    public class StringSplitParser
    {
        public Formel Parse(string input)
        {
            string[] parts = input.Split();
            Formel output = new Formel();
            output.Operand1 = Convert.ToInt32(parts[0]);
            output.Operator = parts[1];
            output.Operand2 = Convert.ToInt32(parts[2]);

            return output;
        }
    }

    public class SimplerRechner
    {
        public int Berechne(Formel input)
        {
            if (input.Operator == "+")                  // entscheidung
                return input.Operand1 + input.Operand2; // berechnung
            else if (input.Operator == "-")
                return input.Operand1 - input.Operand2;
            // .....

            throw new InvalidOperationException($"Operator {input.Operator} ist unbekannt");
        }
    }

    public class KonsolenUI
    {
        public void Start()
        {
            // I/O
            Console.WriteLine("Bitte geben Sie die Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            // Parsen
            var parser = new StringSplitParser();
            var formel = parser.Parse(eingabe);

            // Rechnen
            var rechner = new SimplerRechner();
            var ergebnis = rechner.Berechne(formel);

            //I/O
            Console.WriteLine($"Das Ergebnis ist {ergebnis}");
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
