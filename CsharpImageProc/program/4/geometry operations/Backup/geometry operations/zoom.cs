using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geometry_operations
{
    public partial class zoom : Form
    {
        public zoom()
        {
            InitializeComponent();
        }

        private void startZoom_Click(object sender, EventArgs e)
        {
            if (xZoom.Text == "0" || yZoom.Text == "0")
            {
                MessageBox.Show("缩放量不能为0！\n请重新正确填写。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool GetNearOrBil
        {
            get
            {
                return nearestNeigh.Checked;
            }
        }

        public string GetXZoom
        {
            get
            {
                return xZoom.Text;
            }
        }

        public string GetYZoom
        {
            get
            {
                return yZoom.Text;
            }
        }
    }
}