using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    static class MyListAddition
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] arr = new T[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                arr[i] = list[i];
            }

            return arr;
        }
    }
}
