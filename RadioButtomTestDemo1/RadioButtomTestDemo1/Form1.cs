using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioButtomTestDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rdoFlat_Click(object sender, EventArgs e)
        {
            rdoA.FlatStyle=FlatStyle.Flat;
            rdoB.FlatStyle=FlatStyle.Flat;
            rdoC.FlatStyle=FlatStyle.Flat;
        }

        private void rdoPopup_Click(object sender, EventArgs e)
        {
            //rdoA.FlatStyle = FlatStyle.Popup;
            //rdoB.FlatStyle = FlatStyle.Popup;
            //rdoC.FlatStyle = FlatStyle.Popup;
            foreach (Control  c in gbChooseValue.Controls)
            {
                if (c is RadioButton)
                {
                   ( (RadioButton )c).FlatStyle=FlatStyle.Popup;
                }
            }
        }

        private void rdoStandard_Click(object sender, EventArgs e)
        {
            FlatStyle fs=new FlatStyle();
            if (rdoStandard.Checked)
            {
                fs=FlatStyle.Standard;
            }
            else
            {
                if (rdoSystem.Checked)
                {
                    fs=FlatStyle.System;
                }
            }
            rdoA.FlatStyle = fs;
            rdoB.FlatStyle = fs;
            rdoC.FlatStyle = fs;
        }

        private void rdoB_Click(object sender, EventArgs e)
        {
            lbIndex.Text = "你选中了第  "+((Control)sender).Tag+" 项.";
            lbTextValue.Text = "名称是:" + ((Control)sender).Text;
        }

    }
}
