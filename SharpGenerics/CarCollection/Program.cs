using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("ferrari", 1993);
            Car car2 = new Car("ford", 1994);
            Car car3 = new Car("fiat", 1990);
            Car car4 = new Car("dacha", 1999);

            CarCollection<Car> carCollection = new CarCollection<Car>();
            carCollection.Add(car1);
            carCollection.Add(car2);
            carCollection.Add(car3);
            carCollection.Add(car4);
            carCollection.Add("lada", 2003);
            Truck truck = new Truck("cybertruck", 2021, 300);
            carCollection.Add(truck);
        }
    }
}
