using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErweiterungsmethodenUndOP
{
    // 1) Static
    public static class Erweiterungsmethoden
    {
        // 2) this - Schlüsselwort
        public static int Verdoppeln(this int input)
        {
            return input * 2;
        }
        // Es ist alles(!) Erweiterbar
    }
}
