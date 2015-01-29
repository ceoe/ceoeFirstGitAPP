using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateUsagedemo1
{
    public partial class Form1 : Form
    {
        public delegate void delegateaa(object sender, EventArgs e);
        public Form1()
        {
            InitializeComponent();
            button3.Click += AddClick;
            button3.Click += button1_Click;
            button3.Click += button2_Click;
            button3.Click += delegate { label1.Text +="\r\n "+ label1.Name; };
        }

        private void AddClick(object sender, EventArgs e)

        {
            label1.Text += "\r\n Buttn2 add a string  CC";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text += "\r\n Buttn2 add a string  BB";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text += "\r\n Buttn1 add a string  AA";
        }

        private void button3_Click(object sender, EventArgs e)
        {
    
       
        }

    }
}
