using Domain;
using System;
using System.Linq;

namespace TRLogic
{
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
            var rechenart = unterstützteRechenarten.FirstOrDefault(x => x.Operator.Any(op => op == input.Operator));
            if (rechenart == null)
            {
                // ToDo: User darf sich den Operator selber aussuchen, da keiner Matcht
                throw new InvalidOperationException($"Der Operator {input.Operator} wird leider nicht unterstützt.");
            }
            else
                return rechenart.Rechne(input.Operand1, input.Operand2);
        }
    }

}
