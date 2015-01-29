using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mulitdelegatedemotest1
{
    class Program
    {
        // 定义代理类
        //该方法定义一个int 参数  返回void 
        public delegate string Mydelegate();



        static void Main1(string[] args)
        {
            //声明代理变量
            Mydelegate ddStatic;
            Mydelegate ddInstance1;
            Mydelegate ddInstance2;

            //声明一个代理链 并赋值为 null
            Mydelegate ddchain=null;

            //使用静态方法来实例化一个代理变量  静态方法直接使用 new 委托类名（类.方法名）
            ddStatic=new Mydelegate(Program.method1);

            // 使用实例方法来实例化委托时， 格式必须如： new  委托类名 （new 类().方法名）
            ddInstance1 = new Mydelegate(new Program().method2);

            ddInstance2=new Mydelegate(new Program().method3);

            //使用 +=建立 委托链
            ddchain += ddStatic;
            ddchain += ddInstance1;
            ddchain += ddInstance2;

            // ddchain = (Mydelegate) Delegate.Combine(ddchain,ddInstance);


            Console.WriteLine(Test(ddchain));
            
            ////隐式调用委托
            //ddStatic();

            ////显式调用Invoke方法来调用委托
            //ddInstance.Invoke();

            ////隐式调用委托
            //ddStatic(2);

            ////显式调用Invoke方法来调用委托
            //ddInstance.Invoke(2);

            //Console.WriteLine("开始调用代理链输出：");

            //ddchain(1);

            //ddchain(2);

            Console.ReadKey();


        }

        private static string  method1()
        {
            return "调用了静态方法1 method1"; 

           // Console.WriteLine("调用的是静态方法，参数值为："+parm);
        
        }

        private string  method2()

        {
             throw new Exception("实例方法2 method2 抛出了一个异常");
            //Console.WriteLine("调用的是实例方法，参数值为：" + parm);
        }

        private string method3()
        {
            return "调用实例方法3 method3";
        }

        //定义了一个方法 调用了代理链变量
        private static string Test(Mydelegate ddchain)
        {
          // 代理链为空则直接返回为空

            if (ddchain == null)
            {
                return null;
            }

            // 用stringBuilder类 来建立一个可扩展的字符串变量 来存储一大串文本
            StringBuilder returnstring = new StringBuilder();

            // 将ddchain 代理链拆开分配给delegateArray数组  使用了代理链变量
            Delegate[] delegateArray = ddchain.GetInvocationList();

            //遍历delegateArray数组 
            foreach (Mydelegate tt in delegateArray)
            {
                //使用try catch结构捕获异常，
                try
                {
                   // 执行正常的文本串添加，并在每次执行的结尾加上 Environment.NewLine 静态字段
                    returnstring.Append(tt() + Environment.NewLine);
                }
                // 对于捕获到的异常
                catch (Exception e)
                {
                    //returnstring 仍然进行 添加字符串处理处理
                    returnstring.AppendFormat("异常从{0}方法中抛出，异常信息为：{1} {2}", tt.Method.Name, e.Message,
                                              Environment.NewLine);

                }
            }

            return returnstring.ToString();
        }

    }
}
