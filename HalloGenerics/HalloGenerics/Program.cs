using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Stack aus .NET Framework
            //Stack<int> meinStack = new Stack<int>();

            //meinStack.Push(12);
            //meinStack.Push(7);
            //meinStack.Push(3);

            //Console.WriteLine(meinStack.Pop());
            //Console.WriteLine(meinStack.Pop());
            //Console.WriteLine(meinStack.Pop()); 
            #endregion

            #region Pre- und Postincrement
            //int zahl1 = 5;
            //int zahl2 = 0;

            //// zahl1++;
            //// ++zahl1;
            ////Console.WriteLine(zahl1);

            //zahl2 = ++zahl1;
            //Console.WriteLine(zahl1);
            //Console.WriteLine(zahl2);

            //zahl1 = 5;

            //// WIN + .
            //zahl2 = zahl1++ + ++zahl1; // 😎

            //Console.WriteLine(zahl2);

            //for (int i = 0; i < 10; ++i)
            //{

            //} 
            #endregion

            ObjectStack stack = new ObjectStack();

            stack.Push(12);
            stack.Push(7);
            stack.Push("Hallo Welt");
            stack.Push(33.333333);

            stack.Push(98765.99m); // Vergrößern

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            // Console.WriteLine(stack.Pop()); // Exception


            IntegerStack intStack = new IntegerStack();
            intStack.Push(12);

            GenericStack<int> genericIntStack = new GenericStack<int>();
            genericIntStack.Push(123);
            genericIntStack.Pop();

            GenericStack<string> genericStringStack = new GenericStack<string>();
            genericStringStack.Push("abcde");


            MachEtwas(12);
            MachEtwas<string>("Hallo Welt");
            MachEtwas(new IntegerStack());


            Console.WriteLine("---ENDE 😎---");
            Console.ReadKey();
        }


        public static void MachEtwas<T>(T item)
        {
            Console.WriteLine($"Ich mache etwas mit: {item}");
            // $"Die Summe von {++zahl1} und {zahl2++} ist {zahl1 + zahl2}";
        }
    }
}
