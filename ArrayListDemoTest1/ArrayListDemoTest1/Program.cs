using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListDemoTest1
{
    class Program
    {
        static void Main(string[] args)
        {
           // ArrayListTest();

            //QueueDemoTest();

            HashTableDemoTest();
        }

        private static void HashTableDemoTest()
        {

            Hashtable   hst=new Hashtable();
            hst["aa"] = "23";
            hst["bb"] = "24";
            hst["cc"] = "25";
            hst["dd"] = "26";
            hst["ee"] = "27";
            hst["ff"] = "28";

            Console.WriteLine("The aa key  Value is "+ hst["aa"]);

            Console.WriteLine(hst.Count);
            foreach (DictionaryEntry test1 in hst)
            {
                 Console.WriteLine("Key is {0}, value is {1}.",  test1.Key,test1.Value);

                
            }
            Console.ReadKey();

        }


        private static void QueueDemoTest()
        {
            Queue number = new Queue();

            foreach (int temp in new int[7] { 22, 34, 56, 62, 68, 71, 83, })
            {
                number.Enqueue(temp);

            }

            Console.WriteLine("Queue number count is {0}", number.Count);

            number.Enqueue("aaa");

            Console.WriteLine("Now the Queue number count is {0}", number.Count);

            while (number.Count>0)
            {
                Console.WriteLine(Convert.ToString(number.Dequeue()) + "     Has left the Queue!");

                Console.WriteLine(number.Count);
            }

            Console.ReadKey();


        }

        private static void ArrayListTest()
        {
            ArrayList  number=new ArrayList();

            foreach (int  temp in new int[7] {22, 34, 56, 62, 68, 71, 83,})
            {
                number.Add(temp);

            }

            Console.WriteLine("number count is {0}",number.Count);

            number.Insert(number.Count-2, "aaa");

            foreach (var temp in number)
            {
                Console.WriteLine(Convert.ToString(temp));
            }

            Console.WriteLine("Now the number count is {0}", number.Count);


            Console.ReadKey();





        }
    }
}
