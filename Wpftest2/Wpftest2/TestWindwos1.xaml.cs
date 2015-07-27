using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Baml2006;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpftest2
{
    /// <summary>
    /// TestWindwos1.xaml 的交互逻辑
    /// </summary>
    /// 
    /// 
    /// 
    class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        { }

        public DateTime DateTime { get; set; }
    }

    public class ReportTimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime",
            RoutingStrategy.Tunnel, typeof(EventHandler<ReportTimeEventArgs>), typeof(ReportTimeButton));

        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            var args = new ReportTimeEventArgs(ReportTimeEvent, this) { DateTime = DateTime.Now };
            this.RaiseEvent(args);
        }
    }
    
    public partial class TestWindwos1 : Window

    {

         void ReportTimeHandle(object sender, ReportTimeEventArgs routedEventArgs)
        {
            FrameworkElement element = sender as FrameworkElement;
            string recordtime = routedEventArgs.DateTime.ToLongTimeString();
            string content = string.Format("{0} Arrival to {1}", recordtime, element.Name);

            lsb_re.Items.Add(content);
             if (element==this.gr4)
             {
                 routedEventArgs.Handled = true;
             }

        }

        private void innbuttonClicked(object sender, RoutedEventArgs eventArgs)
        {
            MessageBox.Show(eventArgs.ToString() + "\r\n" + "LogicTree Start Point is :" + (eventArgs.Source as FrameworkElement).ToString() +
                "\r\n" + "VisualTree Start Point is :" + (eventArgs.OriginalSource as FrameworkElement).ToString());
        }


        List<Student> stuList = new List<Student>()
            {
                new Student(){Id = 001,Name = "Tom",Age = 18},
                new Student(){Id = 002,Name = "Jim",Age = 19},
                new Student(){Id = 003,Name = "Karry",Age = 28},
                new Student(){Id = 004,Name = "Jack",Age = 26},
                new Student(){Id = 005,Name = "Andy",Age = 22},
                new Student(){Id = 006,Name = "Kitty",Age = 20},
                new Student(){Id = 007,Name = "Jane",Age = 17},
            };

        Animal aa = new Animal();
        public TestWindwos1()
        {
            InitializeComponent();
            SetMultiBinding();

            this.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(this.innbuttonClicked));

           this.GridA.AddHandler(ButtonBase.ClickEvent,new RoutedEventHandler(this.LeftButtonClicked));
            
            //为ListBoxStudent 设定一个Binding
            this.ListBoxStudent.ItemsSource = stuList;


            this.mytestUserControlslist.lsViewFromSource.ItemsSource = stuList;
            //this.mytestUserControlslist.SetBinding(ItemsControl.ItemsSourceProperty, new Binding());

            // this.lsViewFromSource.DataContext = stuList;
            //this.lsViewFromSource.SetBinding(ItemsControl.ItemsSourceProperty, new Binding());


            //this.ListBoxStudent.DisplayMemberPath = "Name";


            //this.rectPart.SetBinding(Canvas.LeftProperty, new Binding("Value") {Source = this.sliderleft});
            //this.rectPart.SetBinding(Canvas.TopProperty, new Binding("Value") {Source = this.slidertop});

            //为TextBoxStudent 设定一个Binding
            Binding binding = new Binding("SelectedItem.Id") { Source = this.ListBoxStudent };
           this.tbStudentID.SetBinding(TextBox.TextProperty, binding);


            ObjectDataProvider odp = new ObjectDataProvider();
            odp.ObjectInstance = new MyCalculator();
            odp.MethodName = "Add";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");

            Binding bindingToArg1 = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            Binding bindingToArg2 = new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            Binding bindingToResult=new Binding("."){Source = odp};

            this.tbarg1.SetBinding(TextBox.TextProperty, bindingToArg1);
            this.tbarg2.SetBinding(TextBox.TextProperty, bindingToArg2);
            this.tbkResult.SetBinding(TextBlock.TextProperty, bindingToResult);

            //this.tbkResult.Text = odp.Data.ToString();

            #region tb1.TextProperty 依赖属性绑定到sliderbar1.Value上，并且为tb1的Binding 功能中设置 PropertyChanged 为触发源，
            //并定义一个派生于ValidataionRule ：RangeValidataionRule 子类对象实例 作为 检测 从（Source）sliderbar1.Value传入至tb1.TextProperty 的有效性校验方法,并且已经设置ValidatesOnTargetUpdated属性为打开状态
            //RangeValidataionRule子类重写了Validate 方法

            RangeValidataionRule rvr = new RangeValidataionRule() { ValidatesOnTargetUpdated = true };

            Binding tb1Binding = new Binding("Value")
            {
                Source = this.Sliderbar1,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                // NotifyOnValidationError = true
            };
            tb1Binding.ValidationRules.Add(rvr);
            //tb1Binding.NotifyOnSourceUpdated = true;

            this.tb1.SetBinding(TextBox.TextProperty, tb1Binding);

            //this.tb1.AddHandler(Validation.ErrorEvent,new RoutedEventHandler(ValidationError));
            // this.tb1.AddHandler(ValidationResult.ValidResult,new RoutedEventHandler(ValidationError));
            //this.tb1.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(ValidationMsg));

            this.tb1.AddHandler(Validation.ErrorEvent,new RoutedEventHandler(ValidationError));



            #endregion

            
         
            aa.SetBinding(Animal.KindofNameProperty, new Binding("Text") { Source = tbinput });

            tbOuput.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = aa });
            //tbOuput.SetBinding(TextBox.TextProperty, new Binding("Text") { Source = tbinput });
            tbkforaminal.SetBinding(TextBlock.TextProperty, new Binding("Name") {Source = aa});
           
        }

        private void LeftButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.ToString() + "\r\n" + (e.OriginalSource as FrameworkElement).ToString());
        }

        private void SetMultiBinding()
        {
            Binding b1=new Binding("Text"){Source = this.tb2};
            Binding b2=new Binding("Text"){Source = this.tb3};
            Binding b3=new Binding("Text"){Source = this.tb4};
            Binding b4=new Binding("Text"){Source = this.tb5};

            MultiBinding mb=new MultiBinding(){Mode = BindingMode.OneWay};
            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);

            mb.Converter = new LoginMultiBindingConverter();

            this.btnLogin.SetBinding(IsEnabledProperty, mb);
        }

        private void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.tb1).Count>0)
            {
                this.tb1.ToolTip = Validation.GetErrors(this.tb1)[0].ErrorContent.ToString();
            }
        }
        private void ValidationMsg(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.tb1).Count > 0)
            {
                this.tb1.ToolTip = Validation.GetErrors(this.tb1)[0].ErrorContent.ToString();
            }
            else
            {
                if (ValidationResult.ValidResult.ErrorContent!=null)
                {
                    this.tb1.ToolTip = ValidationResult.ValidResult.ErrorContent.ToString();
                }
            }
        }

        private void Testbutton_Click(object sender, RoutedEventArgs e)
        {
            Button btn1 = sender as Button;
            DependencyObject level1 = VisualTreeHelper.GetParent(btn1);
            DependencyObject level2 = VisualTreeHelper.GetParent(level1);
            DependencyObject level3 = VisualTreeHelper.GetParent(level2);

            MessageBox.Show(level3.GetType().ToString());
        }

        private void BtnTestkey2_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn1 = sender as Button;
            DependencyObject level1 = VisualTreeHelper.GetParent(btn1);
            DependencyObject level2 = VisualTreeHelper.GetParent(level1);
            DependencyObject level3 = VisualTreeHelper.GetParent(level2);

            MessageBox.Show(level3.GetType().ToString());
        }

        private void CheckBoxTim_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox1 = sender as CheckBox;
            DependencyObject level1 = VisualTreeHelper.GetParent(checkBox1);
            DependencyObject level2 = VisualTreeHelper.GetParent(level1);
            DependencyObject level3 = VisualTreeHelper.GetParent(level2);

            MessageBox.Show(level3.GetType().ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dt = new DataTable();

            #region Read From DataBase

            string connectionString = @"Data Source=.\AOI;Initial Catalog=aoi5sys;Integrated Security=True";

            var connection = new SqlConnection(connectionString);
            //string sql=@"SELECT * FROM AXIS_PARAM WHERE NAME='#1HOST'";
            string sql = @"SELECT [NAME]
      ,[AXIS]
      ,[AXIS_ID]
      ,[PULSE_MODE]
      ,[MAX_DIST]
      ,[ORG_POSITION]
      ,[RESET_SPEED]
      ,[START_SPEED]
      ,[MAX_SPEED]
      ,[ADD_SPEED]
      ,[ADD_MODE]
      ,[PULSE_PER_MM]
  FROM [aoi5sys].[dbo].[AXIS_PARAM]
  WHERE	NAME='#1HOST'";
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataReader dataReader = cmd.ExecuteReader();

                dt.Load(dataReader);

            }

            catch (DataException dataException)
            {
                MessageBox.Show(dataException.ToString());
            }
            finally
            {
                connection.Close();
            }
            #endregion

            if (dt != null)
            {
                this.lsViewDataBase.DataContext = dt;
                this.lsViewDataBase.SetBinding(ItemsControl.ItemsSourceProperty, new Binding());

                this.lsViewFromSource.DataContext = stuList;
                this.lsViewFromSource.SetBinding(ItemsControl.ItemsSourceProperty, new Binding());
            }
        }



        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //ObjectDataProvider odp=new ObjectDataProvider();
            //odp.ObjectInstance = new MyCalculator();
            //odp.MethodName = "Add";
            //odp.MethodParameters.Add(this.tbarg1.Text);
            //odp.MethodParameters.Add(this.tbarg2.Text);
            //this.tbkResult.Text = odp.Data.ToString();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> PlaneList = new List<Plane>()
            {
                new Plane(){Category = Category.Bomber,Name="B-1",State = State.Unknown},
                new Plane(){Category = Category.Bomber,Name="B-2",State = State.Unknown},
                new Plane(){Category = Category.Fighter,Name="F-22",State = State.Unknown},
                new Plane(){Category = Category.Fighter,Name="Su-47",State = State.Unknown},
                new Plane(){Category = Category.Bomber,Name="B-52",State = State.Unknown},
                new Plane(){Category = Category.Fighter,Name="J-10",State = State.Unknown},
            };
            this.lsbcnv.ItemsSource = PlaneList;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb=new StringBuilder();
            foreach (Plane p in lsbcnv.Items)
            {
                sb.AppendLine(string.Format("Category={0},Name={1},State={2}", p.Category, p.Name, p.State));
            }
            File.WriteAllText(@"D:\PLANELIST.TXT",sb.ToString());
        }


        private void btnBindingtoClass_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBox.Show(this.aa.KindofName);
        }

        private void btnTestadp_Click(object sender, RoutedEventArgs e)
        {
            Personal aPersonal=new Personal();
            School.SetGrade(aPersonal,101);
            int grade = School.GetGrade(aPersonal);
            MessageBox.Show(grade.ToString());
        }
    }

    public enum Category
    {
        Bomber,
        Fighter
    }

    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class School : DependencyObject
    {


        public static int GetGrade(DependencyObject obj)
        {
            return (int)obj.GetValue(GradeProperty);
        }

        public static void SetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Grade.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new UIPropertyMetadata(0));

        
    }

    public class Personal : DependencyObject
    {
        
    }

    public class Plane
    {
        public Category Category { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
    }

    public class CategoryToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Category c = (Category) value;
            switch (c)
            {
                case Category.Bomber:
                    return @"\Icons\button-highlight.png";
                case Category.Fighter:
                    return @"\Icons\Notes_btn-back-static.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StateToNullableBoolConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            State s = (State) value;
            switch (s)
            {
                    case State.Available:
                    return true;
                    case State.Locked:
                    return false;
                    case State.Unknown:
                    default:
                    return null;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? nb = (bool?) value;
            switch (nb)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                case null:
                default:
                    return State.Unknown;
            }
        }
    }


    public class MyCalculator
    {
        public string Add(string arg1, string arg2)
        {
            double x, y, z;
           // x = y = z = 0;
            if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
            {
                z = x + y;
                return z.ToString();
            }
            else
            {
                return "Input Error!!";
            }
        }
    }

    public class RangeValidataionRule : ValidationRule
    {
        //Validate 方法带2个参数，一个是value(被封装的Binding  Path=Value  {Source= slider})被包装成Object
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double d;
            if (double.TryParse(value.ToString(),out d))
            {
                if (d>=0&&d<=100)
                {
                    return new ValidationResult(true,"OK");
                }
            }
            return new ValidationResult(false,"Vaildation Failed");
        }
    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        
    }

    public class Animal : DependencyObject
    {
        public string KindofName
        {
            get { return (string)GetValue(KindofNameProperty); }
            set { SetValue(KindofNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KindofName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KindofNameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Animal));

        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }
    internal class Testbutton : Button
    {
        public Type UserWindowsType { get; set; }

        protected override void OnClick()
        {
            //base.OnClick();
            Window ws = Activator.CreateInstance(this.UserWindowsType) as Window;
            if (ws != null)
            {
                ws.ShowDialog();
            }
        }
    }
}
