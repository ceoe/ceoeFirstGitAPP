using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassesDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //int x1 = -1;
            //int y1 = -1;
            //int x2 = int.Parse(Console.ReadLine());
            //int y2 = int.Parse(Console.ReadLine());
            //double dis = Math.Sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1));
            //Console.WriteLine("两点间的距离是："+dis);



            Console.Write("请输入x2：");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("请输入y2：");
            int y2 = Convert.ToInt32(Console.ReadLine());


            Point dotA = new Point();
            Point dotB = new Point(x2, y2);

            double AtoB = dotA.Distance(dotB);
            double BtoA = dotB.Distance(dotA);

            Console.WriteLine("A to B 两点间的距离是：" + AtoB);
            Console.WriteLine("B to A 两点间的距离是：" + BtoA);



            Console.WriteLine("两点间的距离是：" + Convert.ToString(dotA.Distance(dotB)));

            Console.ReadKey();

        }
    }
}
