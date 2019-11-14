using Domain;

namespace FreeFeatures
{
    public class Addition : IRechenart
    {
        // ReadOnly-Property
        public string[] Operator => new string[] { "+" };
        public int Rechne(int z1, int z2) => z1 + z2;
        //{
        //    return z1 + z2;
        //}
    }
}
