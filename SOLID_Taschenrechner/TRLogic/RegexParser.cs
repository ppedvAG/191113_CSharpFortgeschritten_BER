using Domain;
using System;
using System.Text.RegularExpressions;

namespace TRLogic
{
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
            if (result.Success)
            {
                Formel output = new Formel();
                output.Operand1 = Convert.ToInt32(result.Groups[1].Value);
                output.Operator = result.Groups[2].Value.Trim();
                output.Operand2 = Convert.ToInt32(result.Groups[3].Value);

                return output;
            }
            else
                throw new FormatException("Ihre Eingabe ist leider keine gültige Formel");
        }
    }

}
