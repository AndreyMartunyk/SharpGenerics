using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGenerics
{
    class Program
    {
        // 1)Создайте класс MyClass<T>, содержащий статический фабричный метод - T FacrotyMethod(), который
        //будет порождать экземпляры типа, указанного в качестве параметра типа(указателя места заполнения типом –
        //Т).
        static void Main(string[] args)
        {
            Foo foo = MyClass<Foo>.FactoryMethod();
        }
    }

    class Foo
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class MyClass<T> where T:new()
    {
        public static T FactoryMethod()
        {
            return new T();
        }
    }
}
