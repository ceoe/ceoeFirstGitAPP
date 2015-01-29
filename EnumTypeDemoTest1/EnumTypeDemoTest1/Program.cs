using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTypeDemoTest1
{
    //internal enum Season
    //{
    //    Spring,
    //    Summer,
    //    Fall,
    //    Winter
    //};





    class Program
    {
        static void DoWork()
        {

            //todo
        
            Month  first=Month.December;
            Console.WriteLine(first);
            first++;
            Console.WriteLine(first);
        }



        static void Main(string[] args)
         {
            //SeasonExample  se=new SeasonExample();
            //se.PrintSeason();
            //Season season = Season.Fall;
            //Console.WriteLine("season is " + season);

            try
            {
                 DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            Console.ReadKey();
        }
    }

}
