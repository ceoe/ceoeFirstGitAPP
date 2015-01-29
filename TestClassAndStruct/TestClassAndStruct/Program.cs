using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClassAndStruct
{
    public class MyClass
    {
        public string name;
        public int Height;

    }

    public struct Mystruct
    {
        public  string name;
        public  int age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass[] myclass = new MyClass[3];
            myclass[0] = new MyClass();
            myclass[1] = new MyClass(); 
            myclass[2] = new MyClass();

            foreach (MyClass aa in myclass)
            {
                Console.WriteLine("Name is :  " + aa.name + "       Height is :  " + aa.Height.ToString());
            }


            Mystruct[] ms = new Mystruct[3];
            Console.WriteLine("*****************************************************************************");
            foreach (Mystruct aa in ms)
            {
                Console.WriteLine("Name is :  " + aa.name + "       Height is :  " + aa.age.ToString());
            }

            Console.ReadKey();

        }
    }
}
