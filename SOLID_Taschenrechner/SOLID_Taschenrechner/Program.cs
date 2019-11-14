using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            // 1) Alle Dateien laden:

            List<Assembly> customLoadedAssemblies = new List<Assembly>();

            if (!Directory.Exists(".\\Plugins"))
                Directory.CreateDirectory(".\\Plugins"); // Damit keine Exception kommt !

            foreach (var file in Directory.GetFiles(".\\Plugins"))
            {
                if (Path.GetExtension(file) == ".dll" ||
                    Path.GetExtension(file) == ".exe")
                       customLoadedAssemblies.Add(Assembly.LoadFrom(file));
            }

            // Alle aktuell geladenen Assemblies:
            // var all = AppDomain.CurrentDomain.GetAssemblies();

            // Ziel: Alles, was die Schnittstelle "IRechenart" implementiert, mit Activator instanzieren und dem Modularrechner übergeben

            IRechenart[] loadedRechenarten = customLoadedAssemblies.SelectMany(x => x.GetTypes())
                                                                   .Where(x => typeof(IRechenart).IsAssignableFrom(x) &&
                                                                               x.IsAbstract == false && // gilt für static UND abstract
                                                                               x.IsInterface == false)
                                                                   .Select(x => (IRechenart)Activator.CreateInstance(x))
                                                                   .ToArray();


            var rechner = new ModularRechner(loadedRechenarten);
            var parser = new RegexParser();
            //var rechner = new ModularRechner(new Addition(), new Subtraktion(), new Division());
            new KonsolenUI(parser, rechner).Start();
        }
    }
}
