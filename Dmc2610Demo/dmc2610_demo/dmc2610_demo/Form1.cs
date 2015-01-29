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
            nCard = Dmc2610.d2610_board_init(); //���ƿ��ĳ�ʼ�����������ú����ʹ��d2410_board_close�رտ����м䲻���ٴε��øó�ʼ��������
            if ((nCard <= 0) || (nCard >8))//�����Ŀ�����1- 8֮��
                MessageBox.Show("��ʼ��DMC2610��ʧ�ܣ�", "����");

            m_UseAxis = 0;                           //Ĭ��ѡ��X�� 

            Dmc2610.d2610_set_pulse_outmode(m_UseAxis, 0);    //�趨�������ģʽ

            Dmc2610.d2610_set_position(XCH, 0);          //����X�������λ��Ϊ0
            Dmc2610.d2610_set_position(YCH, 0);          //����Y�������λ��Ϊ0
            Dmc2610.d2610_set_position(ZCH, 0);          //����Z�������λ��Ϊ0
            Dmc2610.d2610_set_position(UCH, 0);          //����U�������λ��Ϊ0

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

            pos = Dmc2610.d2610_get_position(0);//��ȡָ����ĵ�ǰλ��
            str_DisplayPos = "X=" + Convert.ToString(pos);
            pos = Dmc2610.d2610_get_position(1);
            str_DisplayPos = str_DisplayPos + "   Y=" + Convert.ToString(pos);
            pos = Dmc2610.d2610_get_position(2);
            str_DisplayPos = str_DisplayPos + "   Z=" + Convert.ToString(pos);
            pos = Dmc2610.d2610_get_position(3);
            str_DisplayPos = str_DisplayPos + "  U=" + Convert.ToString(pos);

            Label_POSITION.Text = str_DisplayPos;//��ʾλ����Ϣ
        }

        private void BUTTON_MOVE_Click(object sender, EventArgs e)
        {
            double m_nStart;
            double m_nSpeed;
            double fAcc;
            Int32 dist;

            //��ȡ������Ϣ
            m_nStart = Convert.ToDouble(Text_STRSPD.Text); 
            m_nSpeed = Convert.ToDouble(Text_RUNSPD.Text);  
            fAcc = Convert.ToDouble(Text_Tacc.Text);
            dist = Convert.ToInt32(Text_Dist.Text);

            Dmc2610.d2610_set_profile(m_UseAxis, m_nStart, m_nSpeed, fAcc, fAcc);   //�����ٶȡ����ٶ�

            Dmc2610.d2610_t_pmove(m_UseAxis, dist, 0);           //�����t���˶�
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
            Dmc2610.d2610_set_position(m_UseAxis, 0);//�趨ָ����ĵ�ǰλ��
        }

        private void Button_DelStop_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_decel_stop(m_UseAxis, Convert.ToDouble(Text_Tacc.Text));//����ֹͣ
        }

        private void Button_EmgStop_Click(object sender, EventArgs e)
        {
            Dmc2610.d2610_emg_stop();//����ֹͣ������
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}