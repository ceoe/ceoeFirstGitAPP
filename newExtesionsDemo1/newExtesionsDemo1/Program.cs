using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace newExtesionsDemo1
{
    class Program
    {
     
             static  void Dowork()
            {
                int x= 54678;
                for (int i = 2; i <11; i++)
                {
                    
                    Console.WriteLine("{0}  的 {1}进制 表示方法是：{2}",x.ToString(), i.ToString(),x.ConverttoBase(i));

                }

            }

        static void Main(string[] args)
        {

            try
            {
                Dowork();
            }
            catch (ArgumentException ex  )
            {
                    
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }


    
    }
}
