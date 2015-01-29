using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArryDemoTest1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] pins = new int[4] {20,40,80,50};
            int[] alias = pins;

            var  arrayAbc =new [] {"hello","happy","john"};


            Console.WriteLine(arrayAbc.Length);
            Console.WriteLine();
            foreach (var kk in arrayAbc)
            {
                Console.WriteLine(kk);
            }
         

            foreach (int alia in alias)
            {
                Console .WriteLine(alia);


            }

            Console.WriteLine();

            int[] copy1 = new int[pins.Length];

            //方法1 ，用Array.Copy静态方法来建立复制
            Array.Copy(pins, copy1, pins.Length);
            //方法2，用Array的CopyTo方式来建立复制
            pins.CopyTo(copy1, 0);

           //方法3  用 Array的 Clone方法来建立复制。
            int[] copy2 = (int[]) pins.Clone();


            alias[3] = 100;

            foreach (int alia in alias)
            {
                Console.WriteLine(alia);


            }

            Console.WriteLine();

            foreach (int alia in pins)
            {
                Console.WriteLine(alia);


            }

            Console.WriteLine();

            var anyvarClass = new { Name = "Robot", Age = 20 };

            var othervarClass = new { Name = "Bob", Age = 22 };

            Console.WriteLine("Name is : {0} , Age is {1}",anyvarClass.Name,anyvarClass.Age);
            Console.WriteLine("Name is : {0} , Age is {1}", othervarClass.Name, othervarClass.Age);
            Console.WriteLine();
        
            foreach (var alia in copy2)
            {
                Console.WriteLine(alia);


            }




            Console.ReadKey();





        }
    }

  

}
