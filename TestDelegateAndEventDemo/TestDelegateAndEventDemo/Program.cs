using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDelegateAndEventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb=new Publisher();
            var sb=new SubScriber();

            pb.OnSomethingDelegate+=new MakeDelegate(sb.OnForSubcriberDo);
            pb.Count = 100;
            pb.Str = "Publsiher的数据";

            pb.DoingSomthing();
            pb.OnSomethingDelegate("在主程序中直接调用",200);
        }
    }

    public delegate void MakeDelegate(string str,int count);

    public class Publisher
    {
        public string Str { get; set; }
        public int Count;
        public MakeDelegate OnSomethingDelegate;
       // public event MakeDelegate OnSomethingDelegate;

        public void DoingSomthing()
        {
            if (OnSomethingDelegate!=null)
            {
                Count++;
                OnSomethingDelegate(this.Str,Count);
            }
        }
    }

    public class SubScriber
    {
        public void OnForSubcriberDo(string str, int  count)
        {
            Console.WriteLine("订阅者已经执行这个动作：{0}++++计数为：{1}",str,count);
            Console.ReadKey();
        }
    }
}
