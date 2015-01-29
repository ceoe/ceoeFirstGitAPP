using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAndUnboxDEMO1
{
    interface ISetname
    {
        string Name { get; set; }
    }

    struct MyStruct : ISetname
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public MyStruct(string name)
        {
            _name = name;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyStruct ms = new MyStruct("陈六");
            ArrayList aa = new ArrayList();
            aa.Add(ms);

            MyStruct [] myarr=new MyStruct[5];
            myarr[0] = ms;
            Console.WriteLine(ms.Name);
            Console.WriteLine(((MyStruct)aa[0]).Name);
            Console.WriteLine(myarr[0].Name);

            MyStruct ms1 = ((MyStruct)aa[0]);

            ms1.Name = "王五";

            ((ISetname)aa[0]).Name = "张三";

            myarr[0].Name = "孙七";

            Console.WriteLine();

            Console.WriteLine(ms.Name);
            Console.WriteLine(((MyStruct)aa[0]).Name);
            Console.WriteLine(myarr[0].Name);
            Console.WriteLine(ms1.Name);
            Console.ReadKey(true);
        }
    }
}
