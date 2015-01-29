using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUsageDemo2
{
     delegate int weituo(string sa);
    
    class Subscriber
    {
       
        public  int Dosomething(string msg)
        {
            Console.WriteLine(msg);
            return msg.Length;
        }

        
    }

    class MyClass
    {
        public void PrintMsg(weituo kk)
        {
            kk("++++++++++++++++++++++++++++++++++++");
            kk("                    使用委托输出的内容!");
            kk("++++++++++++++++++++++++++++++++++++");
        }
    }

   class Program
    {
        static void Main(string[] args)
        {
            Subscriber mm = new Subscriber();
             weituo aa=new weituo(mm.Dosomething);

            string s = "调用委托实例";
            int k = mm.Dosomething(s);

            MyClass myclass=new MyClass();

            myclass.PrintMsg(aa);

            Console.ReadKey();
        }
    }
}
