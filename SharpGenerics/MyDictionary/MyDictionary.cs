using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    class MyDictionary<TKey, TValue>
    {
        public int Length { get; private set; }

        private const int START_ARRAY_SIZE = 10;
        private KeyValue[] _arr;


        public MyDictionary(int startArraySize = START_ARRAY_SIZE)
        {
            if (startArraySize < 0)
            {
                startArraySize = START_ARRAY_SIZE;
            }

            _arr = new KeyValue[startArraySize];
            Length = 0;
        }

        public bool Add(TKey key, TValue value)
        {
            bool isCollised = false;

            if (_arr.Length <= Length)
            {
                increaseArray();
            }

            for (int i = 0; i < Length; i++)
            {
                if (_arr[i].key.Equals(key))
                {
                    isCollised = true;
                    break;
                }
            }

            if (!isCollised)
            {
                _arr[Length] = new KeyValue { key = key, value = value };
                ++Length;
            }

            return isCollised;
        }

        public bool TryDelete(TKey key)
        {
            //медот удаляющий элемент
            //если такого нет, возвращает false
            //если есть удаляем, затем смещаем массив, затем уменьшаем переменную Length
            bool success = false;
            int deletingItemIndex = -1;

            for (int i = 0; i < Length; i++)
            {
                if (_arr[i].key.Equals(key))
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

        

        public TValue this[TKey key]
        {
            get
            {
                return GetValue(key);
            }
        }
        
        public void GetElemByIndex(int index, out TKey key, out TValue value)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            key = _arr[index].key;
            value = _arr[index].value;
        }

        public TValue GetValue(TKey key)
        {

            for (int i = 0; i < Length; i++)
            {
                if (_arr[i].key.Equals(key))
                {
                    return _arr[i].value;
                }
            }

            return default(TValue);
        }

        public void ClearArray()
        {
            _arr = new KeyValue[START_ARRAY_SIZE];
            Length = 0;
        }

        public void Trim()
        {
            if (_arr.Length == Length)
            {
                return;
            }

            KeyValue[] newArray = new KeyValue[Length];

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

            KeyValue[] newArray = new KeyValue[newSize];

            for (int i = 0; i < _arr.Length; i++)
            {
                newArray[i] = _arr[i];
            }

            _arr = newArray;
        }

        private struct KeyValue
        {
            public TKey key;
            public TValue value;

            public bool Equals(KeyValue obj)
            {
                if (!key.Equals(obj.key) || !value.Equals(obj.value))
                {
                    return false;
                }
                
                return true;
            }
        }
    }

}
