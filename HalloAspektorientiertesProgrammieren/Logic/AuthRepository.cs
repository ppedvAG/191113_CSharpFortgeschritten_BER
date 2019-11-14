using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AuthRepository : IRepository
    {
        public AuthRepository(IRepository parent, User currentUser)
        {
            this.parent = parent;
            this.currentUser = currentUser;
        }
        private IRepository parent;
        private readonly User currentUser;
        private void WriteLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]:{message}");
            Console.ResetColor();
        }


        public void Add<T>(T item) where T : Entity
        {
            if (currentUser == User.Admin || currentUser == User.User)
                parent.Add<T>(item);
            else
                WriteLog("Der aktuelle User darf kein Add ausführen");
        }

        public void Delete<T>(T item) where T : Entity
        {
            if (currentUser == User.Admin)
                parent.Delete<T>(item);
            else
                WriteLog("Der aktuelle User darf kein Delete ausführen");
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return parent.GetAll<T>();
        }

        public T GetByID<T>(int id) where T : Entity
        {
            return parent.GetByID<T>(id);
        }

        public void Save()
        {
            if (currentUser == User.Admin || currentUser == User.User)
                parent.Save();
            else
                WriteLog("Der aktuelle User darf kein Save ausführen");
        }

        public void Update<T>(T item) where T : Entity
        {
            if (currentUser == User.Admin || currentUser == User.User)
                parent.Update<T>(item);
            else
                WriteLog("Der aktuelle User darf kein Update ausführen");
        }
    }
}
