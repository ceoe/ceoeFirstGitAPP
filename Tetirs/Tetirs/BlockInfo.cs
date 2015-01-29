using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Tetirs
{
    class BlockInfo
    {
        //BlockInfo类主要是声明一个结构,用于存储有关块模型的一些操作. 比如块模型的读写,从一个长度为25的字符串中得到一个Bitarray序列
        //从一个数字字符串中转换成对应的颜色变量.
        //定义模型放开的2个基本字段, 位状态及颜色.

        private BitArray _id;

        private Color _bColor;

        //声明构造函数,前提是构造函数的参数符合BitArray和Color类型要求
        public BlockInfo(BitArray id,Color bColor)
        {
            ID = id;
            BColor = bColor;
        }

        //声明块模型的位状态编码属性
        public BitArray ID
        {
            get { return _id; }
            set { _id = value; }
        }

        //声明块模型的颜色编码属性
        public Color BColor
        {
            get { return _bColor; }
            set { _bColor = value; }
        }

        //将块模型的BitArray 编码转换层字符串
        public string GetIDStr()
        {
            StringBuilder s=new StringBuilder();
            foreach (bool b in _id)
            {
                s.Append(b ? "1" : "0");
            }
            return s.ToString();
           
        }
        //块模型的颜色编码信息转换成字符串.
        public string GetColorStr()
        {
            return Convert.ToString(_bColor.ToArgb());
        }

    }
}
