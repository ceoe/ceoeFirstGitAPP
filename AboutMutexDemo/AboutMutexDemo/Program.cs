using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AboutMutexDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Program p = new Program();
            p.RunThread();
            Console.ReadLine();
        }

        #region variable

        private Thread thread1 = null;
        private Thread thread2 = null;
        private Mutex mutex = null;

        #endregion

        public Program()
        {
            mutex = new Mutex();
            thread1 = new Thread(new ThreadStart(thread1Func));
            thread2 = new Thread(new ThreadStart(thread2Func));
        }

        public void RunThread()
        {
            thread1.Start();
            thread2.Start();
        }

        private void thread1Func()
        {
          
                for (int count = 0; count < 10; count++)
                {
                    lock (this)
                    {
                  //  mutex.WaitOne();
                    TestFunc("Thread1 have run " + count.ToString() + " times");
                    Thread.Sleep(30);
                  //  mutex.ReleaseMutex();
                } 
            }
           
        }

        private void thread2Func()
        {
            for (int count = 0; count < 10; count++)
            {
            lock (this)
            {
                
                    // mutex.WaitOne();
                    TestFunc("Thread2 have run " + count.ToString() + " times");
                    Thread.Sleep(100);
                    // mutex.ReleaseMutex();
                }
            }
         
        }

        private void TestFunc(string str)
        {

            //lock (this)
            //{
              
            //}
            Console.WriteLine("{0} {1}", str, System.DateTime.Now.Millisecond.ToString());
            Thread.Sleep(50);
  
        }

    }
}

