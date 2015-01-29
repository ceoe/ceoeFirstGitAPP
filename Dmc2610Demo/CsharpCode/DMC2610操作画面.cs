using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 雷泰DMC2610运动控制卡CSharp2010程序
{
    public partial class DMC2610操作画面 : Form
    {
      
        public DMC2610操作画面()
        {
            InitializeComponent();
            
            // DMC2610卡的函数调用                       
            UInt16 nCard=0 ;
            nCard = Dmc2610.d2610_board_init();//'为控制卡分配系统资源，并初始化控制卡。
            if (nCard <= 0)//DMC1000控制卡初始化
            {
                MessageBox.Show("未找到DMC2610控制卡!", "警告");
                return;//退出当前程序  
            }         
        }
 private void DMC2610操作画面_FormClosed(object sender, FormClosedEventArgs e)
        {
            //But单轴停止.PerformClick();// '最简单又快的方法1，调用But单轴停止.的Click事件
            //Dmc2610.d2610_board_reset();//控制卡复位
            //Dmc2610.d2610_board_close(); //'关闭控制卡，释放系统资源。
        }
        const UInt16 X轴 = 0;//const定义X轴为常量整型数，定义常量时必须要赋值。先声明后使用，值类型范围
        const UInt16 Y轴 = 1;//const定义Y轴为常量整型数，定义常量时必须要赋值。先声明后使用，值类型范围
        const UInt16 Z轴 = 2;//const定义Z轴为常量整型数，定义常量时必须要赋值。先声明后使用，值类型范围
        const UInt16 U轴 = 3;//const定义U轴为常量整型数，定义常量时必须要赋值。先声明后使用，值类型范围
        const UInt16 A轴 = 4;//const定义A轴为常量整型数，定义常量时必须要赋值。先声明后使用，值类型范围
        const UInt16 B轴 = 5;//const定义B轴为常量整型数，定义常量时必须要赋值。先声明后使用，值类型范围
        UInt16[] nAxis轴号 = new UInt16[6];//定义Axis轴号的数组（6个数组）先声明后使用，引用类型范围
        Int32[] Dist位置设定 = new Int32[6];//定义Dist位置设定的数组（6个数组）先声明后使用，引用类型范围

private void Check电机方向选择_CheckedChanged(object sender, EventArgs e)
        {
            if (Check电机方向选择.Checked)//脉冲+负方向
            {
                Check电机方向选择.Text = "脉冲+负方向";
                for (UInt16 负方向选择 = 0; 负方向选择 < 4; 负方向选择++)
                    Dmc2610.d2610_set_pulse_outmode(负方向选择, 2);//'位置设定和读取,X\Y\Z轴清零   
            }
            else//脉冲+正方向
            {
                Check电机方向选择.Text = "脉冲+正方向";
                Dmc2610.d2610_set_pulse_outmode(0, 1);        // 'X脉冲输出设置函数
                Dmc2610.d2610_set_pulse_outmode(1, 1);     //    'Y脉冲输出设置函数
                Dmc2610.d2610_set_pulse_outmode(2, 1);     //    'Z脉冲输出设置函数 
            }


        }
        int Min_Vel起始速度,Max_Vel运行速度;       
        double Tacc加速时间,Tdec减速时间;       
        Int32 Sacc加速脉冲,Sdec减速脉冲;      
        int X轴运动检测,Y轴运动检测,Z轴运动检测;        
        int U轴运动检测,A轴运动检测,B轴运动检测;       
        int nNum插补轴数;
        UInt16 模式;
  
        private void Timer位置显示_Tick(object sender, EventArgs e)
        {            
                 Min_Vel起始速度 =Int32.Parse(Text起始速度.Text); //'起始速度设定
                 Max_Vel运行速度 = Int32.Parse(Text运行速度.Text);//'运行速度设定
                 Tacc加速时间 = Convert.ToDouble(Text加速时间.Text);//  '加速时间设定
                 Tdec减速时间 = Convert.ToDouble(Text减速时间.Text);//'减速时间设定
                 Sacc加速脉冲 = Convert.ToInt32(Text加速脉冲.Text);//'加速脉冲设定
                 Sdec减速脉冲 = Int32.Parse(Text减速脉冲.Text);//'减速脉冲设定
                 //#################X/Y/Z/U/A/B位置设定################
            Text0X轴当前位置.Text = Convert.ToString(Dmc2610.d2610_get_position(X轴));//  '位置设定"
            Text1Y轴当前位置.Text = Convert.ToString(Dmc2610.d2610_get_position(Y轴));//  '位置设定"
            Text2Z轴当前位置.Text = Convert.ToString(Dmc2610.d2610_get_position(Z轴));//  '位置设定"
            Text3U轴当前位置.Text = Convert.ToString(Dmc2610.d2610_get_position(U轴));//  '位置设定"
            Text4A轴当前位置.Text = Convert.ToString(Dmc2610.d2610_get_position(A轴));//  '位置设定"
            Text5B轴当前位置.Text = Convert.ToString(Dmc2610.d2610_get_position(B轴));//  '位置设定"
            //#####################X/Y/Z/U/A/B当前速度读取#######################
            Text3X轴速度.Text = Convert.ToString(Dmc2610.d2610_read_current_speed(X轴));//    'X轴当前速度读取
            Text4Y轴速度.Text = Convert.ToString(Dmc2610.d2610_read_current_speed(Y轴));//    'Y轴当前速度读取
            Text5Z轴速度.Text = Convert.ToString(Dmc2610.d2610_read_current_speed(Z轴));//    'Z轴当前速度读取
            Text6U轴速度.Text = Convert.ToString(Dmc2610.d2610_read_current_speed(U轴));//    'Z轴当前速度读取
            Text7A轴速度.Text = Convert.ToString(Dmc2610.d2610_read_current_speed(A轴));//    'A轴当前速度读取
            Text8B轴速度.Text = Convert.ToString(Dmc2610.d2610_read_current_speed(B轴));//    'B轴当前速度读取
            //*****************插补轴数选择及位置设置*************
            Text轴数.Text = Convert.ToString(nNum插补轴数);//插补轴数显示
            nNum插补轴数 = 0;
            if (CheckX轴.Checked)//X轴选种
            {
                nAxis轴号[nNum插补轴数] = X轴;  //   'X轴号存入
                Dist位置设定[nNum插补轴数] = ushort.Parse(TextX轴位置.Text); //'X轴位置设置（Int32.Parse字符串转整数数据类型【数据类型.Parse()方法】
                nNum插补轴数 = nNum插补轴数 + 1; //X轴号插补轴数存入
            }
            if (CheckY轴.Checked)//Y轴选种
            {
                nAxis轴号[nNum插补轴数] = Y轴;  //   'X轴号存入
                Dist位置设定[nNum插补轴数] = ushort.Parse(TextY轴位置.Text); //'Y轴位置设置ushort.Parse字符串转整数数据类型】
                nNum插补轴数 = nNum插补轴数 + 1;//Y轴号插补轴数存入
            }
            if (CheckZ轴.Checked)//Z轴选种
            {
                nAxis轴号[nNum插补轴数] = Z轴;  //   'Z轴号存入
                Dist位置设定[nNum插补轴数] = ushort.Parse(TextZ轴位置.Text); //'Z轴位置设置（ushort.Parse字符串转整数数据类型）
                nNum插补轴数 = nNum插补轴数 + 1;//Z轴号插补轴数存入
            }
            if (CheckU轴.Checked)//U轴选种
            {
                nAxis轴号[nNum插补轴数] = U轴;   // U轴号存入
                Dist位置设定[nNum插补轴数] = ushort.Parse(TextU轴位置.Text); //'U轴位置设置（ushort.Parse字符串转整数数据类型）
                nNum插补轴数 = nNum插补轴数 + 1;//U轴号插补轴数存入
            }
            if (CheckA轴.Checked)//A轴选种  
            {
                nAxis轴号[nNum插补轴数] = A轴;   // 'A轴号存入
                Dist位置设定[nNum插补轴数] = ushort.Parse(TextA轴位置.Text); //'A轴位置设置（ushort.Parse字符串转整数数据类型）
                nNum插补轴数 = nNum插补轴数 + 1;//U轴号插补轴数存入
            }
            if (CheckB轴.Checked)//B轴选种    
            {
                nAxis轴号[nNum插补轴数] = B轴;   //   B轴号存入
                Dist位置设定[nNum插补轴数] = ushort.Parse(TextB轴位置.Text); //'B轴位置设置（ushort.Parse字符串转整数数据类型）
                nNum插补轴数 = nNum插补轴数 + 1;//U轴号插补轴数存入
            }
            //*************运动模式转换**********************8
            if (radio相对模式.Checked)
            {
                模式 = 0; // '0相对位移，1绝对位移
            }
            else if (radio绝对模式.Checked)
            {
                模式 = 1; // '0相对位移，1绝对位移
            }
            //'**************X轴运动状态检测**********************
            string X检测 = "";
            X轴运动检测 = Dmc2610.d2610_check_done(X轴);      
            switch (X轴运动检测)//X轴运行状态信息显示
            {               
                case 0:
                    X检测 = "正在运行";
                    break;
                case 1:
                    X检测 = "脉冲输出停止";
                    break;              
            }
            string Y检测 = "";
            Y轴运动检测 = Dmc2610.d2610_check_done(Y轴);
            switch (Y轴运动检测)//Y轴运行状态信息显示
            {
                case 0:
                    Y检测 = "正在运行";
                    break;
                case 1:
                    Y检测 = "脉冲输出停止";
                    break;
            }
            string Z检测 = "";
            Z轴运动检测 = Dmc2610.d2610_check_done(Z轴);
            switch (Z轴运动检测)//Z轴运行状态信息显示
            {
                case 0:
                    Z检测 = "正在运行";
                    break;
                case 1:
                    Z检测 = "脉冲输出停止";
                    break;
            }
            string U检测 = "";
            U轴运动检测 = Dmc2610.d2610_check_done(U轴);
            switch (U轴运动检测)//U轴运行状态信息显示
            {
                case 0:
                    U检测 = "正在运行";
                    break;
                case 1:
                    U检测 = "脉冲输出停止";
                    break;
            }
            string A检测 = "";
           A轴运动检测 = Dmc2610.d2610_check_done(A轴);
            switch (A轴运动检测)//U轴运行状态信息显示
            {
                case 0:
                    A检测 = "正在运行";
                    break;
                case 1:
                    A检测 = "脉冲输出停止";
                    break;
            }
            string B检测 = "";
            B轴运动检测 = Dmc2610.d2610_check_done(B轴);
            switch (B轴运动检测)//U轴运行状态信息显示
            {
                case 0:
                    B检测 = "正在运行";
                    break;
                case 1:
                    B检测 = "脉冲输出停止";
                    break;
            }
            Lab运检测.Text = "X轴:" + X检测 + " " + "Y轴:" + Y检测 + " " + "Z轴:" + Z检测
                + " " + "U轴:" + U检测 + " " + "A轴:" + A检测 + " " + "B轴:" + B检测;  // 'X\Y\Z轴运行状态信息显示

            //*****************各轴缓冲检测**********************************
           int X缓冲检测 = Dmc2610.d2610_prebuff_status(X轴);
           switch (X缓冲检测)
           {
               case 0:
                   LaX缓冲.Text = "X缓冲:空";
                   break;
               case 1:
                   LaX缓冲.Text = "X缓冲:满";
                   break;
               default:
                   break;
           }
           int Y缓冲检测 = Dmc2610.d2610_prebuff_status(X轴);
           switch (Y缓冲检测)
           {
               case 0:
                   LaY缓冲.Text = "Y缓冲:空";
                   break;
               case 1:
                   LaY缓冲.Text = "Y缓冲:满";
                   break;
               default:
                   break;
           }
           int Z缓冲检测 = Dmc2610.d2610_prebuff_status(X轴);
           switch (Z缓冲检测)
           {
               case 0:
                   LaZ缓冲.Text = "Z缓冲:空";
                   break;
               case 1:
                   LaZ缓冲.Text = "Z缓冲:满";
                   break;
               default:
                   break;
           }
           int U缓冲检测 = Dmc2610.d2610_prebuff_status(X轴);
           switch (U缓冲检测)
           {
               case 0:
                   LaU缓冲.Text = "U缓冲:空";
                   break;
               case 1:
                   LaU缓冲.Text = "U缓冲:满";
                   break;
               default:
                   break;
           }
           int A缓冲检测 = Dmc2610.d2610_prebuff_status(A轴);
           switch (A缓冲检测)
           {
               case 0:
                   LaA缓冲.Text = "A缓冲:空";
                   break;
               case 1:
                   LaA缓冲.Text = "A缓冲:满";
                   break;
               default:
                   break;
           }
           int B缓冲检测 = Dmc2610.d2610_prebuff_status(B轴);
           switch (B缓冲检测)
           {
               case 0:
                   LaB缓冲.Text = "B缓冲:空";
                   break;
               case 1:
                   LaB缓冲.Text = "B缓冲:满";
                   break;
               default:
                   break;
           }

        //*******************输入输出读取写出*****************
           if (Dmc2610.d2610_read_inbit(0, 1) == 1 )
           {
               La输入1.Text = "La输入1:信号输入";//'读取指定控制卡的第一位输入口电平。
               Dmc2610.d2610_write_outbit(0, 1, 1);// '指定控制卡的第一位输出口置位为高电平。               
           }
           else
           {
               Dmc2610.d2610_write_outbit(0, 1, 0);// '指定控制卡的第一位输出口置位为低电平。
               La输入1.Text = "La输入1:信号断开";
           }

           if (Dmc2610.d2610_read_outbit(0, 1) == 1)//'读取指定控制卡的第一位输出口电平。
           {
                La1输出.Text = "La输出1:信号输出";
           }
           else
           {
               La1输出.Text = "La输出1:信号关闭";
           }

           if (Dmc2610.d2610_read_inbit(0, 2) == 1)//'读取指定控制卡的第一位输入口电平。
           {
               La输入2.Text = "La输入2:信号输入";
               Dmc2610.d2610_write_outbit(0, 2, 1);// '指定控制卡的第一位输出口置位为高电平。
           }
           else
           {
               Dmc2610.d2610_write_outbit(0, 2, 0) ;//'指定控制卡的第一位输出口置位为低电平。
               La输入2.Text = "La输入2:信号断开";
           }

           if (Dmc2610.d2610_read_inbit(0, 3) == 1)//'读取指定控制卡的第一位输入口电平。
           {
               La输入3.Text = "La输入3:信号输入";
               Dmc2610.d2610_write_outbit(0, 3, 1);// '指定控制卡的第一位输出口置位为高电平。
           }
           else
           {
               Dmc2610.d2610_write_outbit(0, 3, 0) ;//'指定控制卡的第一位输出口置位为低电平。
               La输入3.Text = "La输入3:信号断开";
           }
           if (Dmc2610.d2610_read_outbit(0, 3) == 1)//'读取指定控制卡的第一位输出口电平。
           {
               La3输出.Text = "La输出3:信号输出";
           }
           else
           {
               La3输出.Text = "La输出3:信号关闭";
           }
           //************ 实时在线改变速度**************
           变速数据 = HScrollBar1.Value;//'在线运行中改变指定单轴运行速度   
           la变速度.Text =Convert.ToString (变速数据);
           if (Check单轴变速.Checked & Radio单轴T形连续运动.Checked||Radio单轴S形连续运动.Checked)
           {              
               Dmc2610.d2610_change_speed(nAxis轴号[0], 变速数据);// '在线改变指定单轴的当前运行速度
           }
        }
        double 变速数据;
        private void But清零_Click(object sender, EventArgs e)
        {

            for (UInt16 i轴号 = 0; i轴号 < 6; i轴号++)
            {
                Dmc2610.d2610_set_position(i轴号, 0);// '位置设定和读取,X\Y\Z\U\A\B轴清零   
            }

        }

        private void But原点_Click(object sender, EventArgs e)
        {
            for (UInt16 原点轴号 = 0; 原点轴号 < 6; 原点轴号++)
            {
               Dmc2610.d2610_set_HOME_pin_logic(原点轴号, 0, 1);// '设定原点信号有效电平为低电平，滤波功能允许
               Dmc2610.d2610_config_home_mode(原点轴号, 0, 1);// '回原点模式，设定无原点接近信号
               Dmc2610.d2610_home_move(原点轴号, 1, 0);//    'X\Y\轴原点归零。 
            }
        }

        private void Timer1驱动器专用接口_Tick(object sender, EventArgs e)
        {
            // '*************读取X轴有关运动信号的状态，包含专用I/O状态*******************
            UInt16 X轴运动信号 = Dmc2610.d2610_axis_io_status(X轴);
            if ((X轴运动信号 & (UInt16)Math.Pow(2, 8)) == (UInt16)Math.Pow(2, 8))// 'X轴正在加速读取，以2进制方式检测即2的8次方
            {
                La8X轴FU.Text = "X轴正在加速ON";
                La8X轴FU.ForeColor = Color.Red;
            }
            else
            {
                La8X轴FU.Text = "8X轴FU加速OFF";
               La8X轴FU.ForeColor = Color.Brown;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 9)) == (UInt16)Math.Pow(2, 9))// 'X轴正在减速读取，以2进制方式检测即2的9次方
            {
                La9X轴FD.Text = "X轴正在减速ON";
                La9X轴FD.ForeColor = Color.Red;
            }
            else
            {
                La9X轴FD.Text = "9X轴FD减速OFF";
                La9X轴FD.ForeColor = Color.Blue;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 10)) == (UInt16)Math.Pow(2, 10))// 'X轴正在低速读取，以2进制方式检测即2的10次方
            {
                La10X轴FC.Text = "X轴正在恒速运行ON";
                La10X轴FC.ForeColor = Color.CadetBlue;
            }
            else
            {
                La10X轴FC.Text = "10X轴FC低速OFF";
                La10X轴FC.ForeColor = Color.Aqua;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 11)) == (UInt16)Math.Pow(2, 11))// 'X轴伺服报警信号读取，以2进制方式检测即2的11次方
            {
                La11X轴ALM.Text = "X轴伺服报警信号ON";
                La11X轴ALM.ForeColor = Color.Brown;
            }
            else
            {
                La11X轴ALM.Text = "11X轴ALM信号OFF";
                La11X轴ALM.ForeColor = Color.Blue;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 12)) == (UInt16)Math.Pow(2, 12))//'X轴+EL正限位读取，以2进制方式检测即2的12次方
            {
                La12X轴PEL.Text = "X轴+EL正限位信号ON";
                La12X轴PEL.ForeColor = Color.Yellow;
            }
            else
            {
                La12X轴PEL.Text = "12X轴+EL信号OFF";
                La12X轴PEL.ForeColor = Color.Black;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 13)) == (UInt16)Math.Pow(2, 13))// 'X轴-EL正限位读取，以2进制方式检测即2的13次方
            {
                La13X轴MEL.Text = "X轴-EL正限位信号ON";
               La13X轴MEL.ForeColor = Color.Blue;
            }
            else
            {
                La13X轴MEL.Text = "13X轴-EL信号OFF";
                La13X轴MEL.ForeColor = Color.Black;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 14)) == (UInt16)Math.Pow(2, 14))//X轴ORG原点读取，以2进制方式检测即2的14次方
            {
                La14X轴ORG.Text = "X轴ORG原点信号输入ON";
                La14X轴ORG.ForeColor = Color.Blue;
            }
            else
            {
                La14X轴ORG.Text = "14X轴ORG原点OFF";
                La14X轴ORG.ForeColor = Color.Brown;
            }

            if ((X轴运动信号 & (UInt16)Math.Pow(2, 15)) == (UInt16)Math.Pow(2, 15))//'X轴SD减速信号读取，以2进制方式检测即2的15次方
            {
                La15X轴SD.Text = "X轴SD信号输入ON";
                La15X轴SD.ForeColor = Color.Brown;
            }
            else
            {
                La15X轴SD.Text = "15X轴SD信号OFF";
                La15X轴SD.ForeColor = Color.Green;
            }
            // '##############读取X轴的主状态#########
            UInt16 X轴主状态 = Dmc2610.d2610_axis_status(X轴);
            if ((X轴主状态 & (UInt16)Math.Pow(2, 0)) == (UInt16)Math.Pow(2, 0))//'X轴X轴启动命令读取，以2进制方式检测即2的0次方
            {
                La0启动命令.Text = "X轴启动命令运行ON";
                La0启动命令.ForeColor = Color.Green;
            }
            else
            {
                La0启动命令.Text = "X轴启动命令OFF";
                La0启动命令.ForeColor = Color.Blue;
            }

            if ((X轴主状态 & (UInt16)Math.Pow(2, 1)) == (UInt16)Math.Pow(2, 1))//'X轴X轴脉冲输出读取，以2进制方式检测即2的1次方
            {
                La1X轴脉冲输出.Text = "X轴脉冲ON输出中";
            La1X轴脉冲输出.ForeColor = Color.Black;
            }
            else
            {
                La1X轴脉冲输出.Text = "X轴脉冲输出OFF";
                La1X轴脉冲输出.ForeColor = Color.Blue;
            }

            //'########读取X轴的外部信号状态**********
               uint X轴外部信号 = Dmc2610.d2610_get_rsts(X轴);
               if ((X轴外部信号 & (UInt16)Math.Pow(2, 7)) == (UInt16)Math.Pow(2, 7))//'X轴急停出读取，以2进制方式检测即2的7次方
            {
                La7X轴急停.Text = "X轴紧急停ON输入";
                La7X轴急停.ForeColor = Color.Black ;
            }
            else
            {
               La7X轴急停.Text = "X轴急停OFF";
               La7X轴急停.ForeColor = Color.Orchid;
            }

               if ((X轴外部信号 & (UInt16)Math.Pow(2, 8)) == (UInt16)Math.Pow(2, 8))//8X轴PCS信号读取，以2进制方式检测即2的8次方
               {
                   La8X轴PCS信号.Text = "X轴PCS信号ON输入";
                   La8X轴PCS信号.ForeColor = Color.Blue;
               }
               else
               {
                   La8X轴PCS信号.Text = "X轴PCS信号OFF";
                   La8X轴PCS信号.ForeColor = Color.Orange ;
               }

               if ((X轴外部信号 & (UInt16)Math.Pow(2, 9)) == (UInt16)Math.Pow(2, 9))//9X轴ERC信号读取，以2进制方式检测即2的9次方
               {
                  La9X轴ERC信号.Text = "X轴ERC信号ON";
                  La9X轴ERC信号.ForeColor = Color.Black;
               }
               else
               {
                   La9X轴ERC信号.Text = "9X轴ERC信号OFF";
                   La9X轴ERC信号.ForeColor = Color.Coral;
               }

               if ((X轴外部信号 & (UInt16)Math.Pow(2, 15)) == (UInt16)Math.Pow(2, 15))//15X轴ERS信号读取，以2进制方式检测即2的15次方
               {
                   La15X轴INP信号.Text = "X轴INP信号ON";
                   La15X轴INP信号.ForeColor = Color.Blue;
               }
               else
               {
                    La15X轴INP信号.Text = "15X轴INP信号OFF";
                    La15X轴INP信号.ForeColor = Color.Red;
               }

               if ((X轴外部信号 & (UInt16)Math.Pow(2, 16)) == (UInt16)Math.Pow(2, 16))//16X轴INP信号读取，以2进制方式检测即2的16次方
               {
                  La16X轴DIR信号.Text = "X轴正方向DIR信号";
                  La16X轴DIR信号.ForeColor = Color.Black;
               }
               else
               {
                    La16X轴DIR信号.Text = "X轴DIR负方向信号";
                    La16X轴DIR信号.ForeColor = Color.Crimson;
               }
            // '****************急停信号********
               Dmc2610.d2610_config_EMG_PIN(0, 1, 0);// '设置急停信号有效后会立即停止所有轴，指定0卡号，1允许功能，1低电平有效
           //'************SD减速信号*********
               if (CheckSD减速.Checked)
               {
                   CheckSD减速.Text = "SD减速开";
                   for (ushort SD轴号 = 0; SD轴号 <6; SD轴号++)//'设置SD/PCS1端SD信号有效的逻辑电平及其工作方式（轴号，允许/禁止功能1有为有效，0低电平，3锁存SD信号，并减速到起始速度后停止。
                   {
                     Dmc2610.d2610_config_SD_PIN(SD轴号, 1, 0, 3);// '设置6轴SD信号1允许，0低电平有效，3锁存SD信号，并减速到起始速度后停止。  
                   }                   
               }
               else
               {
                   CheckSD减速.Text = "SD减速关";
               }
            //'**************变终点信号********
               if (CheckPCS变终.Checked)
               {
                   int 目标位置 = int.Parse(text改变目标位置.Text);
                   CheckPCS变终.Text = "PCS变终开";
                   for (ushort PCS轴号 = 0; PCS轴号 < 6; PCS轴号++)//'设置允许、禁止PCS外部信号在运动中改变目标位置
                   {
                       Dmc2610.d2610_config_PCS_PIN(PCS轴号, 1, 1);// '1有效，0低电平有效
                       Dmc2610.d2610_reset_target_position(X轴, 目标位置);// '单轴相对运动中改变目标位置。
                   }
               }
               else
               {
                   CheckPCS变终.Text = "PCS变终关";
               }
            //'#############位置到位信号###########
               for (ushort INP轴号 = 0; INP轴号 < 6; INP轴号++)//'设置允许、禁止INP信号的有效电平。
               {
                   Dmc2610.d2610_config_INP_PIN(INP轴号, 1, 1);// '0为无效，1为有效，0为低电平，1为高电平
               }
             //'##############“误差清除”########
               for (ushort ERC轴号 = 0; ERC轴号 < 6; ERC轴号++)// '设置允许、禁止ERC信号的有效电平和输出方式
               {
                    Dmc2610.d2610_config_ERC_PIN(ERC轴号, 1, 1, 4, 3) ;//'1自动输出ERC信号，0低电平有效，7电平输出，3关断时间104MS
               }
               for (ushort ERC轴号1 = 0; ERC轴号1 <6; ERC轴号1++)// '控制指定轴“误差清除”信号的输出
               {
                   Dmc2610.d2610_write_ERC_PIN(ERC轴号1, 1);// '0为复位ERC信号，1为输出ERC信号
               }
            //'************ALM报警信号**********
               for (ushort ALM轴号 = 0; ALM轴号 < 6; ALM轴号++)//'设置ALM报警信号的有效电平及其工作方式 
               {
                   Dmc2610.d2610_config_ALM_PIN(ALM轴号, 0, 0);// '0低电平有效，0立即停止电机.
               }
            // '*********编码器Z相信号使用***
               for (ushort EZ轴号 = 0; EZ轴号 <6; EZ轴号++)//'设置指定轴的EZ信号的有效电平及其工作方式
               {
                     Dmc2610.d2610_config_EZ_PIN(EZ轴号, 0, 0);// '0为低电平，0为EZ信号无效。
               }
            //'***********编码器锁存信号*****
               for (ushort LTC轴号 = 0; LTC轴号 <6; LTC轴号++)//'设置指定轴的锁存信号有效电平。
               {
                   Dmc2610.d2610_config_LTC_PIN(LTC轴号, 0, 7);
               }
             //'**********各轴电机EL限位信号*********
               for (ushort EL轴号 = 0; EL轴号 < 6; EL轴号++)// '设置EL限位信号的有效电平及制动方式 
               {
                  Dmc2610.d2610_config_EL_MODE(EL轴号, 1);// '低电平有效，减速停止 
               }
           // '******ORG原点信号***********
        //'设置ORG原点的有效电平，以及允许、禁止滤波功能
               Dmc2610.d2610_set_HOME_pin_logic(X轴, 0, 1);// '0为代电平，1允许滤波
               Dmc2610.d2610_set_HOME_pin_logic(Y轴, 0, 1);// '0为代电平，1允许滤波
       //'***********伺服电机使能信号*********
            int X使能 = Dmc2610.d2610_read_SEVON_PIN(X轴);//'读取指定轴的伺服电机使能信号，高低电平信号 '0为低电平，1为高电平
            Dmc2610.d2610_write_SEVON_PIN(X轴, 0);//  '设置伺服电机使能信号'0为低电平有效，1为高电平有效。
            switch (X使能)
            {
               case 0:
                LaX使能.Text = "X使能SEVON1低电平";
                LaX使能.ForeColor = Color.Black;
                 break;
               case 1:
                 LaX使能.ForeColor = Color.Red;
                LaX使能.Text = "X使能SEVON1高电平";          
                 break;
                default:
                    break;
            }
         int Y使能 = Dmc2610.d2610_read_SEVON_PIN(Y轴);//'读取指定轴的伺服电机使能信号，高低电平信号 '0为低电平，1为高电平
          Dmc2610.d2610_write_SEVON_PIN(Y轴, 1);// '设置伺服电机使能信号''0为低电平有效，1为高电平有效。
          switch (Y使能)
          {
              case 0:
                LaY使能.Text = "Y使能SEVON2低电平";
                LaY使能.ForeColor = Color.Blue;
                break;
              case 1:
                LaY使能.Text = "Y使能SEVON2高电平";
                LaY使能.ForeColor = Color.Red;
                break;
              default:
                  break;
          }
            // '***********“伺服准备好”********
          int X准备RDY = Dmc2610.d2610_read_RDY_PIN(X轴);// '读取指定轴的“伺服准备好”的信号电平
          switch (X准备RDY)// '0为低电平，1为高电平
          {
              case 0:
                LaX准备RDY.Text = "X伺服准备好低电平";
                LaX准备RDY.ForeColor = Color.Red;
                break;
              case 1:
                LaX准备RDY.Text = "X伺服准备好高电平";
                LaX准备RDY.ForeColor = Color.Black;
                break;         
              default:
                  break;
          }
          int Y准备RDY = Dmc2610.d2610_read_RDY_PIN(Y轴);// '读取指定轴的“伺服准备好”的信号电平
          switch (Y准备RDY)// '0为低电平，1为高电平
          {
              case 0:
                  LaY准备RDY.Text = "Y伺服准备好低电平";
                  LaY准备RDY.ForeColor = Color.Red;
                  break;
              case 1:
                  LaY准备RDY.Text = "Y伺服准备好高电平";
                  LaY准备RDY.ForeColor = Color.Blue;
                  break;
              default:
                  break;
          }
            // '********************位置比较**********************
          if (Check比较.Checked)//位置比较打开
          {
              int CMP1比较数据 = Int32.Parse(Text比较数据.Text);
              Dmc2610.d2610_set_comparator_data(X轴, CMP1比较数据, 0);// '预置比较器数值
              Dmc2610.d2610_set_comparator_data(Y轴, CMP1比较数据, 0);// '预置比较器数值
              Dmc2610.d2610_config_comparator(X轴, 3, 0, 0, 0);// '设置指定轴比较器触发条件X轴；（0关闭，1等于，2小于，3大于）；保留0；0：比较器与指令脉冲计数器比较1：比较器与指令脉冲比较；保留0；
              Dmc2610.d2610_config_comparator(Y轴, 3, 0, 0, 0);// '设置指定轴比较器触发条件
              //***********X轴配置位置***************
           Dmc2610.d2610_config_CMP_PIN(X轴, 1, 0, 1);// '配置位置比较输出端口的功能，每轴只有一个比较端口CMP,轴号，1为比较端输出，0为低电平。
           int X轴比较 = Dmc2610.d2610_read_CMP_PIN(X轴);// '读取指定轴的位置比较输出端口的电平
           switch (X轴比较)
             {
              case 0:
                LaX位置比较.Text = "X轴CMP低电平";
                But紧急停止_Click(sender, e);
                break;               
              case 1:
                LaX位置比较.Text = "X轴CMP高电平";
                break;
              default:
                  break;
              }
           //***********Y轴配置位置***************
          Dmc2610.d2610_config_CMP_PIN(Y轴, 1, 0, 0);// '配置位置比较输出端口的功能，每轴只有一个比较端口CMP,轴号，1为比较端输出，1为高电平。
          int Y轴比较 = Dmc2610.d2610_read_CMP_PIN(Y轴);// '读取指定轴的位置比较输出端口的电平
            switch (Y轴比较)
             {
              case 0:
                  LaY位置比较.Text = "Y轴CMP低电平";                
                  break;                
              case 1:
                  LaY位置比较.Text = "Y轴CMP高电平";
                   Dmc2610.d2610_emg_stop();// '所有轴紧急停止
                  break;
              default:
                  break;
             }
          }      
        }

        private void But单轴启动_Click(object sender, EventArgs e)
        {
            //************设定指定运行单轴改变速度上限，及变速使能。************************
            Dmc2610.d2610_variety_speed_range(nAxis轴号[0], 1, 35889.9);// '设定指定单轴改变速度上限，及变速使能。
            if (变速数据 > 1000)
            {
                HScrollBar1.Value = 1000;
            }
            //***************设定曲线的起始速度、运行速度、加速时间, 减速时间**************************
            if (Radio设置T形速度.Checked)//'设定T形曲线的起始速度、运行速度、加速时间, 减速时间
            {
                Dmc2610.d2610_set_profile(nAxis轴号[0], Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间);// '以T形速度模式运动函数
                La速度方式.Text = "设置T形速度";
            }

            if ( Radio设置S形速度.Checked)//'设定S形曲线运动的Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间,加减速脉冲。
            {
                Dmc2610.d2610_set_s_profile(nAxis轴号[0], Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间, Sacc加速脉冲, Sdec减速脉冲);// '以S形速度模式运动函数
                La速度方式.Text = "设置S形速度";                
            }
            if (Radio多轴插补速度.Checked != false)//Radio多轴插补速度不等于false
            {
                MessageBox.Show("没有选择设置T形或S形速度", "提示");
                return;//退出当前if程序
            }
                                 //'############各轴运行方式########## 
            if (nNum插补轴数 >= 2)
            {
                MessageBox.Show("单轴运行不能同时选择两个以上轴！", "提示");
                return;//退出当前程序
            } 
             if (Radio圆弧插补.Checked || Radio两轴直线插补.Checked || Radio三轴直线插补.Checked||Radio四轴直线插补.Checked ||radio六轴直线插补.Checked!=false)
             {
                 //if ((CheckX轴.Checked & CheckY轴.Checked == true) || (CheckX轴.Checked & CheckZ轴.Checked == true) || (CheckX轴.Checked & CheckU轴.Checked == true)
                 //    || (CheckY轴.Checked & CheckZ轴.Checked == true) || (CheckY轴.Checked & CheckU轴.Checked == true) || (CheckZ轴.Checked & CheckU轴.Checked == true)
                 //    || (CheckA轴.Checked & CheckB轴.Checked == true) || (CheckX轴.Checked & CheckA轴.Checked == true) || (CheckX轴.Checked & CheckB轴.Checked == true)
                 //    || (CheckA轴.Checked & CheckU轴.Checked == true) || (CheckZ轴.Checked & CheckA轴.Checked == true) || (CheckZ轴.Checked & CheckB轴.Checked == true))
                 MessageBox.Show("没有选择单轴运动！", "提示");
                 return;//退出当前程序            
                 //Application.Exit();///退出整个程序
              }

            if (X轴运动检测 == 0 || Y轴运动检测 == 0 || Z轴运动检测 == 0 || U轴运动检测 == 0 || A轴运动检测 == 0 ||B轴运动检测 == 0)
             {
                 MessageBox.Show("其它轴在运行中！", "提示");
                 return;//退出当前if程序
             }
             //if (CheckX轴.Checked == false &CheckY轴.Checked == false & CheckZ轴.Checked == false
             //    & CheckU轴.Checked == false & CheckA轴.Checked == false & CheckB轴.Checked == false)// '轴没有选择判断检测
             if (nNum插补轴数 < 1)// '判断检测轴有没有选择
             {
                 MessageBox.Show("轴没有选择！", "提示");
             }
             else if (Radio单轴T形位置运动对.Checked)
             {
                if (radio相对模式.Checked)
                 {
                     Dmc2610.d2610_t_pmove(nAxis轴号[0], Dist位置设定[0], 0);// '指定轴以对称T形速度曲线做定长位移运动,0相对位移，1绝对位移
                     La运行方式.Text = "单轴T形位置运动对"; 
                 }
               if (radio绝对模式.Checked)
                 {
                   Dmc2610.d2610_t_pmove(nAxis轴号[0], Dist位置设定[0], 1);// '指定轴以对称T形速度曲线做定长位移运动,0相对位移，1绝对位移
                     La运行方式.Text = "单轴T形位置运动对";   
                 }
             }
             else if (Radio单轴T形位置运动非.Checked)
             {
                 Dmc2610.d2610_ex_t_pmove(nAxis轴号[0], Dist位置设定[0], 模式);// '指定轴以非对称T形速度曲线做定长位移运动,模式：0相对位移，1绝对位移
                 La运行方式.Text = "单轴T形位置运动非";
             }
             else if (Radio单轴S形位置运动对.Checked)
             {
                 Dmc2610.d2610_s_pmove(nAxis轴号[0], Dist位置设定[0], 模式);// '指定轴以对称S形速度曲线做定长位移运动,模式：0相对位移，1绝对位移
                La运行方式.Text = "单轴S形位置运动对";
             }
             else if (Radio单轴S形位置运动非.Checked)
             {
                 Dmc2610.d2610_ex_s_pmove(nAxis轴号[0], Dist位置设定[0], 模式);// '指定轴以非对称S形速度曲线做定长位移运,模式：0相对位移，1绝对位移
                 La运行方式.Text = "单轴S形位置运动非";
             }
             else if (Radio单轴T形连续运动.Checked)
             {
                 Dmc2610.d2610_t_vmove(nAxis轴号[0], 模式);// '指定轴以T形速度曲线加速到高速，并持续运行下去，模式：0负方向，1正方向
                  La运行方式.Text = "单轴T形连续运动";
             }
             else if (Radio单轴S形连续运动.Checked)
             {
                 Dmc2610.d2610_s_vmove(nAxis轴号[0], 模式); //'指定轴以S形速度曲线加速到高速，并持续运行下去，模式：0负方向，1正方向
                La运行方式.Text = "单轴S形连续运动";
             }           
        }

        private void But单轴停止_Click(object sender, EventArgs e)
        {
            if (Radio单轴减速停止.Checked)
            {
                for (UInt16  XYZ急停止 = 0; XYZ急停止 < 6; XYZ急停止++)
                {
                    Dmc2610.d2610_decel_stop(XYZ急停止,0.5);  // '窗口关闭同时X轴减速停止 
                } 
            }
            if (Radio单轴立即停止.Checked)
            {
              for (UInt16 XYZ急停止 = 0; XYZ急停止 < 6; XYZ急停止++)
               {
                Dmc2610.d2610_imd_stop(XYZ急停止);  // '窗口关闭同时X轴急速停止 
               } 
            }            
        }

        private void But紧急停止_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_emg_stop();// '所有轴紧急停止
        }

        private void But退出_Click(object sender, EventArgs e)
        {
            But单轴停止.PerformClick();// '最简单又快的方法1，调用But单轴停止.的Click事件
            Dmc2610.d2610_board_close(); //'关闭控制卡，释放系统资源。
            //this.Close();//退出当前窗口
            Application.Exit();///退出整个程序及关闭窗口
        }

        private void But同步停止_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_simultaneous_stop(nAxis轴号[0]);// '使多卡上的所有轴同时停止运行
            Dmc2610.d2610_board_reset();//控制卡复位
        }

        private void But插补启动_Click(object sender, EventArgs e)
        {
             if (nNum插补轴数 < 2)
            {
                MessageBox.Show("没有选择插补功能！或者没有选择两个以上的轴", "提示");
                return;//退出当前程序
            }
            if (Radio多轴插补速度.Checked)//'设定插补矢量运动曲线的Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间
            {
                Dmc2610. d2610_set_vector_profile(Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间);
                La速度方式.Text = "多轴插补速度";
            }
           
            if (Radio两轴直线插补.Checked == false & Radio三轴直线插补.Checked == false & Radio四轴直线插补.Checked == false
                &radio六轴直线插补.Checked==false&Radio圆弧插补.Checked==false)
            {                
                 if (nNum插补轴数>=2)
                {
                    MessageBox.Show("没有选择插补功能！", "提示");
                    return;//退出当前程序
                }
            }
            if (X轴运动检测==0 || Y轴运动检测 == 0 || Z轴运动检测 == 0 || U轴运动检测 == 0 || A轴运动检测 == 0 || B轴运动检测 == 0)
            {
                MessageBox.Show("其它轴在运行中！", "提示");
                return;//退出当前if程序
            }
            if (Radio多轴插补速度.Checked == false)
            {
                MessageBox.Show("没有选择多轴插补速度！", "提示");
                return;//退出当前if程序
            }
            if (Radio三轴直线插补.Checked)           
            {
               if ((CheckX轴.Checked & CheckY轴.Checked & CheckZ轴.Checked) != true || nNum插补轴数 > 3 )
                {
                     MessageBox.Show("三轴直线插补请选择X/Y/Z三个轴！", "提示");
                     return;//退出当前if程序  
                }               
            }
            else if (Radio四轴直线插补.Checked & nNum插补轴数 < 4)
              {                
                    MessageBox.Show("四轴直线插补请选择四个轴！", "提示");
                    return;//退出当前if程序                
              }
           else if (Radio四轴直线插补.Checked)                
            {
                if ((CheckX轴.Checked & CheckY轴.Checked & CheckZ轴.Checked & CheckU轴.Checked)!=true||nNum插补轴数 > 4)
                {
                    MessageBox.Show("四轴直线插补请选择X/Y/Z/U四个轴！", "提示");
                    return;//退出当前if程序  
                }                  
            }
          else if (radio六轴直线插补.Checked & nNum插补轴数 < 6)
            {
                 MessageBox.Show("六轴直线插补请选择六个轴！", "提示");
                 return;//退出当前if程序 
            }
            if (Radio两轴直线插补.Checked)//两轴直线插补打开
            {
                if (CheckX轴.Checked & CheckY轴.Checked != false & nNum插补轴数 < 3)
                {
                    Dmc2610.d2610_t_line2(nAxis轴号[0], Dist位置设定[0], nAxis轴号[1], Dist位置设定[1], 模式);//模式'0相对位移，1绝对位移
                  La运行方式.Text = "两轴直线插补";  
                }
                else
                {
                    MessageBox.Show("两轴直线插补请选X/Y择两个轴！", "提示");
                    return;//退出当前if程序
                }
            }
            else if (Radio三轴直线插补.Checked)//三轴直线插补打开
            {
                Dmc2610.d2610_t_line3(ref nAxis轴号[0], Dist位置设定[0], Dist位置设定[1], Dist位置设定[2], 模式);//模式 '0相对位移，1绝对位移
               La运行方式.Text = "三轴直线插补";
            }
            
            else if (Radio四轴直线插补.Checked)//四轴直线插补打开
            {
                Dmc2610.d2610_t_line4(nAxis轴号[0], Dist位置设定[0], Dist位置设定[1], Dist位置设定[2], Dist位置设定[3], 模式);// 模式'0相对位移，1绝对位移
                La运行方式.Text = "四轴直线插补";
            }
            else if (radio六轴直线插补.Checked)//六轴直线插补打开
           {
               Dmc2610.d2610_t_line6(nAxis轴号[0], ref Dist位置设定[0], 模式);// 模式'0相对位移，1绝对位移
               La运行方式.Text = "六轴直线插补";
           }

            if ( Radio圆弧插补.Checked)
            {
                //if ((CheckZ轴.Checked & CheckX轴.Checked == true) || (CheckZ轴.Checked & CheckY轴.Checked == true) || (CheckX轴.Checked & CheckU轴.Checked == true)
                //    || (CheckU轴.Checked & CheckY轴.Checked == true) || (CheckA轴.Checked & CheckB轴.Checked == true) || (CheckX轴.Checked & CheckB轴.Checked == true)
                //    || (CheckA轴.Checked & CheckX轴.Checked == true) || (CheckY轴.Checked & CheckB轴.Checked == true) || (CheckY轴.Checked & CheckA轴.Checked == true))
                if (CheckX轴.Checked != true || CheckY轴.Checked != true || nNum插补轴数 >2)
                {
                    MessageBox.Show("圆弧插补只能选择XY两个轴！",  "提示");
                    return;//退出当前if程序
                }
            }
            if (Radio圆弧插补.Checked & Radio多轴插补速度.Checked == false & Radio两轴直线插补.Checked == false & Radio三轴直线插补.Checked ==false)
            {
                MessageBox.Show("没有选择多轴插补速度！", "提示");
                return;//退出当前if程序
            }
            else if (Radio圆弧插补.Checked & nNum插补轴数 < 2)
            {
                MessageBox.Show("插补不能少于两个轴！", "提示");
                return;//退出当前if程序
            }
           else if ( Radio圆弧插补.Checked & Radio多轴插补速度.Checked)
            {
                if (radio相对模式.Checked)
                 {
                     Dmc2610.d2610_rel_arc_move(ref nAxis轴号[0], ref Dist位置设定[0], ref Dist位置设定[1], 模式);//模式 '0顺时针转，1逆时针转位移
                    La速度方式.Text = "相对圆弧插补";
                 }
                if (radio绝对模式.Checked)
                {
                    Dmc2610.d2610_arc_move(ref nAxis轴号[0], ref Dist位置设定[0], ref Dist位置设定[1], 模式);//模式 '0顺时针转，1逆时针转位移
                    La速度方式.Text = "绝对圆弧插补";
                }
             
            }
        }

        private void 单轴启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Radio单轴T形位置运动对.Checked||Radio单轴S形连续运动.Checked||Radio单轴S形位置运动对.Checked
                ||Radio单轴S形位置运动非.Checked||Radio单轴T形连续运动.Checked||Radio单轴T形位置运动非.Checked)
            {
                But单轴启动.PerformClick();
            }            
        }

        private void 单轴连续启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (X轴运动检测 == 0 || Y轴运动检测 == 0 || Z轴运动检测 == 0 || U轴运动检测 == 0)
            {
                MessageBox.Show("其它轴在运行中！", "提示");
                return;//退出当前if程序
            }
            else if (Radio单轴T形连续运动.Checked == false & Radio单轴S形连续运动.Checked == false )
            {
                MessageBox.Show("没有选择连续运动！",  "提示");
                return;//退出当前if程序
            }
            if (Radio设置T形速度.Checked)
            {
               for (ushort  轴号 = 0; 轴号 < 6; 轴号++)
                {
                    Dmc2610.d2610_set_profile(轴号, Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间);// '以T形速度模式运动函数
                     La速度方式.Text = "设置T形速度";
                }             
            }
            if (Radio设置S形速度.Checked)
            {
              for (ushort 轴号 = 0; 轴号 < 6; 轴号++)
			   {
                  Dmc2610.d2610_set_s_profile(轴号, Min_Vel起始速度, Max_Vel运行速度, Tacc加速时间, Tdec减速时间, Sacc加速脉冲, Sdec减速脉冲);// '以S形速度模式运动函数
                  La速度方式.Text = "设置S形速度";
			   }                 
            }
            if (Radio单轴T形连续运动.Checked)
            {
                for (ushort 多轴连续 = 0; 多轴连续 < 6; 多轴连续++)
                {
                    Dmc2610.d2610_t_vmove(多轴连续, 0);//'指定轴以T形速度曲线加速到高速，并持续运行下去，0负方向，1正方向
                    La运行方式.Text = "多轴T形连续运动负";
                } 
            }
            if (Radio单轴S形连续运动.Checked)
            {
                for (ushort 多轴连续 = 0; 多轴连续 < 6; 多轴连续++)
                {
                    Dmc2610.d2610_s_vmove(多轴连续, 1);// '指定轴以S形速度曲线加速到高速，并持续运行下去,0负方向，1代表正方向
                    La运行方式.Text = "多轴S形连续运动正";
                }
            }

        }

        private void 直线插补ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Radio两轴直线插补.Checked == false & Radio三轴直线插补.Checked == false & Radio四轴直线插补.Checked == false & radio六轴直线插补.Checked == false)
            {
                MessageBox.Show("没有选择轴插补模式！", "提示");
                return;//退出当前if程序
            }

            else if (Radio两轴直线插补.Checked || Radio三轴直线插补.Checked || Radio四轴直线插补.Checked || radio六轴直线插补.Checked)
            {
                But插补启动_Click(sender, e); 
            }
           
        }

        private void 圆弧插补ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Radio圆弧插补.Checked == false)
            {
                MessageBox.Show("没有选择圆弧插补模式！", "提示");
                return;//退出当前if程序
            }
            else
            {
                But插补启动.PerformClick();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            But单轴停止.PerformClick();// '最简单又快的方法1，调用But单轴停止.的Click事件
            Dmc2610.d2610_board_close(); //'关闭控制卡，释放系统资源。
            this.Close();//退出当前窗口
        }

        private void DMC2610操作画面_FormClosing(object sender, FormClosingEventArgs e)
        {
            But单轴停止.PerformClick();// '最简单又快的方法1，调用But单轴停止.的Click事件
            Dmc2610.d2610_board_reset();//控制卡复位
            Dmc2610.d2610_board_close(); //'关闭控制卡，释放系统资源。
        }
                    
    }
}
