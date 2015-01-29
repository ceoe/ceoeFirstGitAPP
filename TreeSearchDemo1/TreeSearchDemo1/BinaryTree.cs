using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSearchDemo1
{

    // 二叉树集合的操作类。 二叉树必须先有一个根，并且有一个指针指向这个根（在构造函数里面搞定）。
    class BinaryTree
    {
        private Node _head;
        private string str;


        public Node Head
        {
            get { return _head; }
        }

        public StringBuilder testsb=new StringBuilder();

        public BinaryTree(string str1)
        {
            str= str1;
            _head=new Node(str1[0]);
            AddElement(_head,0);
        }

        private void AddElement(Node parent, int index)
        {
            int leftindex = index*2 + 1;
            if (leftindex<str.Length)
            {
                if (str[leftindex]!='#')
                {
                    //这条语句做了2件事情，1是实例化了一个新的Node对象，并初始化Node._data
                    //成员为str串中的某个元素，并将这个Node对象的引用赋值给了父节点的Left属性。
                    parent.Left = new Node(str[leftindex]);
                    testsb.Append(parent.Left.Data.ToString());
                    AddElement(parent.Left,leftindex);
                }
            }
            int rightindex = index * 2 + 2;
            if (rightindex < str.Length)
            {
                if (str[rightindex] != '#')
                {
                    parent.Right = new Node(str[rightindex]);
                    testsb.Append(parent.Right.Data.ToString());
                    AddElement(parent.Right, rightindex);
                }
            }
        }


        public  StringBuilder sb1=new StringBuilder();


        public void  PreOrder(Node node)
        {
            if (node!=null)
            {
                sb1.Append(node.ToString());

                PreOrder(node.Left);
                PreOrder(node.Right);
            }
            
        }

        public void PreOrederByStack()
        {

            var tempst = new Stack();
            Node checkNode = _head;

            //
            while (tempst.Count>0||checkNode!=null)
            {
                while (checkNode != null)
                {
                    sb1.Append(checkNode.ToString());
                   tempst.Push(checkNode);
                   checkNode = checkNode.Left;
                }
                if (tempst.Count>0)
                {
                    checkNode=(Node)tempst.Pop();
                    checkNode = checkNode.Right;

                }
            }

        }

        public void MidOrder(Node node)
        {
            if (node != null)
            {
                MidOrder(node.Left);
                sb1.Append(node.ToString());
                MidOrder(node.Right);
            }
           
        }

        public void MidOrederByStack()
        {

            var tempst = new Stack();
            Node checkNode = _head;

            //
            while (tempst.Count > 0 || checkNode != null)
            {
                while (checkNode != null)
                {
                    tempst.Push(checkNode);
                    checkNode = checkNode.Left;
                }

                if (tempst.Count>0)
                {
                    checkNode=(Node)tempst.Pop();
                    sb1.Append(checkNode.ToString());
                    checkNode = checkNode.Right;
                }
            }

        }

        public void LastOrder(Node node)
        {
            if (node != null)
            {
               LastOrder(node.Left);
               LastOrder(node.Right);
               sb1.Append(node.ToString());
            }
            
        }

        public void LastOrderbyStack()
        {
            var lStack = new Stack<Node>();
            var rStack = new Stack<Node>();

            Node checkNode = _head;
            Node lcheckNode;
            Node rCheckNode;

            do
            {
               //这一段是负责将不为空的第一个节点靠左边的所有左边节点的，左孩子全部入左栈，右孩子入右栈
                while (checkNode!=null)
                {
                    rCheckNode = checkNode.Right; //只要当前节点不为空，就会进行处理
                    lStack.Push(checkNode);
                    rStack.Push(rCheckNode);  //不管当前节点的右孩子是否为空，都会被压入栈。
                    checkNode = checkNode.Left;
                }
                ////////////////////////////////
                
                //当出现末节点出现左孩子为空的情况了，就开始双双出栈。

                lcheckNode=lStack.Pop();
                rCheckNode = rStack.Pop();
                //////////////////////////////////////////
                /// 
                
                //对右栈弹出的节点进行判断， 若为空，则左栈的弹出的数据有效，可以进行处理。
                //若不为空，则需要将原来左栈弹出的元素再次入左栈，并且在右栈再压入一个空元素。
                if (rCheckNode!=null)
                {
                    lStack.Push(lcheckNode);
                    rStack.Push(null);
                 }
                else
                {
                    sb1.Append(lcheckNode.ToString());
                }

              //此句最关键了。 不管数据有效否，右栈弹出的元素都将再次对其进行后序遍历。
                checkNode = rCheckNode;


            } while (checkNode!=null||lStack.Count>0);


          
        }

        public void LastOrderbySingleStack()
        {
            Node prev,checkNode;
            checkNode = _head;
            prev = _head;
            var st = new Stack<Node>();

            do
            {
                while (checkNode!=null)
                {
                    st.Push(checkNode);
                    checkNode = checkNode.Left;
                }

                if (st.Peek().Right == prev || st.Peek().Right==null)
                {
                    prev=st.Pop();
                    sb1.Append(prev.ToString());
                }
                else
                {
                    checkNode = st.Peek().Right;
                    //st.Push(st.Peek().Right);
                }

            } while (checkNode!=null||st.Count>0);
        }

        public void LastOrderbySingleStack2()
        {
            var st2 = new Stack<Node>();
            Node prev = _head, checkNode = _head;

            while (checkNode!=null||st2.Count>0)
            {
                while (checkNode!=null)
                {
                    st2.Push(checkNode);
                    checkNode = checkNode.Left;
                }

                checkNode = st2.Pop();
                if (checkNode.Right==null||checkNode.Right==prev)
                {
                    sb1.Append(checkNode.ToString());
                    prev = checkNode;
                    checkNode = null;
                }
                else
                {
                    st2.Push(checkNode);
                    checkNode = checkNode.Right;
                }
            }
        }

        public void LastOrederByPreOrderAndStack()
        {

            var tempst = new Stack<Node>();
            var invertStack = new Stack<Node>();
            Node checkNode = _head;

            //
            while (tempst.Count > 0 || checkNode != null)
            {
                while (checkNode != null)
                {
                    invertStack.Push(checkNode);
                    tempst.Push(checkNode);
                    checkNode = checkNode.Right;
                }
                if (tempst.Count > 0)
                {
                    checkNode = (Node)tempst.Pop();
                    checkNode = checkNode.Left;

                }
            }
            while (invertStack.Count>0)
            {
                sb1.Append(invertStack.Pop().ToString());
            }

        }





        public void LevelOrder()
        {
            var queue = new Queue();
            queue.Enqueue(_head);
            while (queue.Count>0)
            {
                Node node = (Node) queue.Dequeue();
                sb1.Append(node.ToString());
                if (node.Left!=null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right!=null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public void GetAllOddNum(int frist, int last)
        {
            int OddNum=(frist%2!=0)?(frist+1):frist;
           
            if (OddNum<=last)
            {
                sb1.Append(OddNum.ToString()+" ");
                OddNum = OddNum + 2;
                GetAllOddNum(OddNum,last);

            }

        }

        public void GetAllParityNum(int frist, int last)
        {
            int ParityNum = (frist % 2 != 1) ? (frist + 1) : frist;

            if (ParityNum <= last)
            {
                sb1.Append(ParityNum.ToString() + " ");
                ParityNum = ParityNum + 2;
                GetAllParityNum(ParityNum, last);

            }

        }

        public void GetallOddAdnParityNum(int frist,int last)
        {
            sb1.Append("Odd:  ");
            GetAllOddNum(frist,last);
            sb1.Append("Parity: ");
            GetAllParityNum(frist,last);
        }

        ////////////////////
    }
}
