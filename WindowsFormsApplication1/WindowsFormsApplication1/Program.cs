using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parameters;


namespace WindowsFormsApplication1
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
            Application.Run(new Form1());

            
            //在静态的方法里面调用的方法只能是静态的方法。

            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        private static void DoWork()
        {   //todo
            int i = 0;
            Console.WriteLine(i.ToString());
            Pass.value(i);
        }
    }
}
