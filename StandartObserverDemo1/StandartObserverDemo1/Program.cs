//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StandartObserverDemo1
//{ 
//    //符合.Net Framework的代理及事件的编码规范：
//    // 代理类型的名称都应该以~EventHandle作为后缀名
//    //代理原型定义   返回值为void , 接收两个输入参数（object类型, EventArgs类型 /继承自EventArgs类型）；
//    // 事件的命名方法为 去掉 ~EventHandle作为后缀名, 并以~Event作为后缀名
//    // 事件定义形式为：  访问修饰符  event  代理类名  事件名

//    public class Heater
//    {
//        private int Temperature;

//        public delegate void BoilHandler(int parm);

//        public event BoilHandler BoilEvent;

//        public void BoilWater()
//        {

//            for (int i = 0; i < 100; i++)
//            {
//                Temperature = i;

//                if (Temperature>95)
//                {
//                    if (BoilEvent!=null)
//                    {
//                        BoilEvent(Temperature);
//                    }
//                }
//            }

//        }




//    }

//    public class Alarm
//    {
//        //实例方法
//        public void MakeAlarm(int parm)
//        {
//            Console.WriteLine("Alarm: 滴滴滴， 水温已经达到{0}度了！", parm);
//        }
//    }

//    public class Display
//    {
//        //类的静态方法
//        public static void ShowMsg(int parm)
//        {
//            Console.WriteLine("Display: 水烧开了，当前温度为：{0} 度。", parm);
//        }

//    }

//    class Program
//    {
//        static void Main1(string[] args)
//        {
//            Heater heater=new Heater();
//            //Alarm中的MakeAlarm属于实例方法，所以要实例化一个Alarm对象后才能被使用。
//            Alarm alarm=new Alarm();

//            heater.BoilEvent += null;
//            heater.BoilEvent += alarm.MakeAlarm;
//            //showmsg属于静态方法，所以Display类不需要实例化即可赋值给BoilEvent事件。
//            heater.BoilEvent += Display.ShowMsg;

//            heater.BoilWater();
//            Console.ReadKey();
//        }
//    }
//}
