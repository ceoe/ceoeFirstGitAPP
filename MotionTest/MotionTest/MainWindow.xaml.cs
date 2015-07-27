using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace MotionTest
{

    public  class PointF
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MotionSet motionSet;
        private AxisParaSet axisparaset;
        private bool isInit = false;
        UInt16 nCard = 0;

        struct  PointF
        {
            public double x;
            public  double y;
        }
     

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTestLoad_Click(object sender, RoutedEventArgs e)
        {
            motionSet = new MotionSet(@".\Motion_set.txt");

            axisparaset = new AxisParaSet(@".\hardware_set.txt");

            if (motionSet.GroupParametersSetses != null)
            {
                this.lsvMotionSet.ItemsSource = motionSet.GroupParametersSetses;
                this.dgAxisPara.ItemsSource = motionSet.GroupParametersSetses;
                this.tvAxisConfigList.ItemsSource = axisparaset.ListAxisParametersSets;
                this.grdata_GlobalMotionset.DataContext = axisparaset;
                CheckCard();
                if (!isInit)
                {
                    MessageBox.Show("Error Can not find DMC Card!");
                }
                
            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void CheckCard()
        {
            // DMC2610卡的函数调用                       
          
            nCard = Dmc2610.d2610_board_init();//'为控制卡分配系统资源，并初始化控制卡。
            if (nCard <= 0) //DMC1000控制卡初始化
            {
                isInit = false;
            }
            else
            {
                isInit = true;
            }
        }
    }
}