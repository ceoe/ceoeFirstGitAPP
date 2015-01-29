using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableUsageDemo1
{
    class Studen : IComparable
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Studen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        #region IComparable 成员
        // 隐式的声明接口方法.  签名中包含强类型参数. 
        public int CompareTo(Studen stu)
        {
            return Name.CompareTo(stu.Name);
        }

        #endregion

        #region IComparable 成员

        //显式的声明接口方法, 不需要加pubic ,protect , private  static 等访问修饰符. 并只能在外部由 接口名+方法名进行调用.
        // 由于使用了Object类型作为参数, 此方法的签名属于弱类型参数, 使用过多会造成性能损失. 但是可以与上面的隐式声明配套使用
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Studen))
            {
                throw new ArgumentException("非Studen 类型!");
            }
            return Name.CompareTo(((Studen)obj).Name);
        }

        #endregion



        #region 适配器模式下的 多条件比较

        private class AgeComparer : IComparer
        {

            #region IComparer 成员

            int IComparer.Compare(object x, object y)
            {
                if (!(x is Studen) || !(y is Studen))
                {
                    throw new ArgumentException("非Student 类型");
                }
                return ((Studen)x)._age.CompareTo(((Studen)y)._age);
            }

            #endregion
        }

        private static AgeComparer _ageComparer = null;


        // 接口类型的属性声明    属性的类型原来还可以是一个类类型,并且可以在get 或者set 方法中实例化一个内部类. 返回一个接口
        // 前提是 该内部类继承了某个接口 
        public static  IComparer AgeCompare
        {
            get
            {
                if (_ageComparer==null)
                {
                    _ageComparer=new AgeComparer();
                }
                return _ageComparer;
            }
        }

      

        #endregion


        public override string ToString()
        {
            return _name + "       " + _age;
        }

      

      
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stu = new Studen[5];

            stu[0] = new Studen("张三", 1);
            stu[1] = new Studen("王五", 3);
            stu[2] = new Studen("李四", 2);
            stu[3] = new Studen("陈六", 5);
            stu[4] = new Studen("孙七", 4);

            Console.WriteLine("原始顺序:");
           foreach (var studen in stu)
            {
                Console.WriteLine(studen.ToString());
            }
            
            
            Console.WriteLine("对类数组进行 姓名字段的排序:");
            Array.Sort(stu);

            foreach (var studen in stu)
            {
                Console.WriteLine(studen.ToString());
            }

            Console.WriteLine("对类数组进行 年龄字段的排序:");
            Array.Sort(stu, Studen.AgeCompare);

            foreach (var studen in stu)
            {
                Console.WriteLine(studen.ToString());
            }

            Console.ReadKey();
        }
    }
}
