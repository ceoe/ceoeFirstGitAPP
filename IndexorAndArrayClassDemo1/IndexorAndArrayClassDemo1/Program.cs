using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexorAndArrayClassDemo1
{
    internal class WeekDay
    {
        private string[] day = {"Sun","Mon","Tue","Wed","Thr","Fri","Sat"};
        public string this[int i ]
        {
            get
            {
                if (i>=0&&i<=day.Length-1)
                {
                    return day[i];
                }
                else
                {
                    return "";
                }
                   
            }
            set { day[i] = value; }
        }

        public WeekDay()
        {
            
        }

        public int Daycount
        {
            get { return day.Length; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            WeekDay[] YearWeek=new WeekDay[5];
            for (int i = 0; i < YearWeek.Length; i++)
            {
                YearWeek[i]=new WeekDay();
            }

            for (int i = 0; i < YearWeek.Length; i++)
            {
                Console.WriteLine("This is {0} Week: ",i+1);
                for (int j = 0; j < YearWeek[i].Daycount; j++)
                {
                    Console.Write(YearWeek[i][j]+"      ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
