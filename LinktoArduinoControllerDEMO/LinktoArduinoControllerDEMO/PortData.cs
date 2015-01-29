using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinktoArduinoControllerDEMO


{
    //　注：1~9 串口的名称是 "COMx:",>9的以前用\\\\.\\COMx:比较好使，
    //但是在moxa 661设备上却不行，要用如下格式"$device\\COM" + PortNo.ToString() + "\0"，
    //也许这是moxa修改了相应的串口驱动。
    //
    class PortData
    {

        public event PortDataReceivedEventHandle Received;
        public event SerialErrorReceivedEventHandler Error;
        public SerialPort port;
        public bool ReceiveEventFlag = false;
        //接收事件是否有效 false表示有效
        public PortData(string sPortName,int baudrate, Parity parity)
        {
            port = new SerialPort(sPortName, baudrate, parity, 8, StopBits.One);
            port.RtsEnable = true;
            port.ReadTimeout = 3000;
            port.DataReceived +=
            new SerialDataReceivedEventHandler(DataReceived);
            port.ErrorReceived +=
            new SerialErrorReceivedEventHandler(ErrorEvent);
        }

        public PortData()
        {
            // TODO: Complete member initialization
        }
        ~PortData()
        {
            Close();
        }
       //串口操作之打开或关闭
        public void Open()
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
        }
        public void Close()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }

        //C#串口操作之数据发送
        public void SendData(byte[] data)
        {
            if (port.IsOpen)
            {
                port.Write(data, 0, data.Length);
            }
        }
        public void SendData(byte[] data,int offset, int count)
        {
            if (port.IsOpen)
            {
                port.Write(data, offset, count);
            }
        }
        //C#串口操作之发送命令
        public int SendCommand(byte[] SendData,ref  byte[] ReceiveData, int Overtime)
        {
            if (port.IsOpen)
            {
                ReceiveEventFlag = true;//关闭接收事件
                port.DiscardInBuffer(); //清空接收缓冲区
                port.Write(SendData, 0, SendData.Length);
                int num = 0, ret = 0;
                while (num++ < Overtime)
                {
                    if (port.BytesToRead >= ReceiveData.Length) break;
                    System.Threading.Thread.Sleep(1);
                }
                if (port.BytesToRead >= ReceiveData.Length)
                    ret = port.Read(ReceiveData, 0, ReceiveData.Length);
                ReceiveEventFlag = false;   //打开事件
                return ret;
            }
            return -1;
        }

        public void ErrorEvent(object sender,SerialErrorReceivedEventArgs e)
        {
            if (Error != null) Error(sender, e);
        }

        //C#串口操作之数据接收事件
        public void DataReceived(object sender,SerialDataReceivedEventArgs e)
        {
            //禁止接收事件时直接退出
            if (ReceiveEventFlag) return;
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            if (Received != null) Received(sender,new PortDataReciveEventArgs(data));
        }
        public bool IsOpen()
        {
            return port.IsOpen;
        }
    }


   //串口数据接收事件
    public delegate void PortDataReceivedEventHandle(object sender, PortDataReciveEventArgs e);

    public class PortDataReciveEventArgs : EventArgs
    {
        public PortDataReciveEventArgs()
        {
            this.data = null;
        }
        public PortDataReciveEventArgs(byte[] data)
        {
            this.data = data;
        }
        private byte[] data;
        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
