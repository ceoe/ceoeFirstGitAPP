using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//存储键值所需序列化

namespace Tetris
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        KeyConfig config;
        public FrmConfig(KeyConfig con)
        {
            InitializeComponent();
            config = con;
            txtLeft.Text = config.KeyLeft.ToString();
            txtLeft.Tag = config.KeyLeft;               //存放与对象关联的用户定义数据
            txtRight.Text = config.KeyRight.ToString();
            txtRight.Tag = config.KeyRight;
            txtDown.Text = config.KeyDown.ToString();
            txtDown.Tag = config.KeyDown;
            txtDrop.Text = config.KeyDrop.ToString();
            txtDrop.Tag = config.KeyDrop;
            txtRotate.Text = config.KeyRotate.ToString();
            txtRotate.Tag = config.KeyRotate;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {//屏蔽掉不适合作为快捷键的键
            if ((e.KeyValue >= 33 && e.KeyValue <= 36) || (e.KeyValue >= 45 && e.KeyValue <= 46) ||
               (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 65 && e.KeyValue <= 90) ||
               (e.KeyValue >= 96 && e.KeyValue <= 107) || (e.KeyValue >= 109 && e.KeyValue <= 111) ||
               (e.KeyValue >= 186 && e.KeyValue <= 192) ||
               (e.KeyValue >= 219 && e.KeyValue <= 222))
            {
                foreach (Control c in gbKeySet.Controls)//先清空冲突的快捷键值
                {
                    TextBox txtTemp = c as TextBox;
                    if (txtTemp != null)
                    {
                        if ((Keys)txtTemp.Tag == e.KeyCode)
                        {
                            txtTemp.Text = "";
                            txtTemp.Tag = Keys.None;
                        }
                    }
                }

                //sender 表示发生时间的编辑框
                TextBox txtHot = (TextBox)sender;
                txtHot.Text = e.KeyCode.ToString();
                txtHot.Tag = e.KeyCode;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            config.KeyLeft = (Keys)txtLeft.Tag;
            config.KeyRight = (Keys)txtRight.Tag;
            config.KeyRotate = (Keys)txtRotate.Tag;
            config.KeyDrop = (Keys)txtDrop.Tag;
            config.KeyDown = (Keys)txtDown.Tag;
            SaveConfigToFile();
            Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveConfigToFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream=new FileStream("Key.tet",FileMode.Create,
                FileAccess.Write,FileShare.None);
            formatter.Serialize(stream,config);
            stream.Close();
        }
        
    }
}
