using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryArrayCalc
{
    public partial class Form1 : Form
    {
        int[] newArray;
        public Form1()
        {
            InitializeComponent();
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbNumofArray.Text = "10";


        }

        private void btnGen_Click(object sender, EventArgs e)
        {
             newArray=new int[Convert.ToInt32(tbNumofArray.Text)];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = i+1;
            }
        }

        private void btnSummary1_Click(object sender, EventArgs e)
        {

            foreach (int i in newArray)
            {
                tbResult.Text += Convert.ToString(i) + "\r\n";
            }
            tbResult.Text += "\r\n&&&&&&&&&&&&&&&&&&&&&&\r\n";
            tbResult.Text+= Convert.ToString(sum(newArray,newArray.Length));
            tbResult.Text += "\r\n&&&&&&&&&&&&&&&&&&&&&&\r\n";
            tbResult.Text += Convert.ToString(sumUseIteration(newArray));
            tbResult.Text += "\r\n&&&&&&&&&&&&&&&&&&&&&&\r\n";
        }

        private int sum(int[] testArray, int n)
        {
            return (n < 1) ? 0 : sum(testArray, n - 1) + testArray[n - 1];
        }

        private int sumUseIteration(int[] testArray)
        {
            int x=0;
            foreach (int i in testArray)
            {
                x += i;
            }
            return x;
        }
    }
}
