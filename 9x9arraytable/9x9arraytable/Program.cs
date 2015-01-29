using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9x9arraytable
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int k = 1; k < 10; k++)
            {
                for (int l = k; l < 10; l++)
                {
                    Console.Write("    {0} * {1}={2}", k, l, k * l);
                }
                Console.WriteLine("\n");            
            }
            Console.ReadKey();

        }

       
    }
}
