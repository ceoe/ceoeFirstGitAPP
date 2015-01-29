using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using csDmc2610;

namespace Demo
{
    public partial class Form1 : Form
    {
        const Int32 XCH = 0;
        const Int32 YCH = 1;
        const Int32 ZCH = 2;
        const Int32 UCH = 3;

        UInt16 m_UseAxis;

        public Form1()
        {
            InitializeComponent();

            Int32 nCard = 0;
            nCard = Dmc2610.d2610_board_init(); //控制卡的初始化操作，调用后必须使用d2410_board_close关闭卡。中间不可再次调用该初始化函数。
            if ((nCard <= 0) || (nCard >8))//正常的卡数在1- 8之间
                MessageBox.Show("初始化DMC2610卡失败！", "出错");

            m_UseAxis = 0;                           //默认选择X轴 

            Dmc2610.d2610_set_pulse_outmode(m_UseAxis, 0);    //设定脉冲输出模式

            Dmc2610.d2610_set_position(XCH, 0);          //设置X轴的脉冲位置为0
            Dmc2610.d2610_set_position(YCH, 0);          //设置Y轴的脉冲位置为0
            Dmc2610.d2610_set_position(ZCH, 0);          //设置Z轴的脉冲位置为0
            Dmc2610.d2610_set_position(UCH, 0);          //设置U轴的脉冲位置为0

            timer1.Enabled = true;
        }

        private void Form1_FormClosed()
        {
            timer1.Enabled = false;
            Dmc2610.d2610_board_close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long pos;
            string str_DisplayPos;

            pos = Dmc2610.d2610_get_position(0);//读取指定轴的当前位置
            str_DisplayPos = "X=" + Convert.ToString(pos);
            pos = Dmc2610.d2610_get_position(1);
            str_DisplayPos = str_DisplayPos + "   Y=" + Convert.ToString(pos);
            pos = Dmc2610.d2610_get_position(2);
            str_DisplayPos = str_DisplayPos + "   Z=" + Convert.ToString(pos);
            pos = Dmc2610.d2610_get_position(3);
            str_DisplayPos = str_DisplayPos + "  U=" + Convert.ToString(pos);

            Label_POSITION.Text = str_DisplayPos;//显示位置信息
        }

        private void BUTTON_MOVE_Click(object sender, EventArgs e)
        {
            double m_nStart;
            double m_nSpeed;
            double fAcc;
            Int32 dist;

            //提取输入信息
            m_nStart = Convert.ToDouble(Text_STRSPD.Text); 
            m_nSpeed = Convert.ToDouble(Text_RUNSPD.Text);  
            fAcc = Convert.ToDouble(Text_Tacc.Text);
            dist = Convert.ToInt32(Text_Dist.Text);

            Dmc2610.d2610_set_profile(m_UseAxis, m_nStart, m_nSpeed, fAcc, fAcc);   //设置速度、加速度

            Dmc2610.d2610_t_pmove(m_UseAxis, dist, 0);           //作相对t型运动
        }

        private void OptionMoveAxis1_CheckedChanged(object sender, EventArgs e)
        {
            m_UseAxis = XCH;
        }

        private void OptionMoveAxis2_CheckedChanged(object sender, EventArgs e)
        {
            m_UseAxis = YCH;
        }

        private void OptionMoveAxis3_CheckedChanged(object sender, EventArgs e)
        {
            m_UseAxis = ZCH;
        }

        private void OptionMoveAxis4_CheckedChanged(object sender, EventArgs e)
        {
            m_UseAxis = UCH;
        }

        private void Button_CLEAN_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_set_position(m_UseAxis, 0);//设定指定轴的当前位置
        }

        private void Button_DelStop_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_decel_stop(m_UseAxis, Convert.ToDouble(Text_Tacc.Text));//减速停止
        }

        private void Button_EmgStop_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_emg_stop();//紧急停止所有轴
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}