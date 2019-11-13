using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloGenerics
{
    class ObjectStack
    {
        public ObjectStack()
        {
            index = 0;
            data = new object[4];
        }

        private int index;
        private object[] data;

        public void Push(object item)
        {
            if(index == data.Length)
            {
                object[] newData = new object[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
                // GC.Collect();
            }
            data[index++] = item;
        }


        public object Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Der Stack ist leer");

            var result = data[--index];
            data[index] = null; // array "leer" machen
            return result;
        }

        public void Clear()
        {
            data = new object[4];
            GC.Collect();
        }
    }
}
