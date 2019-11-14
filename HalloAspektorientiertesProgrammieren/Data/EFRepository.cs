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
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToArray();
        }

        public T GetByID<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
            var loaded = GetByID<T>(item.ID);
            if(loaded != null)
            {
                context.Entry(loaded).CurrentValues.SetValues(item);
            }
        }
    }
}
