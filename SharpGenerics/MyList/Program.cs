using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> nums = new MyList<int>();
            nums.Add(3);
            nums.Add(4);
            nums.Add(6);
            nums.Add(2);
            nums.Add(7);

            int[] arr = nums.GetArray();

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }

       
    }
}
