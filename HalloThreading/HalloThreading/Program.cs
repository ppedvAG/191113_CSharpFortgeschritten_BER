using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreading
{
    class Program
    {
        // Delegate-Type
        // public delegate void MachEtwas();
        // public delegate void MachEtwas2(int Zahl);
        static void Main(string[] args)
        {
            // Delegaten und Events:
            #region Delegate - Alt
            ////MachEtwas del = new MachEtwas(A);
            ////del.Invoke();

            ////MachEtwas del2 = B; // Kurzschreibweise
            ////del2(); // Kurzschreibweise

            ////MachEtwas2 del3 = C;
            ////del3(12);

            ////Multicast-Delegaten

            ////MachEtwas del = A;
            ////del += B;

            ////del();

            ////del -= B;
            ////del();
            #endregion

            #region Action<T> und Func<T>

            //// Action: alles was void ist
            //Action del1 = A;
            //del1 += B;

            //Action<int> del2 = C;

            //// Func<T>: alles mit einer Rückgabe (letzter Eintrag: return-Type)
            //Func<int, int, int> rechner = Add; 
            #endregion

            // Für Oberflächen
            //EventHandler eh = MeinButton_Click;

            #region Anwendungsfall

            //Button b = new Button();

            //b.ClickEvent += MeinButton_Click;
            //b.ClickEvent += Logger;

            //b.Click();

            //b.ClickEvent = null;             // absolut verboten !!!!! 

            //b.Click();
            //b.Click();
            //b.ClickEvent -= Logger;
            //b.Click();
            //b.Click();

            //b.ClickEvent.Invoke(null,null); // delegat auslösen : verboten !!!!
            //b.ClickEvent.Invoke(null,null); // delegat auslösen : verboten !!!!
            //b.ClickEvent.Invoke(null,null); // delegat auslösen : verboten !!!! 
            #endregion

            #region Basisfunktionalität mit Threads
            //Thread t1 = new Thread(MachEtwas);
            //t1.Start();

            //Thread t2 = new Thread(MachEtwasMitEinemParameter);
            //t2.Start("_");

            //Thread.Sleep(5000);
            //t2.Abort();

            //t1.Join(); // Warten bis t1 fertig ist 
            #endregion

            #region ThreadPool
            //ThreadPool.GetAvailableThreads(out int workerThreads, out int portThreads);
            //Console.WriteLine(workerThreads); 
            //Console.WriteLine(portThreads); 

            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,1);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,2);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,3);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,4);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,5);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,6);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,7);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,8);
            //ThreadPool.QueueUserWorkItem(MachEtwasMitEinemParameter,9);

            //// Threadpool: Background-Threads
            #endregion

            #region Monitor/Lock - Beispiel
            //Konto meinKonto = new Konto(1000);

            //for (int i = 0; i < 100; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(ZufälligesKontoupdate,meinKonto);
            //} 
            #endregion

            #region Mutex - Beispiel
            //bool newInstance;
            //Mutex mutex = new Mutex(true, "MeinMutex",out newInstance );

            //if(newInstance == false)
            //{
            //    Console.WriteLine("Programm läuft bereits, bitte warten !");
            //    Console.ReadKey();
            //    return;
            //}

            //for (int i = 0; i < 100; i++)
            //{
            //    bool result = mutex.WaitOne();
            //        Thread.Sleep(100);
            //        Console.WriteLine(i);
            //    mutex.ReleaseMutex();
            //}
            #endregion

            SemaphoreZähler sz = new SemaphoreZähler();
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(sz.Machwas,i);
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void ZufälligesKontoupdate(object state)
        {
            Konto meinKonto = (Konto)state;
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                if (r.Next(0, 2) % 2 == 0)
                    meinKonto.Abheben(r.Next(0, 1000));
                else
                    meinKonto.Einzahlen(r.Next(0, 1000));
            }

        }

        private static void MachEtwasMitEinemParameter(object item)
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                    Console.Write(item);
                }
                catch (ThreadAbortException ex)
                {
                    Console.WriteLine("Ich mach trotzdem weiter ;)" );
                    Thread.ResetAbort();
                }
            }
        }

        private static void MachEtwas()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write('#');
            }
        }



        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now +  ": Button wurde geklickt");
        }

        private static void MeinButton_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        public static void A()
        {
            Console.WriteLine("A");
        }
        public static void B()
        {
            Console.WriteLine("B");
        }

        public static void C(int zahl)
        {
            Console.WriteLine($"C{zahl}");
        }


        public static int Add(int z1, int z2)
        {
            return z1 + z2;
        }
    }
}
