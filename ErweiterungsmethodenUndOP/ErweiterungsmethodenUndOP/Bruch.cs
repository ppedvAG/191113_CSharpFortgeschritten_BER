using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErweiterungsmethodenUndOP
{
    public class Bruch
    {
        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner;
        }

        public int Zähler { get; set; }
        public int Nenner { get; set; }

        // Operatorüberladung:

        // Arithmetische Operatoren:
        // +,-,*,/,%, .... +=, -= 
        // Bit-Operatoren
        // &,|,^, <<,>>, 
        // Vergleichsoperatoren:
        // <,>,<=,>=, == ,!=
        // ----> paarweise überladen !!!

        public static Bruch operator*(Bruch left, Bruch right)
        {
            return new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);
        }

        public static Bruch operator *(Bruch left, int right)
        {
            return new Bruch(left.Zähler * right, left.Nenner);
        }


        public static bool operator == (Bruch left, Bruch right)
        {
            return true;
        }
        public static bool operator !=(Bruch left, Bruch right)
        {
            return false;
        }


        public override string ToString()
        {
            return $"{Zähler}/{Nenner}";
        }
    }
}
