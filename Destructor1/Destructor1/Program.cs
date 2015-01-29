using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor1
{
    internal class MyResource : IDisposable
    {
        public MyResource()
        {
        }

        private bool disposed = false;

        //关闭和解析方法都为public , 实际上是调用private Dispose (bool) 的方法.
        public void Dispose()
        {
            Dispose(true);
        }

        public void Close()
        {
            Dispose(true);
        }

        ~MyResource()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            //该执行一次,就会不受限制反复的对Disposed置为true, 这个有些问题
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Disposing 为真,不但需要做析构当前对象调用的非托管资源, 并且要阻止垃圾自动回收 由此提高程序性能.
                    Console.WriteLine("Dispose重载函数形参为True时,执行被类对象引用的其他非托管对象的析构方法!");
                    GC.SuppressFinalize(this);

                }
                Console.WriteLine("析构类本身所使用的非托管资源.");

                //反复的对Disposed置为true, 这个有
                disposed = true;
            }
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {

            #region 普通的做法tryf
            MyResource mr = new MyResource();

            try
            {
                Console.WriteLine("对象执行一些方法及过程,在try中.");
            }
            finally
            {
                mr.Close();
            }
            
            #endregion

            Console.WriteLine("\r\n#################################################\r\n");

            using ( MyResource mb = new MyResource())
            {
                Console.WriteLine("对象执行一些方法及过程,在using中.");
            }

            Console.WriteLine("\r\n#################################################\r\n");


            MyResource mc = new MyResource();
            
                Console.WriteLine("mc对象执行一些方法及过程");
            

            Console.WriteLine("\r\n#################################################\r\n");

            
        }



    }

}
