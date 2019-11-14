using Domain;
using System;

namespace TRLogic
{
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

}
