using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTypeDemoTest1
{
    internal enum Month
    {
        //一月, 二月, 三月, 四月, 五月, 六月, 七月, 八月, 九月, 十月, 十一月, 十二月
        January, February, March, April, May, June, July, August, September,  October, November, December
    };


    class SeasonExample
    {
        //Season season = Season.Fall;

        //类体中不允许出现直接调用方法吗？ 难道只能建立方法中调用方法？
        //public void PrintSeason()
        //{
        //    Console.WriteLine("season is " + season);
        //}


    }
}
