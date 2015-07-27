using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using System.Windows;


namespace Wpftest2
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human h = ((Human) FindResource("human")).Child;
            MessageBox.Show("##AND##  " + h.Name);

            var str = TryFindResource("welcomeString") as string;
            if (str != null)
            {
                TextBox1.Text = str;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double origValue = RaGradBrush1.GradientStops[2].Offset;

            for (int i = 30; i < 70; i++)
            {
                RaGradBrush1.GradientStops[2].Offset = (double) i/100;
                TextBox1.Text = RaGradBrush1.GradientStops[2].Offset.ToString();

                Thread.Sleep(100);
            }
            for (int i = 70; i > 30; i--)
            {
                RaGradBrush1.GradientStops[2].Offset = (double) i/100;
                TextBox1.Text = RaGradBrush1.GradientStops[2].Offset.ToString();
                Thread.Sleep(100);
            }
        }

        public class StringToHumanTypeConverter : UriTypeConverter
        {
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    var j = new Human();
                    j.Name = value as string;
                    return j;
                }
                return base.ConvertFrom(context, culture, value);
            }
        }
    }


    }