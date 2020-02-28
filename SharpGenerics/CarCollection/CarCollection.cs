using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCollection
{
    class CarCollection<T> where T : Car
    {
        public int Length { get; private set; }

        private const int START_ARRAY_SIZE = 10;
        private T[] _arr;

        public CarCollection(int startArraySize = START_ARRAY_SIZE)
        {
            if (startArraySize < 0)
            {
                startArraySize = START_ARRAY_SIZE;
            }

            _arr = new T[startArraySize];
            Length = 0;
        }

        public void Add(T elem)
        {
            if (_arr.Length <= Length)
            {
                increaseArray();
            }
            _arr[Length] = elem;
            ++Length;
        }

        public void Add(string carName, int yearOfIssue)
        {
            Add((T)new Car(carName, yearOfIssue));
        }

        public void ClearArray()
        {
            _arr = new T[START_ARRAY_SIZE];
            Length = 0;
        }

        public void Trim()
        {
            if (_arr.Length == Length)
            {
                return;
            }

            T[] newArray = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                newArray[i] = _arr[i];
            }

            _arr = newArray;
        }

        private void displaceArray(int index)
        {
            for (int i = index; i < Length - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }
        }

        private void increaseArray()
        {
            int newSize;
            if (_arr.Length == 0)
            {
                newSize = START_ARRAY_SIZE;
            }
            else
            {
                newSize = _arr.Length + (_arr.Length / 2);
            }

            T[] newArray = new T[newSize];

            for (int i = 0; i < _arr.Length; i++)
            {
                newArray[i] = _arr[i];
            }

            _arr = newArray;
        }
    }
}
