using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEqualsMothedDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string a =new string( new char[]{'h','e','l','l','o'});
            string b = new string(new char[] {'h', 'e', 'l', 'l', 'o'});

            Console.WriteLine(a==b);
            Console.WriteLine(a.Equals(b));

            object g = a;
            object h = b;

            Console.WriteLine(g==h);
            Console.WriteLine(g.Equals(h));

            Person p1=new Person("jia");
            Person p2=new Person("jia");

            Console.WriteLine(p1==p2);
            Console.WriteLine(p1.Equals(p2));

            Person p3=new Person("jia");
            Person p4 = p3;


            Console.WriteLine(p3==p4);
            Console.WriteLine(p3.Equals(p4));
            Console.ReadKey();

        }
    }
   

    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }
    }
}
