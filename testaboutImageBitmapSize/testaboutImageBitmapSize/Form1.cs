using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testaboutImageBitmapSize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int increasment = 1000;
            //for (int i = 15000; i < 15001; i++)
            //{
            int i;
            i = Convert.ToInt32(textBox1.Text);
            Bitmap bmp = null;
            Bitmap bmp2 = null;
            Bitmap bmp3 = null;
            Bitmap bmp4 = null;
            byte[,] testBytes, testBytes2;
            byte[] testBytes3,testBytes4,testBytes5,testBytes6;
            Int64 k = 0;
            
                try
                {
                   bmp = new Bitmap(i, i, PixelFormat.Format1bppIndexed);
                   // bmp2 = new Bitmap(i, i, PixelFormat.Format8bppIndexed);
                  //  bmp3 = new Bitmap(i, i, PixelFormat.Format8bppIndexed);
                  //  bmp4 = new Bitmap(i, i, PixelFormat.Format8bppIndexed);
                   // testBytes=new byte[i,i];
                    k = i*i;
                    //testBytes3=new byte[2124000000];
                    //testBytes4=new byte[2124000000];
                    //testBytes5= new byte[2124000000];
                   // testBytes6 = new byte[2124000000];

                  //  testBytes2=new byte[i,i];
                  //  testBytes.Initialize();
                  //  testBytes2.Initialize();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(i.ToString()+"\r\n"+ex.Message);
                  
                }
                finally
                {
                    bmp = null;
                    bmp2 = null;
                    bmp3 = null;
                    bmp4 = null;
                   GC.Collect();
                }

           // }

        }
    }
}
