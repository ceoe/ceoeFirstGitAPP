using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geometry_operations
{
    public partial class rotation : Form
    {
        public rotation()
        {
            InitializeComponent();
        }

        private void startRot_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetDegree
        {
            get
            {
                return degree.Text;
            }
        }
    }
}