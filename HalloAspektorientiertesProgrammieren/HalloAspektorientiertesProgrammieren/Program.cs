using Data;
using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloAspektorientiertesProgrammieren
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new AuthRepository(
                                    new LoggingRepository(new EFRepository(new EFContext())),
                                    User.User);

            // Mit Frameworks zb auch so :
            // new EFRepository().WithLogger().WithAuth();

            Person p1 = new Person();
            p1.Vorname = "Tom";
            p1.Nachname = "Ate";
            p1.Alter = 20;
            p1.Kontostand = 200m;

            // Irgendeine Logik
            repo.Add(p1);
            var loaded = repo.GetByID<Person>(1);
            var all = repo.GetAll<Person>();
            p1.Nachname = "Atinger";
            repo.Update(p1);
            repo.Delete(p1);
            repo.Save();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
