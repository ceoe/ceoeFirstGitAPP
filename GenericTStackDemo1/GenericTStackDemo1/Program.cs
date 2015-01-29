using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTStackDemo1
{
    class Mystack<T>
    {
        private T[] _item;
        private int count;

        public Mystack(int size)
        {
            _item = new T[size];
            count = 0;
        }

        public Mystack()
        {
            
            
            count = 0;
        }

        public void Push(T x)
        {
            _item[count++] = x;
        }

        public T Pop()
        {
            return _item[--count];
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Mystack<int>  mystack=new Mystack<int>(20);

            mystack.Push(200);
            mystack.Push(300);

            Console.WriteLine(mystack.Pop()+mystack.Pop());

            Console.ReadKey();

        }
    }
}
