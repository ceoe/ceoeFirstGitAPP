using System;
using System.Collections.Generic;

namespace TestDelegateAndEventDemo
{
    public  class TesttrycatchEventHandle
    {
         static void Main(string[] args)
        {
            var pb = new Publisher1();
            var sb1 = new SubScriber1();
             var sb2 = new SubScriber2();
             var sb3 = new SubScriber3();

             pb.OnSomethingDelegate +=sb1.OnForSubcriberDo;
            pb.OnSomethingDelegate += sb2.OnForSubcriberDo;
             pb.OnSomethingDelegate +=sb3.OnForSubcriberDo;
             //pb.OnSomethingDelegate += sb1.OnForSubcriberDo;


            pb.Count = 101;
            pb.Str = "Publsiher的数据";

            pb.CheckAndTrigger();
          //  pb.OnSomethingDelegate("在主程序中直接调用", 200);
        }
    }

    public delegate void MakeDelegateEventHandle(object sender, Publisher1.TransferParamEventArgs  args);

    public class Publisher1
    {
        #region 成员字段 发布者的一些字段，其中有订阅者所关心的信息
        public string Str { get; set; }

        public int Count;
        #endregion
       

        //定义一个event 事件代理变量 OnsomethingDelegate
        //public MakeDelegate1 OnSomethingDelegate;
        public event MakeDelegateEventHandle  OnSomethingDelegate;

        #region 定义一个内部类继承自 EventArgs 基类，以便封装一些信息在里面，并且符合.NET FrameWork对事件定义及使用的规则
        public class TransferParamEventArgs : EventArgs
        {
            //这里又要定义2个成员字段，以便于订阅者能够通过EventArgs访问到发布者的一些数据，应该就是数据的拷贝
            public readonly string str;
            public readonly int count;
            //EventArgs 构造函数，实例化的时候必须让内部的2个只读成员字段赋值。
            public TransferParamEventArgs(string str, int count)
            {
                this.str = str;
                this.count = count;
            }
        }
        
        #endregion

        #region 检查触发条件，满足条件即触发
        public void CheckAndTrigger()
        {
            //CHECKD SOME THINGS TO Trigger   to do:

            //条件满足后即要准备出发，所有订阅者需要的数据信息必须提前准备好，所以这一句就是准备EventArgs实例并赋值进行构造，以便main方法中读取使用。
            var tpArgs = new TransferParamEventArgs(this.Str, this.Count);

            //使用下面的方法，传递已经提前初始化好的EventArgs子类对象 给到Dodelgatethings 方法去执行标准化的Event调用。
           
                Dodelegatethings(tpArgs);
           

        }
        
        #endregion
       

        #region 定义一个虚方法，专门执行标准化调用各个绑定的方法
        protected virtual void Dodelegatethings(TransferParamEventArgs args)
        {
            if (OnSomethingDelegate != null)
            {
                Delegate[] delArray = OnSomethingDelegate.GetInvocationList();
                List<object> listobj=new List<object>();

               foreach (var del in delArray)
                {
                    //MakeDelegateEventHandle handleEventMothed = del as MakeDelegateEventHandle;
                    try
                    {
                       object obj= del.DynamicInvoke(this, args);
                        if (obj!=null)
                        {
                            listobj.Add(obj);
                        }
                    }
                    catch (Exception  e)
                    {
                        Console.WriteLine("Exception: {0}",e.Message);
                    }
                }
            }
        }
        #endregion
       
    }

    public class SubScriber1
    {
        public void OnForSubcriberDo(object sender, Publisher1.TransferParamEventArgs  args)
        {
            Publisher1 pb11 = sender as Publisher1;
            Console.WriteLine("1号订阅者已经执行这个动作：{0}++++计数为：{1}",args.str, args.count);
            Console.WriteLine("1号订阅者已经执行这个动作：{0}++++计数为：{1}", pb11.Str, pb11.Count);
            Console.ReadKey();
        }
    }

    public class SubScriber2
    {
        public void OnForSubcriberDo(object sender, Publisher1.TransferParamEventArgs args)
        {
            throw new Exception("2号订阅者已经抛出异常！！！！！！！！");
            //Console.WriteLine("2号订阅者已经执行这个动作：{0}++++计数为：{1}", str, count);
            //Console.ReadKey();
        }
    }

    public class SubScriber3
    {
        public void OnForSubcriberDo(object sender, Publisher1.TransferParamEventArgs args)
        {
            Console.WriteLine("3号订阅者已经执行这个动作：{0}++++计数为：{1}", args.str, args.count);
            Console.ReadKey();
        }
    }
}