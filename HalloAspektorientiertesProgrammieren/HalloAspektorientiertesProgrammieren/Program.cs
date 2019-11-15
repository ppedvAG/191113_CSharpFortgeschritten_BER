using AutoFixture;
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
            #region Beispiel: Aspektorientierte Programmierung
            //IRepository repo = new AuthRepository(
            //                        new LoggingRepository(new EFRepository(new EFContext())),
            //                        User.User);

            //// Mit Frameworks zb auch so :
            //// new EFRepository().WithLogger().WithAuth();

            //Person p1 = new Person();
            //p1.Vorname = "Tom";
            //p1.Nachname = "Ate";
            //p1.Alter = 20;
            //p1.Kontostand = 200m;

            //// Irgendeine Logik
            //repo.Add(p1);
            //var loaded = repo.GetByID<Person>(1);
            //var all = repo.GetAll<Person>();
            //p1.Nachname = "Atinger";
            //repo.Update(p1);
            //repo.Delete(p1);
            //repo.Save(); 
            #endregion

            // TPL: Task, Parallel, PLINQ -> LINQ-Abfragen parallelisieren


            // 1): Daten erstellen:
            // Tool: Autofixture
            //Fixture fix = new Fixture();
            //// var data = fix.CreateMany<Person>(100_000);
            //var data = fix.Build<Person>()
            //              .With(x => x.Alter,42)
            //              .Without(x => x.ID)
            //              .CreateMany(100_000);



            EFRepository repo = new EFRepository(new EFContext());

            var item = repo.Query<Person>().AsParallel()
                                           .Where(x => x.Kontostand > 500)
                                           .OrderByDescending(x => x.Alter)
                                           .ToList();


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
