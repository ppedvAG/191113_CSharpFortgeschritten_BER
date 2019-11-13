using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloGenerics
{
    class GenericStack<T> // Platzhalter für einen Datentypen
    {
        public GenericStack()
        {
            index = 0;
            data = new T[4];
        }

        private int index;
        private T[] data;

        public void Push(T item)
        {
            if (index == data.Length)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
                // GC.Collect();
            }
            data[index++] = item;
        }


        public T Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Der Stack ist leer");

            var result = data[--index];
            data[index] = default; // Standardwert für den Datentypen hinter "T"
            return result;
        }

        public void Clear()
        {
            data = new T[4];
            GC.Collect();
        }
    }
}
