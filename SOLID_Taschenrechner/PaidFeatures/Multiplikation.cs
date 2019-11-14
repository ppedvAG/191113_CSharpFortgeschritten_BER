using Domain;

namespace PaidFeatures
{
    public class Multiplikation : IRechenart
    {
        public string[] Operator => new string[] { "*", "." };

        public int Rechne(int z1, int z2) => z1 * z2;
    }
}
