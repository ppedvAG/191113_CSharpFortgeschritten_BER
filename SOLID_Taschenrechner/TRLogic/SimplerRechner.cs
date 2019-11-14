using Domain;
using System;

namespace TRLogic
{
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

}
