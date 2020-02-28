using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCollection
{
    class Truck : Car
    {
        public int WeightCarried { get; private set; }

        public Truck(string carName, int yearOfIssue, int weightCarried) 
            : base(carName, yearOfIssue)
        {
            WeightCarried = weightCarried;
        }


        public void Foo()
        {
            //something foooo
        }

        public override string ToString()
        {
            return String.Concat( base.ToString(), String.Format("WeightCarried: {0}", WeightCarried));
        }
    }
}
