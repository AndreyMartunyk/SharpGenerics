﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class MyList<T>
    {
        public int Length { get; private set; }

        private const int START_ARRAY_SIZE = 10;
        private T[] _arr;

        public MyList(int startArraySize = START_ARRAY_SIZE)
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

        public bool TryDelete(T elem)
        {
            //медот удаляющий элемент
            //если такого нет, возвращает false
            //если есть удаляем, затем смещаем массив, затем уменьшаем переменную Length
            bool success = false;
            int deletingItemIndex = -1;

            for (int i = 0; i < Length; i++)
            {
                if(_arr[i].Equals(elem))
                {
                    deletingItemIndex = i;
                    success = true;
                    break;
                }
            }

            if (success)
            {
                displaceArray(deletingItemIndex);
                --Length;
            }

            return success;
        }
        public T this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _arr[index];
            }
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
