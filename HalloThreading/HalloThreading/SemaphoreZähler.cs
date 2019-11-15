using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreading
{
    class SemaphoreZähler
    {
        private Semaphore semaphore = new Semaphore(5, 5);
        private int zähler = 0;


        public void Machwas(object parameter)
        {
            semaphore.WaitOne();
                Thread.Sleep(50);
                zähler++;
                Console.WriteLine($"{zähler} wurde von {parameter} erhöht");
                zähler--;
            semaphore.Release();
        }
    }
}
