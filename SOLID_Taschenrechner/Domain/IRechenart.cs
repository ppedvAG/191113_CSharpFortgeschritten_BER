namespace Domain
{
    public interface IRechenart
    {
        string[] Operator { get; }

        int Rechne(int z1, int z2);
    }
}
