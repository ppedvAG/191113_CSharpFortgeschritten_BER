using FreeFeatures;
using PaidFeatures;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TRLogic;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping -> Initialisieren der Logik
        static void Main(string[] args)
        {
            var parser = new RegexParser();
            var rechner = new ModularRechner(new Addition(), new Subtraktion(), new Division());
            new KonsolenUI(parser, rechner).Start();
        }
    }
}
