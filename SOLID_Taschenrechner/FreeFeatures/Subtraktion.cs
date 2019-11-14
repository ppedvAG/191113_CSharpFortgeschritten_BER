using Domain;
using System;

namespace FreeFeatures
{
    public class Subtraktion : IRechenart
    {
        // ReadOnly-Property
        public string[] Operator => new string[] { "-", "_" };
        public int Rechne(int z1, int z2) => z1 - z2;
        //{
        //    return z1 + z2;
        //}
    }
}
