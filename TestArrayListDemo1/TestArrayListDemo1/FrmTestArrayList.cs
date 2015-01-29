using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestArrayListDemo1
{
    public partial class FrmTestArryList : Form
    {
        public FrmTestArryList()
        {
            InitializeComponent();
        }

        private void btnTestArray_Click(object sender, EventArgs e)
        {
            int[] arr = new int[2];
            arr[0] = 5;
            arr[1] = 6;
            int result = arr[0]*arr[1];
            txtArray.Text = "Result is :    " + result;

        }

        private void TestArrayList_Click(object sender, EventArgs e)
        {
            ArrayList   arrL=new ArrayList(2);
            int kk=arrL.Add(5);
            kk=arrL.Add(6);
            int result = (int) arrL[0]*(int) arrL[1];

           txtArrayList.Text = "Result is :    " + result;


            List<int> arrList=new List<int>();
            arrList.Add(5);
            arrList.Add(8);
         
            result = arrList[0]*arrList[1];

            txtArrayList.Text += Environment.NewLine;
            txtArrayList.Text += "Result is :    " + result;
        } 



    }
}
