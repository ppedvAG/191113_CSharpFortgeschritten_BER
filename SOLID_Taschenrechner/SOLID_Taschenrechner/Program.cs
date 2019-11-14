using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping -> Initialisieren der Logik
        static void Main(string[] args)
        {
            var parser = new RegexParser();
            var rechner = new ModularRechner(new Addition(),new Subtraktion());
            new KonsolenUI(parser,rechner).Start();
        }
    }
    public struct Formel
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
    }

    public interface IParser
    {
        Formel Parse(string input);
    }

    public class RegexParser : IParser
    {
        // https://regexr.com
        public RegexParser(string pattern = @"(-?\d+)\s*(\D+)\s*(-?\d+)")
        {
            regex = new Regex(pattern);
        }
        private readonly Regex regex;

        public Formel Parse(string input)
        {
            var result = regex.Match(input);
            if(result.Success)
            {
                Formel output = new Formel();
                output.Operand1 = Convert.ToInt32(result.Groups[1].Value);
                output.Operator = result.Groups[2].Value;
                output.Operand2 = Convert.ToInt32(result.Groups[3].Value);

                return output;
            }
            else
                throw new FormatException("Ihre Eingabe ist leider keine gültige Formel");
        }
    }

    public class StringSplitParser : IParser
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

    public interface IRechner
    {
        int Berechne(Formel input);
    }
    public class SimplerRechner : IRechner
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

    public class ModularRechner : IRechner
    {
        public ModularRechner(params IRechenart[] unterstützteRechenarten)
        {
            this.unterstützteRechenarten = unterstützteRechenarten;
        }
        private readonly IRechenart[] unterstützteRechenarten;


        public int Berechne(Formel input)
        {
            //LINQ
            var rechenart = unterstützteRechenarten.FirstOrDefault(x => x.Operator == input.Operator);
            if (rechenart == null)
            {
                // ToDo: User darf sich den Operator selber aussuchen, da keiner Matcht
                throw new InvalidOperationException($"Der Operator {input.Operator} wird leider nicht unterstützt.");
            }
            else
                return rechenart.Rechne(input.Operand1, input.Operand2);
        }
    }

    public interface IRechenart
    {
        string Operator { get; }

        int Rechne(int z1, int z2);
    }

    public class Addition : IRechenart
    {
        // ReadOnly-Property
        public string Operator => "+";
        public int Rechne(int z1, int z2) => z1 + z2;
        //{
        //    return z1 + z2;
        //}
    }
    public class Subtraktion : IRechenart
    {
        // ReadOnly-Property
        public string Operator => "-";
        public int Rechne(int z1, int z2) => z1 - z2;
        //{
        //    return z1 + z2;
        //}
    }

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
