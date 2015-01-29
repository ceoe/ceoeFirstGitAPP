using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetirs
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    blockarrary[i, j] = false;
                }
            }
        }

        bool[,] blockarrary = new bool[5, 5];

        private  Color BackGroundColor = Color.Black;

        public Color BlockColor = Color.Gold;

        private Config  config=new Config();


        private void lblModelconfig_Paint(object sender, PaintEventArgs e)
        {
            //建立Graphic 对象 通过 事件e变量
            Graphics gp = e.Graphics;
            //使用Graphic中的Clear方法填充颜色
            gp.Clear(BackGroundColor);
            // 声明一个画笔对象,使用白色
            var p = new Pen(Color.White);

            //从坐标0,0开始,每隔31个像素位置画一条白线
            for (int i = 30; i < 156; i = i + 31)
            {
                gp.DrawLine(p, 1, i, 155, i);
                gp.DrawLine(p, i, 1, i, 155);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    SolidBrush s;
                    if (!blockarrary[i, j])
                    {
                        s = new SolidBrush(BackGroundColor);

                    }
                    else
                    {
                        s = new SolidBrush(BlockColor);

                    }
                    gp.FillRectangle(s, i * 31, j * 31, 30, 30);
                }
            }

        }

        private void lblModelconfig_MouseClick(object sender, MouseEventArgs e)
        {
            //若不是Mouse事件中的左键触发,则程序直接返回
            if (e.Button != MouseButtons.Left)
                return;
            // 若是属于鼠标左键触发, 将触发时的鼠标XY坐标除以31 得到所属区块位置
            int posx = e.X / 31;
            int posy = e.Y / 31;

            // 将区块位置对应的bool数组进行求反运算
            blockarrary[posx, posy] = !blockarrary[posx, posy];
            //并将结果赋值给中间bool变量
            var alt = blockarrary[posx, posy];

            //因为Mouse Click事件中未能提供绘图的对象,所以需要创建一个,并且这个创建的绘图对象来自于lblModelconfig
            var gp = lblModelconfig.CreateGraphics();

            //定义画笔用于绘制矩形框线
            var p = new Pen(Color.White);
            //定义实心画刷,用于绘制实心矩形框
            var s = new SolidBrush(alt ? BlockColor : BackGroundColor);

            //绘制矩形框线
            gp.DrawRectangle(p, posx * 31, posy * 31, 30, 30);
            //绘制填充矩形
            gp.FillRectangle(s, posx * 31, posy * 31, 30, 30);
            //一定切记要及时释放来自lblModelconfig.Graphic的资源.
            gp.Dispose();
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            BlockColor = colorDialog1.Color;
            lblColor.BackColor = colorDialog1.Color;
            lblModelconfig.Invalidate();

        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {

            //定义一个判断是否为空的变量
            var notempty = false;
            // 遍历整个BlockArray 
            //对于所有使用foreach  --- if ..判断数组或者集合对象你们是否包含某个元素或对象的场合,
            //可以写成  返回值为bool  if  集合名(数组名).Cast<临时对象类型>().Any(临时对象=>判断条件);
            notempty = blockarrary.Cast<bool>().Any(i => i == true);


            #region MyRegion


            //foreach (bool i in blockarrary)
            //{
            //  //如果存在一个块为真
            //    if (i)
            //    {
            //       //那么就赋值Notempty 为真
            //       notempty = true;
            //        //跳出遍历
            //        break;
            //    }
            //}   
            //遍历完成后,判断Notempty是否为真,
            if (!notempty)
            {
                MessageBox.Show("没有定义任何方块图形,请使用鼠标左键重新定义新图形!", "需要重新绘制方块", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            //建立一个stringBuilder字符串,用于添加存储编码
            var sbu = new StringBuilder(25);

            //再次遍历BlockArray.
            foreach (var i in blockarrary)
            {
                //是真就添加1,是假就添加0
                sbu.Append(i ? "1" : "0");
            }

            //将stringBuilder类转成string对象
            var strForCompare = sbu.ToString();


            //遍历ListViewItem中的Subitems中的第0列,检查是否存在同样的编码串
            /*  这是 查找数组中是否包含某元素的传统写法
            foreach (ListViewItem item in lsvBlockSet.Items)
            {

                if (item.SubItems[0].Text == strForCompare)
                {
                    MessageBox.Show("此方块图形已经存在!请勿重复添加!", "已存在此方块", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    return;
                }
            }
             */
            #endregion

            // 以下是使用LINQ表达式来查找某个数组对象中包含某个元素的写法.
            if (lsvBlockSet.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text == strForCompare))
            {
                MessageBox.Show("此方块图形已经存在!请勿重复添加!", "已存在此方块", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            //再生成一个Listviewitem对象, mylsvitem
            ListViewItem mylsvitem = new ListViewItem();
            //将lsvblockset.item对象地址赋值给mylsvitem引用
            mylsvitem = lsvBlockSet.Items.Add(strForCompare);

            mylsvitem.SubItems.Add(Convert.ToString(BlockColor.ToArgb()));
        }

        private void lsvBlockSet_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                BlockColor = Color.FromArgb(int.Parse(e.Item.SubItems[1].Text));
                lblColor.BackColor = BlockColor;
                string str = e.Item.SubItems[0].Text;
                for (int i = 0; i < str.Length; i++)
                {
                    blockarrary[i / 5, i % 5] = (str[i] == '1') ? true :
                    false;
                }
                lblModelconfig.Invalidate();
            }

        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    blockarrary[i, j] = false;
                }
            }
            lblModelconfig.Invalidate();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lsvBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("没有在列表选中任何方块图形,请使用鼠标点击选择!", "提示信息", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            lsvBlockSet.Items.Remove(lsvBlockSet.SelectedItems[0]);
            btnReset.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsSeletedListViewItem())

                if (IsemptyModeling())

                    if (IsHaveSameModeling(EncodeBlockArray()))
                    {
                        lsvBlockSet.SelectedItems[0].SubItems[0].Text = EncodeBlockArray();
                        lsvBlockSet.SelectedItems[0].SubItems[1].Text =
                            Convert.ToString(Convert.ToString(BlockColor.ToArgb()));
                    }

            lsvBlockSet.Select();
            return;
        }


        //判断是否选中了某一行,有选中则返回True,没有选中则提示并返回false
        private bool IsSeletedListViewItem()
        {
            if (lsvBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("没有在列表选中任何方块图形,请使用鼠标点击选择!", "提示信息", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }

        }

        //判断当前的方块模型不是空模型,若为空返回false ,若不为空返回true.
        private bool IsemptyModeling()
        {
            var Noempty = false;
            // 遍历整个BlockArray 
            //对于所有使用foreach  --- if ..判断数组或者集合对象你们是否包含某个元素或对象的场合,
            //可以写成  返回值为bool  if  集合名(数组名).Cast<临时对象类型>().Any(临时对象=>判断条件);

            //遍历完成后,判断Notempty是否为真,

            Noempty = blockarrary.Cast<bool>().Any(i => i == true);

            if (!Noempty)
            {
                MessageBox.Show("没有定义任何方块图形,请使用鼠标左键重新定义新图形!", "需要重新绘制方块", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return Noempty;
            }
        }

        // 判断是否存在相同的方块模型.
        private bool IsHaveSameModeling(string strForCompare)
        {


            // 以下是使用LINQ表达式来查找某个数组对象中包含某个元素的写法.
            if (lsvBlockSet.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text == strForCompare))
            {
                MessageBox.Show("此方块图形已经存在!请勿重复添加!", "已存在此方块", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        //对blockArray 进行编码,返回一个字符串
        private string EncodeBlockArray()
        {
            //建立一个stringBuilder字符串,用于添加存储编码
            var sbu = new StringBuilder(25);

            //再次遍历BlockArray.
            foreach (var i in blockarrary)
            {
                //是真就添加1,是假就添加0
                sbu.Append(i ? "1" : "0");
            }

            //将stringBuilder类转成string对象
            string strForCompare = sbu.ToString();

            return strForCompare;

        }

       //对在groupbox 键盘设置 控件 gbKeyset中的所有Controls进行遍历,设定相应的按键值
        private void txtKeyRotCCW_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= 33 && e.KeyValue <= 36) ||
                 (e.KeyValue >= 45 && e.KeyValue <= 46) ||
                (e.KeyValue >= 48 && e.KeyValue <= 57) ||
                (e.KeyValue >= 65 && e.KeyValue <= 90) ||
                (e.KeyValue >= 96 && e.KeyValue <= 107)||
                (e.KeyValue >= 109 && e.KeyValue <= 111) || 
                (e.KeyValue >= 186 && e.KeyValue <= 192) ||
                (e.KeyValue >= 219 && e.KeyValue <= 222))
            {
                //if (gbKeySet.Controls.Cast<TextBox>().Any(TempC => ((int) TempC.Tag) == e.KeyValue))
                foreach (Control c in gbKeySet.Controls)
                {
                    Control TempC = c as TextBox;
                    if (TempC != null)
                    {
                        if (TempC.Text!="")
                        {


                            if (((int)TempC.Tag) == e.KeyValue)
                            {
                                TempC.Text = "";
                                TempC.Tag = Keys.None;
                            }

                        }
                        #region 关于GroupBox.里面的Controls属性用法,做个标记
                        //if (((int)((TextBox)TempC).Tag)==e.KeyValue)
                        //{
                        //     (TextBox)TempC).Tag = Keys.None;

                        //     (TextBox)TempC).Text = "";
                        //}

                        //if (((int)((TextBox)TempC).Tag)==e.KeyValue)
                        // {
                        //    (TextBox)TempC).Tag = Keys.None;

                        //    (TextBox)TempC).Text = "";
                        //}
                        #endregion
                    }
                }

                ((TextBox) sender).Text = e.KeyCode.ToString();
                ((TextBox) sender).Tag = (Keys)e.KeyValue;

            }
            #region  此段本想使用char类中IsDigit, IsLetterOrDigit 的静态方法的判断可见字符的方式来测试,暂不成熟.
            //此例子中有判断其他控制符之类key,所以不完全适用
            //switch (e.KeyValue)
            //{
            //    case 33:

            //        break;
            //    case 34:

            //        break;
            //    case 35:

            //        break;
            //    case 45:

            //        break;
            //    case 46:

            //        break;
            //    case 37:
            //        break;
            //}


            #endregion

        }

        //
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            config.LoadFromXmlFile();
            InfoArr info = config.Info;

            //读取文件中块模型数据并显示到listview中
            ListViewItem  myitem=new ListViewItem();
            for (int i = 0; i < info.Length; i++)
            {
                myitem = lsvBlockSet.Items.Add(info[i].GetIDStr());
                myitem.SubItems.Add(info[i].GetColorStr());
            }

            //读取并设置快捷键

            txtKeyDn.Text = config.DownKey.ToString();
            txtKeyDn.Tag = config.DownKey;
            txtKeyDropDn.Text = config.DropDownKey.ToString();
            txtKeyDropDn.Tag = config.DropDownKey;
            txtKeyLeft.Text = config.MoveLeftKey.ToString();
            txtKeyLeft.Tag = config.MoveLeftKey;
            txtkeyRight.Text = config.MoveRightKey.ToString();
            txtkeyRight.Tag = config.MoveRightKey;
            txtKeyRotCW.Text = config.RotCwKey.ToString();
            txtKeyRotCW.Tag = config.RotCwKey;
            txtKeyRotCCW.Text = config.RotCcwKey.ToString();
            txtKeyRotCCW.Tag = config.RotCcwKey;

            //读取并设置环境参数

            txtWidth.Text = config.CoorWidth.ToString();
            txtHeight.Text = config.CoorHeight.ToString();
            txtRectPix.Text = config.RectPix.ToString();
            lbBackColor.BackColor = config.BackColor;
            BackGroundColor = config.BackColor;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfoArr info=new InfoArr();
            foreach (ListViewItem item in lsvBlockSet.Items)
            {
                info.AddType(item.SubItems[0].Text,item.SubItems[1].Text);
            }

            config.Info = info;
            config.DownKey =(Keys) txtKeyDn.Tag;
            config.DropDownKey = (Keys)txtKeyDropDn.Tag;
            config.MoveRightKey = (Keys)txtkeyRight.Tag;
            config.MoveLeftKey = (Keys)txtKeyLeft.Tag;
            config.RotCwKey = (Keys)txtKeyRotCW.Tag;
            config.RotCcwKey = (Keys)txtKeyRotCCW.Tag;

            config.CoorHeight = int.Parse(txtHeight.Text);
            config.CoorWidth = int.Parse(txtWidth.Text);
            config.RectPix = int.Parse(txtRectPix.Text);
            config.BackColor = lbBackColor.BackColor;
            
            config.SaveToXmlFile();
        }

        private void lbBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            BackGroundColor = colorDialog1.Color;
            lbBackColor.BackColor = colorDialog1.Color;
            lblModelconfig.Invalidate();
        }

        private void btnCFGFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
