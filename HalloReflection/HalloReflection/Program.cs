using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HalloReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Typeninformation auslesen
            object o1 = new object();
            Type objektTyp = o1.GetType();

            Console.WriteLine(objektTyp);

            // o1.GetType()  -> Typeninformation von einer Instanz holen
            // typeof(Int32) -> Typeninformation einer Klasse

            // Objekte erstellen:
            //object o2 = Activator.CreateInstance(typeof(Int32));

            //Console.WriteLine(o2);
            //Console.WriteLine(o2.GetType());

            // Zur Laufzeit eine Assembly(exe oder dll) laden
            Assembly geladen = Assembly.LoadFrom("Rechner.dll");
            var allTypes = geladen.GetTypes();          // alle holen
            Type TaschenrechnerTyp = geladen.GetType("Rechner.Taschenrechner");  // Wenn man den namen kennt ;)

            object tr = Activator.CreateInstance(TaschenrechnerTyp);

            MethodInfo addInfo = TaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            var result = addInfo.Invoke(tr, new object[] { 12, 3 });
            Console.WriteLine(result);
            Console.WriteLine("---ANFANG---");
            Console.ReadKey();
        }
    }
}
