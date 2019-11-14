using Domain;
using System;

namespace PaidFeatures
{
    public class Division : IRechenart
    {
        public string[] Operator => new string[] { ":", "/" };

        public int Rechne(int z1, int z2)
        {
            if (z2 == 0)
                throw new DivideByZeroException();
            else
                return z1 / z2;
        }
    }
}
