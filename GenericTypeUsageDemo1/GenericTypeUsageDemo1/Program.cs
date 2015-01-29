using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeUsageDemo1
{
    class  Genericclass1<T>
    {
        public T merber1;

        public Genericclass1<T> Merber2 = null;

        public Genericclass1(T x)
        {
            this.merber1 = x;
            Merber2 = this;
        }



    }

   

    class Program
    {
        static void Main(string[] args)
        {
            Genericclass1<string>  exam1=new Genericclass1<string>("This is a String\n");
            Console.WriteLine(exam1.merber1);
            Console.WriteLine(exam1.Merber2.merber1);

            Console.ReadKey();

        }
    }
}
