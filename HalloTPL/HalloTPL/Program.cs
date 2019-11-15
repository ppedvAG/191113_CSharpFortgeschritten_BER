using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tasks erstellen:
            //// 1):
            //Task t1 = new Task(MachEtwas);
            //t1.Start();

            //// 2) .NET 4.0
            //Task t2 = Task.Factory.StartNew(MachEtwas2); // Task startet sofort
            //// 3) .NET 4.5
            //// Task.Factory.StartNew(MachEtwas3,CancellationToken.None,TaskCreationOptions.DenyChildAttach,TaskScheduler.Default);
            //Task t3 = Task.Run(MachEtwas3); 
            #endregion

            #region Tasks mit einer Rückgabe

            //Task<string> t1 = new Task<string>(GibUhrzeit);
            //t1.Start();

            ////Thread.Sleep(5000);

            //// t1.ContinueWith(XYZ); // Setzt den Task mit der Methode XYZ fort
            //Console.WriteLine(t1.Result); // Wartet automatisch 
            #endregion

            #region Task beenden
            //CancellationTokenSource cts = new CancellationTokenSource();

            //Task t1 = Task.Factory.StartNew(() =>
            //{
            //    while(true)
            //    {
            //        Thread.Sleep(100);
            //        if (cts.IsCancellationRequested)
            //        {
            //            Console.WriteLine("ok ich mach schluss");
            //            break;
            //        }
            //        // Alternative
            //        // cts.Token.ThrowIfCancellationRequested();

            //        Console.Write("#");
            //    }
            //},cts.Token);

            //Thread.Sleep(5000);
            //Console.WriteLine("jetzt wird der Task gekillt:");
            //cts.Cancel();
            #endregion

            #region Exceptions im Task
            //Task t1 = Task.Run(() => throw new DivideByZeroException());
            //Task t2 = Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(3000);
            //    throw new FormatException();
            //});
            //Task t3 = new Task(() =>
            //{
            //    Thread.Sleep(5000);
            //    throw new StackOverflowException();
            //});
            //t3.Start();


            //// Variante 1: Nachschaun:

            ////Thread.Sleep(8000);
            ////if(t1.IsCompleted)
            ////    Console.WriteLine("t1 ist fertig");
            ////if(t2.IsFaulted)
            ////    Console.WriteLine("t2 ist fertig aber kapput :( ");

            //// Variante 2: Warten

            ////t3.Wait();
            //try
            //{
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex)
            //{
            //    // mit foreach durch die InnerExceptions durchgehen !!!!
            //}
            #endregion

            // JIT:
            ForTest(10);
            ParallelTest(10);

            int[] durchgänge = { 1_000, 10_000, 25_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 50_000_000 };
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < durchgänge.Length; i++)
            {
                Console.WriteLine($"-------------------Durchgang {durchgänge[i]}------------------------");
                watch.Restart();
                ForTest(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                ParallelTest(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds}ms");
            }

            
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }


        private static void ForTest(int durchgänge)
        {
            double[] erg = new double[durchgänge];
            for (int i = 0; i < durchgänge; i++)
            {
                erg[i] = Math.Floor((Math.Pow(i, 0.3333333) * Math.Sqrt(i +20) + Math.Sin(Math.E * i) % 15) / Math.Exp(i) + 5);
            }
        }

        private static void ParallelTest(int durchgänge)
        {
            double[] erg = new double[durchgänge];
            Parallel.For(0, durchgänge, new ParallelOptions {MaxDegreeOfParallelism=8 }, i =>
              {
                  erg[i] = Math.Floor((Math.Pow(i, 0.3333333) * Math.Sqrt(i + 20) + Math.Sin(Math.E * i) % 15) / Math.Exp(i) + 5);
              });
        }




        private static string GibUhrzeit()
        {
            Thread.Sleep(3000);
            return DateTime.Now.ToLongTimeString();
        }

        private static void MachEtwas3()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100); // Thread von dem Task
                Console.Write("x");
            }
        }

        private static void MachEtwas2()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100); // Thread von dem Task
                Console.Write("-");
            }
        }

        private static void MachEtwas()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100); // Thread von dem Task
                Console.Write("#");
            }
        }
    }
}
