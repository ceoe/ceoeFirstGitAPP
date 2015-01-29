using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AboutDelegatedemo1

{
    
    
    public partial class Form2 : Form
    {

       //代理的声明格式如下：
        //  访问修饰符  delegate  返回值类型    代理名 （参数）;
        // 注意没有  {} 大括号的实现体！！！ 并且代理变量的 返回值类型和 参数要与被代理的对象属于一一对应。
        // ******定义代理变量   访问修饰符  delegate  返回值类型  代理类名 （参数）
        
        public delegate void Writetobox(char ch);

        //紧接着 用刚生成的代理变量， 生成一个对象，不做赋值。
        // 就好像用int float  double  一样，
        //******** 声明 代理变量名    访问修饰符    代理类名   代理变量
        private Writetobox writetobox;
      
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            if (checkBox1.Checked == true)
            {
                textBox1.Clear();
                textBox1.Refresh();
                // 调用方法WriteRichTextBox1想文本区1写入文字
                //this.WriteTextBox1();
                // ******实例化 代理变量       代理变量名 =  new  代理类名 （方法）   
                writetobox=new  Writetobox(WriteTextBox1);

                // *****将代理变量 作为参数传递给其它方法
                writeText(writetobox);

                textBox3.Focus();
                textBox3.SelectAll();
            }
            if (checkBox2.Checked == true)
            {
                textBox2.Clear();
                textBox2.Refresh();
                // 调用方法WriteRichTextBox2想文本区2写入文字
                //this.WriteTextBox2();
                 writetobox=new  Writetobox(WriteTextBox2);
                writeText(writetobox);
                textBox3.Focus();
                textBox3.SelectAll();
            }
        }

        
        //****** 在其它方法中定义 参数 是一个代理类型
        private void writeText(Writetobox writetobox)
        {
            string data = textBox3.Text;
            for (int i = 0; i < data.Length; i++)
            {
                // *********在其它方法中 使用代理名（参数）；使用该代理。
                //*********代理其实就是所代表方法的一种昵称或一种绰号。
                writetobox(data[i]);
                //间歇延时
                //  DateTime now = DateTime.Now;
                //while (now.AddSeconds(1) > DateTime.Now)
                //  { }
            }
        }

        private void WriteTextBox1(char ch)
        {
            
                textBox1.AppendText(ch.ToString());
               
            }

          private void WriteTextBox2(char ch)
        {
            
                textBox2.AppendText(ch.ToString());
               
            }
        }
    }

