using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace startFormModelessFormsDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmAdvert frmAdvert=new FrmAdvert();
            try
            {
                frmAdvert.ShowDialog();
            }
            finally
            {
                frmAdvert.Dispose();
            }

            FrmLogin  frmLogin=new FrmLogin();
            DialogResult dr;
            try
            {
               dr= frmLogin.ShowDialog();
            }
            finally
            {
                frmLogin.Dispose();
            }
            if (dr==DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            
        }
    }
}
