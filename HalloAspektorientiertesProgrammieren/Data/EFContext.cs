using Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data
{
    public class EFContext : DbContext
    {
        public EFContext() : base(@"Server=(localDb)\MSSQLLocalDb;Database=Personenverwaltung;Trusted_Connection=true")
        {

        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Anstelle von "Persons" eine "Person" - Tabelle
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
