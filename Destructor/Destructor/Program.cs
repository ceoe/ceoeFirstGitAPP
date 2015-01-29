using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    internal class A
    {

        public A()
        {
            Console.WriteLine("A类的实例被创建");
        }

        ~A()
        {
            Console.WriteLine("A类的实例被回收");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            for (string i = ""; (i != "end"); i=Console.ReadLine().ToString() )
            {
                new A();
                for (int j = 0; j < 100; j++)
                {
                    byte []  ba =new byte[1000];
                }
            }
            
            //GC.Collect();
           
            //new A();

        }
    }
}
