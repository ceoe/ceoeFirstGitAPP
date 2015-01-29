using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinktoArduinoControllerDEMO
{
    public partial class Form1 : Form
    {
        //public static string comport = "COM18";
        //public System.IO.Ports.SerialPort serPort1 = new System.IO.Ports.SerialPort(comport);
        public string dstxt;
        public Form1()
        {
            
            InitializeComponent();
         
           //serPort1.Open(); 



        }

        private void trb1_Scroll(object sender, EventArgs e)
        {

        }

        private void btSend1_Click(object sender, EventArgs e)
        {

            string aa = this.txtb1.Text + "\n";
           serPort1.WriteLine(aa);




           this.txtb2.Text=serPort1.ReadLine();

          serPort1.Close();


        }

        private void btntest1_Click(object sender, EventArgs e)
        {
            byte [] inputmsg=new byte[10];
            PortData aa=new PortData("COM18",11520,Parity.None);
            aa.Open();
           PortDataReciveEventArgs  kk=new PortDataReciveEventArgs(inputmsg);
            dstxt = Convert.ToString(kk.Data);
            this.txtb2.Text += dstxt;
            aa.Close();
        }
    }
}
