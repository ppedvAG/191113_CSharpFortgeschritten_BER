using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloGenerics
{
    class IntegerStack
    {
        public IntegerStack()
        {
            index = 0;
            data = new int[4];
        }

        private int index;
        private int[] data;

        public void Push(int item)
        {
            if (index == data.Length)
            {
                int[] newData = new int[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
                // GC.Collect();
            }
            data[index++] = item;
        }


        public int Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Der Stack ist leer");

            var result = data[--index];
            data[index] = 0; // array "leer" machen
            return result;
        }

        public void Clear()
        {
            data = new int[4];
            GC.Collect();
        }

        // indexer + TAB + TAB

        //public int this[int gesuchterKey]
        //{
        //    get 
        //    {
        //        for (int i = 0; i < 10000000; i++)
        //        {
        //            int hex = 0xFF_00_FF;
        //            byte maske = 0b_0000_0010;
        //        }
        //        for (int i = 0; i < 10_000_000; i++)
        //        {

        //        }
        //    }
        //    set { data[index] = value; }
        //}

    }

    class Dictionary<TKey, TValue> 
        where TKey : class 
        where TValue: struct
    {

    }
}
