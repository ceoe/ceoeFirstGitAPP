//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace AboutDelegatedemo1
//{
//    public partial class Form2 : Form
//    {
//        public Form2()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            if (checkBox1.Checked == true)
//            {
//                textBox1.Clear();
//                textBox1.Refresh();
//                // 调用方法WriteRichTextBox1想文本区1写入文字
//                this.WriteTextBox1();
//                textBox3.Focus();
//                textBox3.SelectAll();
//            }
//            if (checkBox2.Checked == true)
//            {
//                textBox2.Clear();
//                textBox2.Refresh();
//                // 调用方法WriteRichTextBox2想文本区2写入文字
//                this.WriteTextBox2();
//                textBox3.Focus();
//                textBox3.SelectAll();
//            }
//        }

//        private void WriteTextBox1()
//        {
//            string data = textBox3.Text;
//            for (int i = 0; i < data.Length; i++)
//            {
//                textBox1.AppendText(data[i].ToString());
//                //间歇延时
//               //  DateTime now = DateTime.Now;
//                //while (now.AddSeconds(1) > DateTime.Now)
//              //  { }
//            }
//        }

//        private void WriteTextBox2()
//        {
//            string data = textBox3.Text;
//            for (int i = 0; i < data.Length; i++)
//            {
//                textBox2.AppendText(data[i].ToString());
//                //间歇延时
//                //DateTime now = DateTime.Now;
//                //while (now.AddSeconds(1) > DateTime.Now)
//                //{ }
//            }
//        }
//    }
//}
