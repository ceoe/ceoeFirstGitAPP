using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitwiseDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ss;
            ss = "Output all of FontStyle:";
            ss += "\r\n";
            ss+=(int)FontStyle.Regular;
            ss += "\r\n";
            ss+=(int)FontStyle.Bold;
            ss += "\r\n";
                ss+=(int)FontStyle.Italic;
            ss += "\r\n";
                ss+=(int)FontStyle.Underline;
            ss += "\r\n";
            ss+=(int)FontStyle.Strikeout;

            textBox1.Text = ss;


        }

        private void chk_Click(object sender, EventArgs e)
        {
            FontStyle  fs=new FontStyle();

            fs = chkBlod.Checked ? fs |FontStyle.Bold : fs & ~FontStyle.Bold;

            fs = chkItalic.Checked ? fs | FontStyle.Italic : fs & ~FontStyle.Italic;
            fs = chkUnderLine.Checked ? fs | FontStyle.Underline : fs & ~FontStyle.Underline;
            fs = chkStrikeOut.Checked ? fs | FontStyle.Strikeout : fs & ~FontStyle.Strikeout;

            textBox1.Font=new Font(textBox1.Font,fs);

        }
    }
}
