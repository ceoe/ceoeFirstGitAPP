using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace ControlTemplateDemo1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //定时器  
        private DispatcherTimer mDataTimer = null;  
        //定时器执行次数  
        private long timerExeCount = 0;

        DateTime s1;
        DateTime s2;  

        public MainWindow()
        {
            InitializeComponent();
             InitTimer();  
        }

         private void InitTimer()  
        {  
            if (mDataTimer == null)  
            {  
                mDataTimer = new DispatcherTimer();  
                mDataTimer.Tick += new EventHandler(DataTimer_Tick);  
                mDataTimer.Interval = TimeSpan.FromSeconds(1);  
            }  
        }  
  
        private void DataTimer_Tick(object sender, EventArgs e)  
        {  
            s2 = DateTime.Now;


            this.tb2.Text = s2.ToString();
            this.tb3.Text = string.Format(string.Format("{0:R}",s2));

            //TimeSpan s = s2 - s1;
            //Debug.WriteLine("==========定时器第 " + timerExeCount + " 次执行, 耗时：" + s.TotalMilliseconds + "=========");
            //Debug.WriteLine("++++++++++开始休眠第 " + timerExeCount + " 次执行+++++++++");
            //s1 = DateTime.Now;
            ////System.Threading.Thread.Sleep(2000);  
            //for (int i = 0; i < 400; ++i)
            //{
            //    System.Threading.Thread.Sleep(10);
            //}
            //s2 = DateTime.Now;
            //TimeSpan t = s2 - s1;
            //Debug.WriteLine("----------结束休眠第 " + timerExeCount + " 次执行, 耗时：" + t.TotalMilliseconds + "---------");
            //s1 = DateTime.Now;
            //++timerExeCount;  
        }  

       
        public void StartTimer()  
        {  
            if (mDataTimer != null && mDataTimer.IsEnabled == false)  
            {  
                mDataTimer.Start();  
                s1 = DateTime.Now;  
            }  
        }  
  
        public void StopTimer()  
        {  
            if (mDataTimer != null && mDataTimer.IsEnabled == true)  
            {  
                mDataTimer.Stop();  
            }  
        }  
  
        private void btnStartTimer_Click(object sender, RoutedEventArgs e)  
        {  
            StartTimer();  
        }  
  
        private void btnStopTimer_Click(object sender, RoutedEventArgs e)  
        {  
            mDataTimer.Stop();  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["TileBrush"] = new SolidColorBrush(Colors.Orange);
            this.btntestbrush.Background = (Brush)this.Resources["TileBrush"];
        }

        
    }  
}

