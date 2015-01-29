using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TestSerialPortPelcoDProctol
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

            // 取消线线程安全保护模式!
            //Control.CheckForIllegalCrossThreadCalls =false; 
        }

        //由于这些数据是需要在程序的各个方法中用到和传递的.所以放在Forms中进行声明

        PelcoD pelcod = new PelcoD();
        SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8);
        int m_dwDevNum = 0;
        byte addressin = Byte.Parse(Convert.ToString(0x01));
        byte speedin = Byte.Parse(Convert.ToString(0xff));
        byte[] messagesend;

        private bool isSendData=false;

        private void btnOpenCOM_Click(object sender, EventArgs e)
        {

            isSendData = true;

            Thread myThread = new Thread(new ThreadStart(SendordertoCom));

            myThread.Start();


            // 使用Join 方法的作用是在该线程没有结束前, 禁止再次调用此线程, 但是在线程中已经关闭了Button控件的功能,则无需使用该方法.
           // myThread.Join();

        }


        private void CheckBtnInThread()
        {
            string kk;
            if (!isSendData)
            {
                kk = "true";
            }
            else
            {
                 kk = "false";
            }
            btnOpenCOM.BeginInvoke(new System.EventHandler(UpdateUIbutton), kk);
        }

        private void UpdateUIbutton(object o,System.EventArgs e)
        {

            btnOpenCOM.Enabled = Boolean.Parse(o.ToString()); 
        }


        private void FillTextboxInThread()
        {
            string kk;
            if (!isSendData)
            {
                kk = "true";
            }
            else
            {
                kk = "false";
            }
            txtMsg.Invoke(new System.EventHandler(UpdateUITextBox), kk);
        }

        private void UpdateUITextBox(object o, System.EventArgs e)
        {

            txtMsg.Text=o.ToString();
            txtMsg.Focus();
            //txtMsg.Select(txtMsg.TextLength,0);
            txtMsg.SelectionStart = txtMsg.TextLength;
            //txtMsg.SelectionStart = 3000;
            txtMsg.ScrollToCaret();
        }




        private void SendordertoCom()
        {
            // 在线程中调用了 不属于该线程创建的控件, 这样系统其实会报错!!
           
            //btnOpenCOM.Enabled = false;

            //该线程调用了2个外部控件,一个是Btn控件, 一个是TextBox控件, 所以对这两个控件的修改操作应该通过MethodInvoker来进行
            //并且带了外部的变量进行判断.

            CheckBtnInThread();

            string TheadStore = "";
            for (int i = 0; i < 0x30; i++)
            {
                messagesend = pelcod.CameraStop(addressin);

                foreach (byte b in messagesend)
                {
                    TheadStore += String.Format("{0:X2}", b);
                    TheadStore += "  ";
                 }
                TheadStore += "\r\n";

                txtMsg.BeginInvoke(new System.EventHandler(UpdateUITextBox), TheadStore);
                serialPort.Open();
                serialPort.Write(messagesend, 0, 7);
                serialPort.Close();
                addressin++;
              
            }

            //btnOpenCOM.Enabled = true;

            isSendData = false;

            CheckBtnInThread();

        }


        private int scrollbarvalue;
       
        private void UserScrollbarSendordertoCom()
        {
            
            //该线程调用了2个外部控件,一个是Btn控件, 一个是TextBox控件, 所以对这两个控件的修改操作应该通过MethodInvoker来进行
            //并且带了外部的变量进行判断.

            string TheadStore1= "";
            for (int i = 0; i < 0x01; i++)
            {
                messagesend = pelcod.CameraStop(addressin);

                foreach (byte b in messagesend)
                {
                    TheadStore1 += String.Format("{0:X2}", b);
                    TheadStore1+= "  ";
                   
                }
                TheadStore1 += "\r\n";
                txtMsg.BeginInvoke(new System.EventHandler(UpdateUITextBox), TheadStore1);

                serialPort.Open();
                serialPort.Write(messagesend, 0, 7);
                serialPort.Close();
             }

        

        }

        private void hScrollBar1_Scroll(object sender, EventArgs e)
        {

            scrollbarvalue = hScrBarSendOrder.Value;
            addressin =Convert.ToByte(scrollbarvalue) ;


            Thread myThread1= new Thread(new ThreadStart(UserScrollbarSendordertoCom));

            myThread1.Start();
            myThread1.Join();
        }
    }
}
