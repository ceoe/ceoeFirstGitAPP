using System;
using System.Windows.Forms;

namespace LCSTestDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            tbSubString.Text = CheckSubstring(tbString1.Text, tbString2.Text);
        }

        private string CheckSubstring(string str1, string str2)
        {
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
            {
                MessageBox.Show("请输入有效的字符！");
                return null;
            }


            var MatchTag = new int[str1.Length];
            int Maxnum = 0;
            int MaxLen = 0;

            for (int i = 0; i < str2.Length; i++)
            {
                for (int j = str1.Length-1; j >= 0; j--)
                {
                    if (str1[j]==str2[i])
                    {
                        if (i == 0 || j == 0)
                        {
                            MatchTag[j] = 1;
                        }
                        else
                        {
                            MatchTag[j] = MatchTag[j - 1] + 1;
                        }
                    }
                    else
                    {
                        MatchTag[j] = 0;
                    }

                    if (MatchTag[j] > MaxLen)
                    {
                        MaxLen = MatchTag[j];
                        Maxnum = j;
                    }
                }


              
            }

            if (Maxnum==0)
            {
                return null;
            }

            return str1.Substring(Maxnum - MaxLen + 1, MaxLen);
        }
    }
}