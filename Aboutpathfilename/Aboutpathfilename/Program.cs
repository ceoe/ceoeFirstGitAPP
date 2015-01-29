using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aboutpathfilename
{
    class Program
    {
        private static void Dizhi(string path,out string mm,out string nn)
        {
            int i = path.Length;
            while (i>0)
            {
                char ch = path[i-1];
                if (ch=='\\'||ch=='/'||ch==':')
                {
                    break;
                }
                i--;
            }
            mm = path.Substring(0, i);
            nn = path.Substring(i);

        }

        static void Main(string[] args)
        {
            string mm, nn;
            Dizhi("E:\\A\\B\\C\\D\\EFG.EXE",out mm,out nn);
            
            Console.WriteLine("文件名:{0}", nn);
            Console.WriteLine("路径是:{0}", mm);
            Console.ReadKey();
        }
    }
}
