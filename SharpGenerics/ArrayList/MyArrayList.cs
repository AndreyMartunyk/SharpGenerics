using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class MyArrayList
    {

        public int Count { get; private set; }

        private const int START_ARRAY_SIZE = 10;
        private object[] arr;

        public MyArrayList(int startArraySize = START_ARRAY_SIZE)
        {
            if (startArraySize < 0)
            {
                startArraySize = START_ARRAY_SIZE;
            }

            arr = new object[startArraySize];
            Count = 0;
        }

        public int Add(object item)
        {
            if (arr.Length <= Count)
            {
                increaseArray();
            }
            arr[Count] = item;
            ++Count;
            
            return Count - 1;
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    return null;
                }
                return arr[index];
            }
        }

        private void increaseArray()
        {
            int newSize;
            if (arr.Length == 0)
            {
                newSize = START_ARRAY_SIZE;
            }
            else
            {
                newSize = arr.Length + (arr.Length / 2);
            }

            object[] newArray = new object[newSize];

            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = arr[i];
            }

            arr = newArray;
        }

        public void Clear()
        {
            arr = new object[START_ARRAY_SIZE];
            Count = 0;
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public MyArrayList GetRange(int index, int count)
        {
            if (count > Count || index < 0 || index >= Count)
            {
                return null;
            }

            if (index + count >= Count)
            {
                return null;
            }

            MyArrayList result = new MyArrayList();

            for (int i = index; i < count; i++)
            {
                result.Add(arr[i]);
            }

            return result;
        }

        public int IndexOf(object value)
        {
            int res = -1;

            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(value))
                {
                    res = i;
                    break;
                }
            }

            return res;
        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index >= Count)
            {
                return;
            }

            arr[index] = value;
        }

        public int LastIndexOf(object value)
        {
            int res = -1;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (arr[i].Equals(value))
                {
                    res = i;
                    break;
                }
            }

            return res;
        }

        public void Remove(object value)
        {
            int deletingItemIndex = IndexOf(value);

            if (deletingItemIndex >= 0)
            {
                RemoveAt(deletingItemIndex);
                --Count;
            }

        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
        }

        public void RemoveRange(int index, int count)
        {
            if (count > Count || index < 0 || index >= Count)
            {
                return;
            }

            if (index + count >= Count)
            {
                return;
            }

            for (int i = index; i < count; i++)
            {
                RemoveAt(i); 
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                object temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }
        }


    }
}
