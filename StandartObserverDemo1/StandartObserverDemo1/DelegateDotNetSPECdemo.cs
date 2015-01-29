using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartObserverDemo1
{

    public class Heater
    {
       
        private int temperture;
        public string model = " AO SMITH 01";
        public string mfArea = "Shanghai  China";

        //声明代理，并使用.net framwork规范， 代理类名+ EventHandler结尾，带上参数（ object  sender ， 代理类名+EventArgs  e）
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs e);

        // 定义代理变量 = 声明事件  public event  代理类名+ EventHandler结尾    代理变量名Event（= 事件名Event）
        public event BoiledEventHandler BoiledEvent;

        //定义BoiledEventArgs 类，传递OBserver所感兴趣的内容
        public  class  BoiledEventArgs:EventArgs
        {
            public readonly int Temperture;
            //BoiledEventArgs构造函数传入
            public BoiledEventArgs(int parm)
            {
                this.Temperture = parm;
            }
        }

        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (BoiledEvent != null)
            {
                BoiledEvent(this, e);
            }
        }

        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperture = i;
                if (temperture > 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(temperture);
                    OnBoiled(e);
                }
            }
        }

    }

    public class Alarm
    {
        public void MakeAlarm(Object sender,Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater) sender;
            
            Console.WriteLine("Alarm: {0}---{1}",heater.model,heater.mfArea);

            Console.WriteLine("Alarm: 滴滴滴，水温已经达到{0}度了！",e.Temperture);
            Console.WriteLine();
        }
    }

    public class Display
    {
        public static  void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;

            Console.WriteLine("Display: {0}---{1}", heater.model, heater.mfArea);

            Console.WriteLine("Display: 水烧开了，水温已经达到{0}度了！", e.Temperture);
            Console.WriteLine();
        }
    }



    class DelegateDotNetSPECdemo
    {
       // private static void Main(string[] args)
       // {
       //     Heater  heater=new Heater();
       //     Alarm  alarm=new Alarm();

       //     heater.BoiledEvent += null;
       //     heater.BoiledEvent += alarm.MakeAlarm;
       //     heater.BoiledEvent += Display.ShowMsg;

       //     heater.BoilWater();

       //     Console.ReadKey();
       //}

    }
}
