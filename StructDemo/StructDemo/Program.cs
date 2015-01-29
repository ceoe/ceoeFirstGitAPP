using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo
{
    
    
    public enum Month
    {
        //一月, 二月, 三月, 四月, 五月, 六月, 七月, 八月, 九月, 十月, 十一月, 十二月
        January, February, March, April, May, June, July, August, September, October, November, December
    };

    
    //结构体是值类型的集合，保存在stack 堆栈中， 类体是引用类型，保存在堆中，是引用类型。
    struct  Time
    {
        //定义字段，小时，分钟，秒数
        private int _hours, _minutes, _seconds;

        //定义构造方法重载函数
        public Time(int hh,int mm, int ss)
        {
            _hours = hh;
            _minutes = mm;
            _seconds = ss;

        }
        //定义构造方法重载函数
        public Time(int hh, int mm)
        {
            _hours = hh;
            _minutes = mm;
            _seconds = 0;

        }


        public int Hours()
        {
            return _hours;

        }
    }

    internal struct Date
    {
        //定义字段
        private int year, day;
       
        private Month month;



        //定义构造函数  结构体的所有字段必须在构造函数中初始化
        public Date(int yy,Month mm,int dd)
        {
            this.year = yy - 1900;
            this.month = mm;
            this.day = dd - 1;
        }

        //重写了Tostring方法，得到了一串处理过后的格式字符串
        public override string ToString()
        {

            string data = string.Format("Month {0}   Day {1}    Year-{2}", this.month, this.day + 1, this.year);
            return data;
        }

        public void AdvanceMonth()
        {
            this.month++;
            if (this.month==Month.December+1)
            {
                this.month = Month.January;
                this.year++;
                    
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            /*
            Time  tt=new Time();

            Console.WriteLine(tt.Hours());

            Time  t2=new Time(12,22,30);
            Console.WriteLine(t2.Hours());


            Time t3 = new Time(10, 25);
            Console.WriteLine(t3.Hours());
                     */

            Date  dd1=new Date(1997,Month.December,23);
            Console.WriteLine(dd1);

            Date dd2 =dd1;
            Console.WriteLine(dd2);

            dd2.AdvanceMonth();
            Console.WriteLine(dd2);
            Console.WriteLine(dd1);


    




            Console.ReadKey();
        }
    }
}
