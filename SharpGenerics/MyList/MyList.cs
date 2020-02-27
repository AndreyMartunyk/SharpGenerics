using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class MyList<T>
    {
        public int Length { get; private set; }
        private T[] _arr;

        public MyList()
        {
            _arr = new T[10];
            Length = 0;
        }

        private void increaseArray()
        {
            T[] newArray = new T[_arr]
        }

    }
}
