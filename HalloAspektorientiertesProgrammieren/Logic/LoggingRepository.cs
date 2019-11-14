using Domain;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class LoggingRepository : IRepository
    {
        public LoggingRepository(IRepository parent)
        {
            this.parent = parent;
        }
        private IRepository parent;

        private void WriteLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]:{message}");
            Console.ResetColor();
        }


        public void Add<T>(T item) where T : Entity
        {
            WriteLog("Vor dem Add");
            parent.Add<T>(item);
            WriteLog("Nach dem Add");
        }

        public void Delete<T>(T item) where T : Entity
        {
            WriteLog("Vor dem Delete");
            parent.Delete<T>(item);
            WriteLog("Nach dem Delete");
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            WriteLog("Vor dem GetAll");
            var result = parent.GetAll<T>();
            WriteLog("Nach dem GetAll");
            return result;
        }

        public T GetByID<T>(int id) where T : Entity
        {
            WriteLog("Vor dem GetByID");
            var result = parent.GetByID<T>(id);
            WriteLog("Nach dem GetByID");
            return result;
        }

        public void Save()
        {
            WriteLog("Vor dem Save");
            parent.Save();
            WriteLog("Nach dem Save");
        }

        public void Update<T>(T item) where T : Entity
        {
            WriteLog("Vor dem Update");
            parent.Update<T>(item);
            WriteLog("Nach dem Update");
        }
    }
}
