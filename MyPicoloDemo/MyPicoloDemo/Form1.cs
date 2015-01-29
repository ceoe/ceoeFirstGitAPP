using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euresys.MultiCam;


namespace MyPicoloDemo
{
    public partial class MainForm : Form
    {
        #region MyRegion
        //建立2个代理事件用于异步调用绘图功能  
        public delegate void PaintDelegate(Graphics g);
        //建立更新状态条代理
        public delegate void UpdateStatusBarDelegate(string text);

        private int FrameCount = 0;

        private DateTime time_start,time_end;

         private double FrameRate;


       
        //建立bitmap对象
        private Bitmap image = null;
        private Bitmap imageorg = null;
 
        //建立互斥类实例 在处理图像时用
        private static readonly Mutex imageMutex = new Mutex();

        //建立 MulitCam对象用于控制取得图像
        UInt32 channel;
        private bool channelactive;

        // MulitCam对象 包含采集缓存区
        private UInt32 currentSurface;

        //此处的回调变量必须要声明 ，它处于主线程中，是mainForm 类的成员
        MC.CALLBACK multiCamCallback;
 
        #endregion
       

        /// <summary>
        /// 此处放入需要设计的变量
        /// </summary>

//#################################################################
        //MainForm的默认构造函数
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            CheckForIllegalCrossThreadCalls = false;
            MessageBox.Show(@"该实例提供一个如何运用multiCam 类进行采集及状态显示！ 开始使用前请确认已经连接好相机！","示例程序描述" ,MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }

        //#################################################################

        private void Form1_Load(object sender, EventArgs e)
        {
            //示例程序开始 用try 来进行初始化
            try
            {
                //打开MultiDriver 
                MC.OpenDriver();

                //允许错误记录
                MC.SetParam(MC.CONFIGURATION,"Errorlog","error.log");

                //建立采集通道并使用第一个采集卡的第一个连接头
                MC.Create("CHANNEL",out channel);
                MC.SetParam(channel,"DriverIndex",0);
                MC.SetParam(channel, "Connector", "VID1");

                //选择视频标准
                MC.SetParam(channel,"CamFile","PAL");

                //设置像素颜色显示格式
                MC.SetParam(channel, "ColorFormat", "RGB24");


                //设置第一次采集的方式是触发的
                MC.SetParam(channel, "AcquisitionMode", "VIDEO");
                MC.SetParam(channel, "TrigMode", "IMMEDIATE");

                //设置后续采集的方式
                MC.SetParam(channel, "NextTrigMode","REPEAT");

                //设置采集的帧数
                MC.SetParam(channel, "SeqLength_Fr", MC.INDETERMINATE);

                //注册回调函数
               // 
                multiCamCallback = new MC.CALLBACK(MultiCamCallback);
                //注册回调函数时，使用主线程里面的成员字段，以防止在向非托管代码传递委托时，多次调用了回调函数，一些局部函数会被垃圾回收掉。
               MC.RegisterCallback(channel,multiCamCallback,channel);

                //允许信号适配于回调函数
                // 这里的三句类似允许中断产生回调的种类, 只有以下三种信号允许中断并由回调函数来处理,这样就可以显示出状态.
                MC.SetParam(channel,MC.SignalEnable+MC.SIG_SURFACE_PROCESSING,"ON");
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_ACQUISITION_FAILURE, "ON");
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_END_CHANNEL_ACTIVITY, "ON");
                channelactive = false;
                //在启动时延迟,为通道状态良好执行最小化采集序列
                MC.SetParam(channel,"ChannelState","READY");

            }
            catch (Euresys.MultiCamException exc)
                 {
                    //当在try catch 代码段中出现异常, 检索它们的描述情况,并显示在一个信息框中
                MessageBox.Show(exc.Message, "MultiCam Exception!");
                Close();
                }

        }

        //这里定义了回调函数
        private void MultiCamCallback(ref MC.SIGNALINFO signalInfo)
        {
            //回调函数 返回的MC.SIGNALINFO不同的信息代表着不同的状态.
            switch (signalInfo.Signal)
            {
               
                case MC.SIG_SURFACE_PROCESSING:
                    ProcessingCallback(signalInfo);
                    break;
                case MC.SIG_ACQUISITION_FAILURE:
                    AcqFailureCallback(signalInfo);
                    break;
                case MC.SIG_END_CHANNEL_ACTIVITY:
                    channelactive = false;
                    break;
                default:
                    throw new Euresys.MultiCamException("Unknown signal");
            }
        }

        private void ProcessingCallback(MC.SIGNALINFO signalInfo)
        {
            
            UInt32 currentChannel = (UInt32)signalInfo.Context;

            //toolStripStatusLabel1.Text = "正在努力处理开通中.....";

            UpdateStatusBar("正在努力处理开通中.....");
            currentSurface = signalInfo.SignalInfo;
            // + PicoloVideo Sample Program

            try
            {
                // Update the image with the acquired image buffer data 
               //读取采集卡中的图像缓冲区对象, 宽,高,缓冲区内存间隔,
                Int32 width, height, bufferPitch;
                IntPtr bufferAddress;
                MC.GetParam(currentChannel, "ImageSizeX", out width);
                MC.GetParam(currentChannel, "ImageSizeY", out height);
                MC.GetParam(currentChannel, "BufferPitch", out bufferPitch);
                MC.GetParam(currentSurface, "SurfaceAddr", out bufferAddress);

                try
                {
                   //这里为什么要WaitOne一次呢?
                    imageMutex.WaitOne();

                    //将采集卡采集到的一帧图像的宽,高, 内存大小,像素格式,图像基地址赋值给image 
                    imageorg= new Bitmap(width, height, bufferPitch, PixelFormat.Format24bppRgb, bufferAddress);
                    image = ScaleByPercent(imageorg,50);


                    /* Insert image analysis and processing code here */
                }
                finally
                {
                    imageMutex.ReleaseMutex();
                }

                // 检索帧率 Retrieve the frame rate
                Double frameRate_Hz;
                MC.GetParam(channel, "PerSecond_Fr", out frameRate_Hz);

                // 检索信道状态 Retrieve the channel state
                String channelState;
                MC.GetParam(channel, "ChannelState", out channelState);

                //将帧率及信道状态更新到状态条  Display frame rate and channel state
                UpdateStatusBar(String.Format("当前帧率为Frame Rate: {0:f2},  信道状态为Channel State: {1}", frameRate_Hz, channelState));

                //toolStripStatusLabel1.Text = String.Format("当前帧率为Frame Rate: {0:f2},  信道状态为Channel State: {1}", frameRate_Hz, channelState);

                // 显示新内存中image的图像 Display the new image
                this.BeginInvoke(new PaintDelegate(Redraw), new object[1] { CreateGraphics() });
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }
        }

        
        private void AcqFailureCallback(MC.SIGNALINFO signalInfo)
        {
            UInt32 currentChannel = (UInt32)signalInfo.Context;

            // + PicoloVideo Sample Program

            try
            {
                // Display frame rate and channel state

                UpdateStatusBar(String.Format("信道采集失败,可能相机无信号，当前通道的状态为：IDLE。"));
                //toolStripStatusLabel1.Text = String.Format("信道采集失败,可能相机无信号，当前通道的状态为：IDLE。");

                this.BeginInvoke(new PaintDelegate(Redraw), new object[1] { CreateGraphics() });
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }

            // - PicoloVideo Sample Program
        }
      
       private void Redraw(Graphics g)
        {
            try
            {
                imageMutex.WaitOne();
                if (image != null)
                {
                    //在窗体内绘制image图形
                    g.DrawImage(image, 0, 0);
                    g.DrawImage(image,image.Width+10,0);
                    g.DrawImage(image, 0, image.Height + 10);
                    g.DrawImage(image, image.Width + 10, image.Height+10);
                }

                UpdateStatusBar(toolStripStatusLabel1.Text);
                CalcFrameRate();
              

            }
            catch (System.Exception exc)
            {

                MessageBox.Show(exc.Message, "System Exception!");
            }
            finally
            {
                //image.Dispose();
                imageMutex.ReleaseMutex();
                
            }
        }

       private void MainForm_Closing(object sender,CancelEventArgs e)
        {
            try
            {
                stopToolStripMenuItem_Click(sender, e);
               
                //删除信道的使用
                if (channel != 0)
                {
                    MC.Delete(channel);
                    channel = 0;
                }
            }
            catch (Euresys.MultiCamException exc)
            {

                MessageBox.Show(exc.Message, "MultiCam Exception!");
            }
            
        }

        private void Go_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            //开始采集, 由激活的信道进行序列获取

            String channelState;
            FrameCount = 0;
            time_start = DateTime.Now;
            MC.GetParam(channel, "ChannelState", out channelState);
            if (channelState != "ACTIVE")
                MC.SetParam(channel, "ChannelState", "ACTIVE");
            Refresh();
            channelactive = true;

          
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //将取消的信道停止采集序列
            if (channel!=0)
                MC.SetParam(channel, "ChannelState", "IDLE");
            UpdateStatusBar(String.Format("已经停止采集，现在的帧率为:{0:f2},信道状态为: IDEL", 0));
            //{
            //    MC.SetParam(channel, " ChannelState", "IDLE");
            //}
            //    UpdateStatusBar(string.Format("现在的帧率为:{0:f2},信道状态为: IDEL", 0));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //释放MultiCam 资源
                MC.CloseDriver();
            }
            catch (Euresys.MultiCamException exc)
            {

                MessageBox.Show(exc.Message, "MultiCam Exception!");
            }
            
        }


        #region 计算采集的持续时间并得到帧率

        private void CalcFrameRate()
        {
            //計時結束 取得目前時間
            time_end = DateTime.Now;
           
            //後面的時間減前面的時間後 轉型成TimeSpan即可印出時間差

            TimeSpan span = time_end-time_start;
            double aliveSec = Math.Floor(span.TotalSeconds);

            

            if (aliveSec<=0)
            {
                FrameRate = FrameCount/1.0;
            }

            FrameRate = FrameCount / aliveSec;

            string rateinfo = string.Format(FrameRate.ToString());

            TLSTB_FrameRate.Text = FrameRate.ToString("f1") +  "      / TotalSecond is:" + aliveSec.ToString()+"sec.";

        }

        #endregion

        #region image 图像缩放方法

        public static Bitmap ScaleByPercent(Bitmap imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto); 
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        #endregion

        #region 多线程更新状态条方法


        private void UpdateStatusBar(string text)
        {
            
                toolStripStatusLabel1.Text = text;
                FrameCount++;
                TLSCountTB.Text = FrameCount.ToString();

        }

//        
        //多线程操作UI控件一定要使用LOCK  MONITOR  MUTEX 等方式同步线程，并使用CALLBACK ， BeginInvoke， 等方式调用
        //private void UpdateStatusBar(string text) //实际控件操作函数
//        {
//          if (toolStripStatusLabel1.label2.InvokeRequired) //用委托来操作
//             {
//                 SetState ss = new SetState(ThreadFunction);
//                 Invoke(ss,new object[]{x});
//                Console.WriteLine(Thread.CurrentThread.Name);
//            }
//            else //普通方式操作
//            {
//                label2.Text = x.ToString();
//                label2.Update();
//                Console.WriteLine(Thread.CurrentThread.Name);
//            }
//
//       }
            


       
        
        //private void SetText(string text)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (this.toolStripStatusLabel1.inInvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetText);
        //        this.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        this.textBox1.Text = text;
        //    }
        //}







        #endregion

    }
}
