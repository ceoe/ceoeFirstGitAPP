using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeSearchDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //teststing : 012#345#6789#AB#CD#EFGHIJKLMNOPQRSTUVWXYZ

        //teststring2:0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ
        private void btnFirstOrder_Click(object sender, EventArgs e)
        {
            BinaryTree bt=new BinaryTree(tbOrgStr.Text);
            if (!chkNotRecursion.Checked)
            {
                Stopwatch  sw=new Stopwatch();
                sw.Start();
                bt.PreOrder(bt.Head);
                sw.Stop();
                tbStrDeepSort.Text = bt.sb1.ToString();
                lbNormaltime.Text = sw.Elapsed + "s";
            }
            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                bt.PreOrederByStack();
                sw.Stop();
                tbNotCursionResult.Text = bt.sb1.ToString();
                lbNotCursionTime.Text = sw.Elapsed + "s";
            }
            
           
            
        }

        private void btnMidOrder_Click(object sender, EventArgs e)
        {
            BinaryTree bt = new BinaryTree(tbOrgStr.Text);

            if (!chkNotRecursion.Checked)
            {
                bt.MidOrder(bt.Head);
                tbStrDeepSort.Text = bt.sb1.ToString();
            }
            else
            {
                bt.MidOrederByStack();
                tbNotCursionResult.Text = bt.sb1.ToString();
            }
            
        }

        private void btnAfterOrder_Click(object sender, EventArgs e)
        {
            BinaryTree bt = new BinaryTree(tbOrgStr.Text);
            Stopwatch sw = new Stopwatch();

            if (!chkNotRecursion.Checked)
            {

              
                sw.Start();
                bt.LastOrder(bt.Head);
                sw.Stop();
                tbStrDeepSort.Text = bt.sb1.ToString();
                lbNormaltime.Text = sw.Elapsed + "s";
            }
            else
            {
               
                sw.Start();
                bt.LastOrederByPreOrderAndStack();
                sw.Stop();
                tbNotCursionResult.Text = bt.sb1.ToString();
                lbNotCursionTime.Text = sw.Elapsed + "s";
            }
           
        }

        private void btnWideSort_Click(object sender, EventArgs e)
        {
            BinaryTree bt = new BinaryTree(tbOrgStr.Text);
            bt.LevelOrder();
            tbStrWideOrder.Text = bt.sb1.ToString();
        }

        private void btnTestOddParity_Click(object sender, EventArgs e)
        {
            BinaryTree bt = new BinaryTree(tbOrgStr.Text);
            tbCursionList.Text = bt.testsb.ToString();
            //int max = Convert.ToInt32(tbOrgStr.Text);
            bt.GetallOddAdnParityNum(3, 23);
            tbStrWideOrder.Text = bt.sb1.ToString();
        }

       
    }
}
