using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
 
namespace RegulatorExpressionDemo1
{
    class Program
    {
        static void Main(string[] args)
        {

         Demotest4();
            

        }

        public static void Demotest1()
        {
            string str = "15300001121";
            Regex rg = new Regex(@"1[358]\d{9}");

            Boolean result = rg.IsMatch(str);

            Console.WriteLine(str + ":" + result);
            Console.ReadKey();

        }

        public static void Demotest2()
        {
            string str = "X123456Y334354X5556Y7778";
            Regex rg = new Regex(@"[XxyY]");
            

            //rg=new Regex(@"[XxYy]");
            string[] str2 = rg.Split(str);

            foreach (string s in str2)
            {
                Console.WriteLine(s);  
            }

            
            Console.ReadKey(); 

        }

        public static void Demotest3()
        {
            string str = "zhangsantttttwangzhiskkkkkkzhaowu";
            Regex rg = new Regex(@"[XY]\d+[XY]\d+");


            rg = new Regex(@"(.)\1+");
            string[] str2 = rg.Split(str);

            foreach (string s in str2)
            {
                Console.WriteLine(s);
            }

           string str1 = rg.Replace(str, "$1");

            Console.WriteLine(str1);
            

            Console.ReadKey();

        }

        public static void Demotest4()
        {
            string str = "15800001111";
            Regex rg = new Regex(@"[XY]\d+[XY]\d+");


            rg = new Regex(@"(\d{3})\d{4}(\d{4})");
            string[] str2 = rg.Split(str);


            for (int i = 1; i < str2.Length-1; i++)
            {

                Console.WriteLine(str2[i]);
            }

            string str1 = rg.Replace(str, "$1****$2");

            Console.WriteLine(str1);


            Console.ReadKey();

        }
    }
}
