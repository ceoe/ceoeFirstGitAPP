using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mulitdelegatedemotest1
{
    // 定义代理类
    public delegate void SayMorning(string name);
    
    class Demo2
    {
        //定义将要被代理 方法 1，方法返回值和参数与代理类中保持一致。
        private static void EnglishGreeting(string name)
        {
                Console.WriteLine("Good morning!" + name) ;
        }

        //定义将要被代理 方法 2，方法返回值和参数与代理类中保持一致。
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好！" + name);
        }

        //定义一个方法， 传递参数进去，其中一个为代理类 类型
        private static void GreetingPeople(string name,SayMorning  sayMorning)
        {
           //直接用代理类 变量 + 参数执行
            sayMorning(name);
        }

        static void Main(string[] args)
        {
            GreetingPeople("Jim Zhang",EnglishGreeting);
            GreetingPeople("张先生",ChineseGreeting);


            Console.ReadKey();


        }


    }
}