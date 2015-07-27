using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Net;
namespace Tank
{
    public partial class MailForm : Form
    {
        public MailForm()
        {
            InitializeComponent();
            txtMail.Text = txt;
            txtMail.SelectAll();
        }
        private string txt = "请在此输入你要说的话!谢谢你的宝贵建议!";
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        private void SendMail()
        {
            string from = "qq1989hn@163.com";
            string to = "qq1989hn@163.com";
            string subject = "Tank Bug提交";
            string body = txtMail.Text;
            string server = "smtp.163.com";
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient(server);
            client.Credentials = new NetworkCredential("qq1989hn", "qq1989");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("邮件发送成功!");
            this.Close();
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
