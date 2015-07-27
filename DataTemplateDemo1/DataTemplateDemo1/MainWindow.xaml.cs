using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DataTemplateDemo1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initialCarList();
           }

        private void initialCarList()
        {
            List<Car> carList=new List<Car>()
            {
                new Car(){AutoMaker ="Bentley",Name="Bentley",Year = "1990",TopSpeed = "230"},
                  new Car(){AutoMaker ="Benz",Name="Benz",Year = "1992",TopSpeed = "230"},
                    new Car(){AutoMaker ="BMW",Name="BMW",Year = "1993",TopSpeed = "230"},
                      new Car(){AutoMaker ="Ferrari",Name="Ferrari",Year = "1994",TopSpeed = "230"},
                        new Car(){AutoMaker ="Lamborghini",Name="Lamborghini",Year = "1995",TopSpeed = "230"},
                          new Car(){AutoMaker ="Maserati",Name="Maserati",Year = "1996",TopSpeed = "230"},
                            new Car(){AutoMaker ="Maybach",Name="Maybach",Year = "1997",TopSpeed = "230"},
                              new Car(){AutoMaker ="Porsche",Name="Porsche",Year = "1998",TopSpeed = "230"},
                                new Car(){AutoMaker ="RollsRoyce",Name="RollsRoyce",Year = "1999",TopSpeed = "230"}
            };

            this.listBoxCars.ItemsSource = carList;
        }

    }

    public class Car
    {
        public string AutoMaker { get; set; }
        public string Name { get; set; }
        public string Year   { get; set; }
        public string TopSpeed { get; set; }          
   
    }

    public class DeliveryImageUri
    {
        public Uri imgstr { get; set; }
    }

    public class AutoMakerTologoPathConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = string.Format(@"/Resource/logos/{0}.jpg", (string)value);
          
            return new BitmapImage(new Uri(uriStr, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NameToPhotoPathConvert:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = string.Format(@"/Resource/Images/{0}.jpg", (string)value);
            return new BitmapImage(new Uri(uriStr, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedItemToPhotoPathConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null)
            {
                Car aCar = value as Car;
                string uristr = string.Format(@"/Resource/Images/{0}.jpg", aCar.Name);
                return new BitmapImage(new Uri(uristr,UriKind.RelativeOrAbsolute));
            }
            else
            {
                string uriStr = string.Format(@"/Resource/Images/Porsche.jpg");
                return new BitmapImage(new Uri(uriStr,UriKind.RelativeOrAbsolute));
            }

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
