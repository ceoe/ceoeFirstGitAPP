using System;
using ConsoleApplication3;

namespace ConsoleApplication3
{
    public class DiffrentCamera
    {
        public void Initial()
        {
            Console.WriteLine("初始化--方法被调用了！");


        }

        public void MoveToPosition()
        {
            Console.WriteLine("移动到指定点--方法被调用了！");


        }


        public void StartGrab()
        {
            Console.WriteLine("开始采集--方法被调用了！");


        }

        public void StopGrab()
        {
            Console.WriteLine("停止采集-方法被调用了！");


        }

        public void DisplayFrame()
        {
            Console.WriteLine("显示一帧-方法被调用了！");


        }

         public virtual void ReportTypeofCamera()
         {
         }
    }

    


    internal class LineCamera : DiffrentCamera
    {
        public override void ReportTypeofCamera()
        {
            {
                Console.WriteLine("线阵相机步骤执行完成！");
            }
        }
    }


  internal class AreaCamera : DiffrentCamera
    {
        public override void ReportTypeofCamera()
        {
            {
                Console.WriteLine("面阵相机步骤执行完成！");
            }
        }
    }

    public class Dowork
    {

        public Dowork()
        {
        }

        public Dowork(DiffrentCamera i)
        {
            i.Initial();
            i.MoveToPosition();
            i.StartGrab();
            i.StopGrab();
            i.DisplayFrame();
            i.ReportTypeofCamera();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DiffrentCamera  Linecamera=new LineCamera();
            DiffrentCamera  Areacamera=new AreaCamera();
            Dowork  dowork1=new Dowork(Linecamera);
// ReSharper disable SuggestUseVarKeywordEvident

            Console.WriteLine("////////////////////////////////////////////////////////////////");
            Console.WriteLine("");
            Dowork dowork2 = new Dowork(Areacamera);
// ReSharper restore SuggestUseVarKeywordEvident

            Console.WriteLine("////////////////////////////////////////////////////////////////");
            Console.WriteLine("");

            Console.ReadKey();
        }

      
    }


}
