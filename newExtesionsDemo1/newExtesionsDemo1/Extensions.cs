using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions

{
    static class Util
    {
        public static int ConverttoBase(this int i, int BaseConvertTo)
        {
            if (BaseConvertTo < 2 || BaseConvertTo>10)
            {
                throw new ArgumentException( "超出程序转换进制的范围！"+BaseConvertTo.ToString() );
            }

            int result = 0;
            int iterator = 0;
            do
            {
                int nextDigital = i%BaseConvertTo;
                i /= BaseConvertTo;
                //取余后 与10的幂相乘得到最高位？？

                result = result + nextDigital*(int) Math.Pow(10, iterator);
                iterator++;

            } while (i!=0);
            return result;


        }

    }
}
