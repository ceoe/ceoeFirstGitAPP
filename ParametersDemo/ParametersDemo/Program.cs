using System;

namespace ParametersDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var a1 = new[] {20, 30, 40, 50, 10, -2, 22, 44};
          //调用静态的方法，不需要new实例化。直接类名.方法名。
            int min = Util.Min(a1);
            Console.WriteLine("Mini Number is " + min);

            min = Util.Min(120, 230, 240, 530, 190, 101, 122, 344);
            Console.WriteLine("Mini Number is " + min);

            var a2 = new[] { 120, 230, 240, 530, 190, 99, 122, 344 };
            //调用静态的方法，不需要new实例化。直接类名.方法名。
            min = Util.Min(a2);
              
            Console.WriteLine("Mini Number is " + min);



            Console.ReadKey();
        }
    }
}