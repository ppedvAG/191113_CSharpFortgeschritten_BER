using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        private readonly EFContext context;

        public void Add<T>(T item) where T : Entity
        {
            Console.WriteLine("Add in EF");
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            Console.WriteLine("Delete in EF");
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            Console.WriteLine("GetAll in EF");
            return context.Set<T>().ToArray();
        }

        public T GetByID<T>(int id) where T : Entity
        {
            Console.WriteLine("GetByID in EF");
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            Console.WriteLine("Save in EF");
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
            var loaded = GetByID<T>(item.ID);
            if(loaded != null)
            {
                Console.WriteLine("Update in EF");
                context.Entry(loaded).CurrentValues.SetValues(item);
            }
        }
    }
}
