using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartObserverDemo1
{
    //定义 委托类 及行参
    public delegate string ProcessDelegate(string t1,string t2);



    public   class  Test1
    {
        // 定义方法，参数中包含一个委托类型
        public string Processs(string s1,string s2, ProcessDelegate  process)
        {
            //当一个方法使用委托类型对象作为参数，并在方法中调用这个委托变量并且委托变量也调用主方法的参数，那么该方法 称之为回调函数
            //将一个方法以参数的形式传递给另外一个方法去执行。 ------称 为回调函数。

            return process(s1,s2);
        }

        public string process1(string s1,string s2)
        {
            return s1 + s2;

        }

        public string process2(string s1, string s2)
        {
            return s1 +Environment.NewLine+ s2;

        }

        public string process3(string s1, string s2)
        {
            return s2 + s1;

        }


    }

   
    class  Program
    {
        static void Main(string[] args)
        {
             Test1  t=new Test1();

            //new出委托变量，并传递到Process方法中
            string r1 = t.Processs("Hello!", "World .", new ProcessDelegate(t.process1));

            string r2 = t.Processs("Hello!", "World .", new ProcessDelegate(t.process2));

            string r3= t.Processs("Hello!", "World .", new ProcessDelegate(t.process3));

            Console.WriteLine(r1);

            Console.WriteLine("");

            Console.WriteLine(r2);

            Console.WriteLine("");

            Console.WriteLine(r3);

            Console.ReadKey();
        }

    }

    



}
