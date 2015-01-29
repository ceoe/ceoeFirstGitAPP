using System;
using System.Collections;
using  System.Drawing;
using System.Windows.Forms; 

namespace Tetirs
{
    internal class InfoArr
    {
        //InfoArr 类是用于存储并维护一个BlockInfo的动态数组, 包括往info 中添加/删除 BlockInfo对象.
        //统计info中BlockInfo的实例对象个数
        private ArrayList info = new ArrayList();
        private int _length = 0;

        public int Length
        {
            get { return _length; }
        }

        public InfoArr()
        {
        }

        //下标索引器  -> 返回一个Object对象, 实际上在使用时需要强制将Object 转换成 BlockInfo,
        public BlockInfo this[int index] //索引器1 根据一个下标 返回一个BlockInfo对象
        {
            get { return (BlockInfo)info[index]; }
        }


        //块模型字符形式位编码索引器->设置对应块模型编码的字符形式的Color编码
        public string this[string id] //索引器2  根据ID串 设置对应BlockInfo的颜色
        {
            //该索引器只实现了写的方法
            set
            {
                //若是位编码为空则直接跳出索引器
                if (value == "")
                {
                    return;
                }
                //若不为空,则遍历info.查找块模型字符形式编码相匹配的的ArrayList对象,
                for (int i = 0; i < info.Count; i++)
                {
                    if (((BlockInfo) info[i]).GetIDStr() == id)
                    {
                        //若成功找到则将ArrayList对象转换为BlockInfo对象,并调用BlockInfo.Bcolor属性赋值.
                        try
                        {
                            ((BlockInfo) info[i]).BColor = Color.FromArgb(Convert.ToInt32(value));
                        }
                            // 若value值不正确,则抛出格式异常提示.
                        catch (System.FormatException)
                        {
                            string errormsg = "颜色信息编码超出设置范围,需要检查并修改config文件,出现错误的模型块为第" + i + "块";
                            MessageBox.Show(errormsg, "需要重新方块绘制的颜色", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }


        //方法: 将id串转换为BitArray编码
        private BitArray StrTobit(string id) //将字符串转换为bitArray

        {
            //将参数id的长度进行判断
            if (id.Length != 25)
            {
                throw new SystemException("块模型格式不正确,正常的块模型应该为25个字符,请检查conifg文件!");
            }
            BitArray ba = new BitArray(25);
            for (int i = 0; i < 25; i++)
            {
                ba[i] = (id[i] != '0');
            }
            return ba;
        }

        //方法: 增加参数为BitArray Color形式的BlockInfo实例对象到ArrayList中
        public void AddType(BitArray id, Color bColor)
        {
            if (id.Length != 25)
            {
                throw new SystemException("块模型格式不正确,正常的块模型应该为25个字符,请检查conifg文件!");
            }
            //增加参数为BitArray Color形式的BlockInfo实例对象到ArrayList中
            info.Add(new BlockInfo(id, bColor));
            //对私有变量_length加1 ? 这个有用吗? 似乎没有remove方法??
            _length++;
        }

        //方法: 增加参数类型均为string 的形式的BlockInfo实例对象到ArrayList中
        public void AddType(string id, string bColor)
        {
            //定义一个Color类型变量,将字符形式的颜色编码转换成Color类型编码
            Color tempColor;
            if (bColor != "")
            {

                tempColor = Color.FromArgb(Convert.ToInt32(bColor));
                //throw new SystemException("块模型的颜色编码不正确,请检查conifg文件!");
            }
            else
            {
                tempColor = Color.Empty;
            }


            info.Add(new BlockInfo(StrTobit(id), tempColor));
            _length++;
        }

        //方法: 移除ArrayList中对应下标的的BlockInfo对象
        public void RemoveType(int i)
        {
            if (i>0&&i<=info.Count-1)
            {
                info.RemoveAt(i);
                _length--;
            }
        }

        //方法: 移除ArrayList中对应ID匹配的BlockInfo对象
        public void RemoveType(string id)
        {
            for (int i = 0; i < info.Count; i++)
            {
                if (((BlockInfo)info[i]).GetIDStr() == id)
                {
                    //若成功找到则将ArrayList对象转换为BlockInfo对象,并调用BlockInfo.Bcolor属性赋值.
                    info.RemoveAt(i);
                }
            }
        }

        //方法: 移除ArrayList中对应BitArray  类型匹配的对象.
        public void RemoveType(BitArray id)
        {
            for (int i = 0; i < info.Count-1; i++)
            {
                if (((BlockInfo) info[i]).ID == id)
                {
                   info.RemoveAt(i);
                }
            }
        }

    }
}
