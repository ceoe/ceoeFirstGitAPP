using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedSingleChainListDemo
{
    internal class LinkedList
    {
        private class Node
        {
            // 数据域
            public object item;

            // 指针域,  注意 这里定义下个指针时,最好是引用全路径.
            public Node Next;
            //public LinkedList.Node Next;

            public Node(object value)
            {
                item = value;
            }

            public override string ToString()
            {
                return item.ToString();
            }
        }

        //元素个数
        private int _count;

        private Node head;


        public int Count
        {
            get { return _count; }
        }


        private Node GetByIndex(int index)
        {
            if (index < 0 || index >= this._count)
            {
                throw new ArgumentOutOfRangeException("Index", "索引超出了范围");
            }

            Node tempNode = this.head;
            //嵌套结构, 先找到事前存储的头指针, 遍历
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }

        public object this[int index]
        {
            get { return GetByIndex(index).item; }
            set { GetByIndex(index).item = value; }
        }

        public void Add(object value)
        {
            Node newnode = new Node(value);
            if (head == null)
            {
                head = newnode;
            }
            else
            {
                GetByIndex(_count - 1).Next = newnode;
            }
            _count++;

        }

        public void InsertAt(int index, object value)
        {
            //对于引用型的变量,先声明,再赋初值,再引用.
            Node tempNode;
            if (index < 0 || index >= this._count)
            {
                throw new ArgumentOutOfRangeException("Index", "索引超出了范围");
            }
          
           //对于插入点在开始节点=0的情况
            if (index==0)
            {
               //对于开始节点本来就为空的情况
                if (head=null)
                {
                    head=new Node(value);
                }else
                {
                    //对于开始节点不为空,则需要包装成一个临时节点
                    tempNode = new Node(value);
                    //将临时节点的NEXT域赋值为head.
                    tempNode.Next = head;
                    //将头指针赋值为tempNode;
                    head = tempNode;
                }
            }
          
         

            tempNode.Next = GetByIndex(index).Next;
            GetByIndex(index).Next = tempNode;
        }




}
}
