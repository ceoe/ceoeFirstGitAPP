using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormElementConversionDEMO1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control  c in this.Controls)
            {
                listView1.Items.Add(c.Name.ToString()+"\r\n");
                Control c1 = c as Button;
                if (c1!=null)
                {
                    c1.Text = "kkaa";
                }
            }
        }
    }
}
