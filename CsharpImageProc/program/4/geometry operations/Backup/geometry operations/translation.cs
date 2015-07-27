using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geometry_operations
{
    public partial class translation : Form
    {
        public translation()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetXOffset
        {
            get
            {
                return xOffset.Text;
            }
        }

        public string GetYOffset
        {
            get
            {
                return yOffset.Text;
            }
        }
    }
}