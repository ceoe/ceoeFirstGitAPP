using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    //byte num1 = byte.Parse(txtInput1.Text);
               
            //    //byte  num2 = byte.Parse(txtInput2.Text);
            //    //byte num3 = num1 + num2;


            //    txtOutput.Text = num3.ToString();

            //}

           

            try
            {
                checked
                {
                    byte aaa = byte.MaxValue;

                    MessageBox.Show(aaa.ToString());

                    aaa++;

                    MessageBox.Show("超出byte值类型！Now aaa is  "+aaa.ToString());

                }
            }
     
             
            catch (OverflowException oe)
            {

                MessageBox.Show("数据输入的值太大了！" + oe.Message);
                
            }

            catch (FormatException  fe)
            {
                MessageBox.Show("数据输入格式不正确！" + fe.Message);
 
            }

           


        }

   
    }
}
