using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannotowner
{
    class Program
    {
        static void Main(string[] args)
        {
             Hanno(6,'A','B','C');
            Console.ReadKey();

        }

        private static void Hanno(int num,char x,char y,char z)
        {
            if (num==0)
            {
                
            }
            else
            {
                    Hanno(num-1,x,z,y);
                Console.Write("{0} --> {1}   ",x,y);
                Hanno(num-1,z,y,x);
            }

        }
    }
}
