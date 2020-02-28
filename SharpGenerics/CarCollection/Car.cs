using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCollection
{
    class Car
    {
        public string CarName { get; private set; }
        public int YearOfIssue { get; private set; }

        public Car(string carName, int yearOfIssue)
        {
            CarName = carName;
            YearOfIssue = yearOfIssue;
        }

        public override string ToString()
        {
            return String.Format("Car name: {0}/nYearOfIssue: {1}/n", CarName, YearOfIssue);

        }
    }
}
