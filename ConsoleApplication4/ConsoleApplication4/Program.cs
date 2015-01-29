using System;

namespace ConsoleApplication4
{
    public interface ICapture
    {
        void Initial();

        void StartGrab();

        void StopGrab();

        void DisplayFrame();


        void ReportTypeofCamera();
    }

    public abstract class DifferentCamera:ICapture
    {

        public  virtual  void Initial()
        {
         }

      
        public  virtual void StartGrab()
        {
            }

        public  virtual  void StopGrab()
        {
          

        }

        public virtual void DisplayFrame()
        {
           
        }

        
        
        public  virtual void ReportTypeofCamera()
        {
        }

        
    }


    class LineCamera:DifferentCamera
    {
        public   override void Initial()
        {
            Console.WriteLine("Line Camera 初始化--方法被调用了！");


        }

      
        public override void StartGrab()
        {
            Console.WriteLine("Line Camera 开始采集--方法被调用了！");


        }

        public override void StopGrab()
        {
            Console.WriteLine("Line Camera 停止采集-方法被调用了！");


        }

        public override void DisplayFrame()
        {
            Console.WriteLine("Line Camera 显示一帧-方法被调用了！");


        }




        public override void ReportTypeofCamera()
        {
            Console.WriteLine("Line Scan Camera is Active !");
        }

    }

    class AreaCamera : DifferentCamera
    {
        public   override void Initial()
        {
            Console.WriteLine("Area Camera 初始化--方法被调用了！");


        }

      
        public override void StartGrab()
        {
            Console.WriteLine("Area Camera 开始采集--方法被调用了！");


        }

        public override void StopGrab()
        {
            Console.WriteLine("Area Camera 停止采集-方法被调用了！");


        }

        public override void DisplayFrame()
        {
            Console.WriteLine("Area Camera 显示一帧-方法被调用了！");


        }



        public override void ReportTypeofCamera()
        {
            Console.WriteLine("Area Scan Camera is Active !");
        }

    }


    public class Dowork
    {
        public Dowork(DifferentCamera i)
        {
            i.Initial();
            i.StartGrab();
            i.StopGrab();
            i.DisplayFrame();
            i.ReportTypeofCamera();
        }
    }

    
    class Program
    {
        static void Main()
        {
           AreaCamera  aa=new AreaCamera();
            ICapture capture = aa;
    
            capture.Initial();
            capture.StartGrab();
            capture.StopGrab();
            capture.DisplayFrame();
            capture .ReportTypeofCamera();

            Console .WriteLine("/////////////////////////////////////////////////////////////////");
            Console .WriteLine();

            capture=new LineCamera();

            capture.Initial();
            capture.StartGrab();
            capture.StopGrab();
            capture.DisplayFrame();
            capture.ReportTypeofCamera();



            //Dowork   work=new Dowork(new AreaCamera());


            //Dowork work2 = new Dowork(new LineCamera());


            Console.ReadKey();

        }
    }
}
