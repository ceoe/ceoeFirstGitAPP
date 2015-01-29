using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinktoArduinoControllerDEMO
{
    class Comm
    {

        //声明一个委托事件，数据接收并读取。
        public delegate void EventHandle(byte[] readBuffer);
        public event EventHandle DataReceived;

        //开启一个线程来读取串口
        public SerialPort serialPort;
        Thread thread;
        // 用volatile修饰后的变量不允许有不同于“主”内存区域的变量拷贝。
        //一个变量经volatile修饰后在所有线程中必须是同步的；
        //任何线程中改变了它的值，所有其他线程立即获取到了相同的值。
        volatile bool _keepReading;

        //Comm的构造函数
        public Comm()
        {
            serialPort = new SerialPort();
            thread = null;
            _keepReading = false;
        }

      // IsOpen 是一个布尔字段 ，但其值似乎是通过结构体里面的get  方法得到的。
        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        // 开始读取串口的方法 StartReading
        private void StartReading()
        {
            if (!_keepReading)
            {
                _keepReading = true;
                thread = new Thread(new ThreadStart(ReadPort));
                thread.Start();
            }
        }

        // 停止读取串口的方法 StopReading
        private void StopReading()
        {
            if (_keepReading)
            {
                _keepReading = false;
                thread.Join();
                thread = null;
            }
        }

       
        //读端口 方法 并赋值给readBuffer，
        private void ReadPort()
        {
            while (_keepReading)
            {
              //端口若是打开
                if (serialPort.IsOpen)
                {
                  //将SerialPort.BytesToRead 属性字段读取赋值给count ，
                    int count = serialPort.BytesToRead;
                   // 将串口缓冲区 的数据 写入readBuffer 一维数组。
                    if (count > 0)
                    {
                        byte[] readBuffer = new byte[count];
                       // 这里这段的意思难道是防止线程读取COM口数据超时，导致程序假停
                        try
                        {
                            Application.DoEvents();
                            serialPort.Read(readBuffer, 0, count);
                            if (DataReceived != null)
                                DataReceived(readBuffer);
                            Thread.Sleep(100);
                        }
                        catch (TimeoutException)
                        {
                        }
                    }
                }
            }
        }

        public void Open()
        {
            Close();
            serialPort.Open();
            if (serialPort.IsOpen)
            {
                StartReading();
            }
            else
            {
                MessageBox.Show("串口打开失败！");
            }
        }

        public void Close()
        {
            StopReading();
            serialPort.Close();
        }

        public void WritePort(byte[] send, int offSet, int count)
        {
            if (IsOpen)
            {
                serialPort.Write(send, offSet, count);
            }
        }
    }
}
