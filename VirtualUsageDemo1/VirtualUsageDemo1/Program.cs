using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualUsageDemo1
{
    abstract class Employee
    {
        protected string _name;

        public Employee()
        {
        }

        public Employee(string name)
        {
            this._name = name;
        }

        public abstract void StartWork();


    }


    class Manager:Employee
    {
        public Manager(string name) : base(name)
        {
        }

        public override void StartWork()
        {
            
            Console.Write(_name+"给员工下达生产任务!\n");
        }
    }

    class Secretary : Employee
    {
        public Secretary(string name)
            : base(name)
        {
        }

        public override void StartWork()
        {
            //base.StartWork();
            Console.Write(_name + "辅助经理完成事务工作!\n");
        }
    }

    class Seller : Employee
    {
        public Seller(string name)
            : base(name)
        {
        }

        public override void StartWork()
        {
           // base.StartWork();
            Console.Write(_name + "销售产品\n");
        }
    }

    class  Accounter:Employee
    {
        public Accounter(string name) : base(name)
        {
        }

        public override void StartWork()
        {
            //base.StartWork();
            Console.WriteLine(_name + "给大家算工资.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee[5];

            emp[0] =new Manager("张经理");
            emp[1] =new  Secretary("王秘书");
            emp[2] =new Seller("邹小姐");
            emp[3] =new  Seller("郑小姐");
            emp[4]=new Accounter("叶女士");

            Console.WriteLine("新的一天开始了,早上好!");

            foreach (var employee in emp)
            {
                employee.StartWork();
            }

            Console.ReadKey();
        }
    }

}
