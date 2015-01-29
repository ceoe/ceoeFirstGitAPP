using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsBntClickEventdemo1.Properties;

namespace FormsBntClickEventdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Form1_btn1_Click_);
            MessageBox.Show(e.ToString());
            btnClick += ShowbtnName;
            btnClick(sender);
            btnClick -= ShowbtnName;

         }


        private delegate void ShowName(object  sender);

        private event ShowName btnClick;

        private void ShowbtnName(object sender)
        {
            var btn = sender as Button;
            if (btn!=null)
            {
                MessageBox.Show(Resources.Form1_ShowbtnName_This_buttom_name_is__ + btn.Name);
                
            }
        }

    }
}
