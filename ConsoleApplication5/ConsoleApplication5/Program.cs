using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversionsApp
{
    class Fruit
    {

    }

    class Apple : Fruit
    {
        public int I = 1;
    }

    class Conversions
    {
        static void Main(string[] args)
        {
            
            Fruit  a=new Apple();

            Apple b=new Apple();

               Console.WriteLine("Apple b Type is :  "+b.GetType().ToString());
               Console.WriteLine("Fruit   a Type is :  "+a.GetType().ToString());

            Apple c = a as Apple;
            if (c!=null)
            {
                Console.WriteLine(c.I);
            }

            Apple d = new Apple();
            if (a is Apple)
            {
                d = (Apple) a;
                Console.WriteLine(d.I);
            }


            Console.ReadKey();

        }
    }
}
