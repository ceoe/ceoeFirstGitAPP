using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSearchDemo1
{
    class Node
    {
        private Object _data;

        private Node _left;
        private Node _right;

        public object Data
        {
            get { return _data; }
        }

        public Node Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Node Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public Node(Object data)
        {
            _data = data;
        }


        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
