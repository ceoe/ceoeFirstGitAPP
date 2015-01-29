using System;

namespace ParametersDemo
{
    internal class Util
    {
        //调用静态的方法，不需要new实例化。直接类名.方法名。
        public static int Min(params int[] ParamList)
        {
            if (ParamList == null || ParamList.Length == 0)
            {
                throw new ArgumentException("Parameter Array is null Please Check it Again!");
            }

            int currentMin = ParamList[0];
            foreach (int i in ParamList)
            {
                if (currentMin > i) currentMin = i;
            }

            return currentMin;

        }

        public static int Sum(params int[] ParamList)
        {

            if (ParamList == null || ParamList.Length == 0)
            {
                throw new ArgumentException("Parameter Array is null Please Check it Again!");
            }

            int TotalSum = 0;
            foreach (int i in ParamList)
            {

                TotalSum += i;
            }
            return TotalSum;
        }
    }
}