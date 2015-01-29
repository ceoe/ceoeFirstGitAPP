using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldUsageDemo1
{
    class WeekDay:System.Collections.IEnumerable
    {
         string []  day={"Sun","Mon","Tue","Wed","Thr","Fri","Sat"};
        private int[] num = {0,1,2,3,4,5,6,7,8,9};



         #region IEnumerable 成员

          System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
         {
              foreach (string s in day)
              {
                  yield return s;
              }
           
         }

         #endregion

          #region IEnumerable2 成员

        public System.Collections.IEnumerable  NumIterator()
          {
              foreach (int i in num)
              {
                  yield return i;
              }

          }

          #endregion

    }
    
    class Program
    {
       
        static void Main(string[] args)
        {
               WeekDay  weekday=new WeekDay();

            foreach (string day in weekday)
            {
                Console.Write(day+"   ");
            }

            Console.Write( "\n");
            foreach (int i in weekday.NumIterator())
            {
                Console.Write(i + "   ");
            }

            Console.ReadKey();
        }

    }
}
