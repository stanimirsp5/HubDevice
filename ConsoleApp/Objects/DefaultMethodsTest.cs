using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Objects
{
    internal class DefaultMethodsTest
    {
        void MyMain()
        {

            String s = null;
            String s2 = "ww";
            s2 = s;
            Console.WriteLine(s2);

            var obj = new { test = 10, obj2 = new { obj3 = new { }, str = "string" } };


            var dog = new Dog();
            dog = default;
            Console.WriteLine(dog.Breed);
            dog.Breed = default;
            Console.WriteLine(dog.Breed);
        }
public class Dog
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public Breed Breed { get; set; }

        }
        public class Breed
        {
            public string Color { get; set; }
            public int HairLength { get; set; }
        }
    }
}
