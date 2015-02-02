using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace DrilTapeTest1


{
    public class Dmc2610
    {
        //---------------------   �忨��ʼ�����ú���  ----------------------
        /********************************************************************************
        ** ��������: d2610_board_init
        ** ��������: ���ư��ʼ�������ó�ʼ�����ٶȵ�����
        ** �䡡  ��: ��
        ** �� �� ֵ: 0���޿��� 1-8���ɹ�(ʵ�ʿ���) 
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 d2610_board_init();

        /********************************************************************************
        ** ��������: d2610_board_close
        ** ��������: �ر����п�
        ** �䡡  ��: ��
        ** �� �� ֵ: ��
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_board_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_board_close();

        /********************************************************************************
        ** ��������: ���ƿ���λ
        ** ��������: ��λ���п���ֻ���ڳ�ʼ�����֮����ã�
        ** �䡡  ��: ��
        ** �� �� ֵ: ��
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_board_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_board_reset();


        //���������������
        /********************************************************************************
        ** ��������: d2610_set_pulse_outmode
        ** ��������: ���������ʽ������
        ** �䡡  ��: axis - (0 - 3), outmode: 0 - 7
        **           6:�������壬A�೬ǰ; 7:�������壬B�೬ǰ
        ** �� �� ֵ: �� 
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_pulse_outmode(UInt16 axis, UInt16 outmode);

        //ר���ź����ú���
        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_SD_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_SD_PIN(UInt16 axis, UInt16 enable, UInt16 sd_logic, UInt16 sd_mode);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_PCS_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_PCS_PIN(UInt16 axis, UInt16 enable, UInt16 pcs_logic);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_INP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_INP_PIN(UInt16 axis, UInt16 enable, UInt16 inp_logic);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_ERC_PIN(UInt16 axis, UInt16 enable, UInt16 erc_logic,
                        UInt16 erc_width, UInt16 erc_off_time);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_ALM_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_ALM_PIN(UInt16 axis, UInt16 alm_logic, UInt16 alm_action);
        //new
        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_EL_MODE", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_EL_MODE(UInt16 axis, UInt16 el_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_HOME_pin_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_HOME_pin_logic(UInt16 axis, UInt16 org_logic, UInt16 filter);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_write_SEVON_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_write_SEVON_PIN(UInt16 axis, UInt16 on_off);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_SEVON_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2610_read_SEVON_PIN(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_write_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_write_ERC_PIN(UInt16 axis, UInt16 sel);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_RDY_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2610_read_RDY_PIN(UInt16 axis);

        //ͨ������/������ƺ���
        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2610_read_inbit(UInt16 cardno, UInt16 bitno);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_write_outbit(UInt16 cardno, UInt16 bitno, UInt16 on_off);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2610_read_outbit(UInt16 cardno, UInt16 bitno);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_read_inport(UInt16 cardno);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_read_outport(UInt16 cardno);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_write_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_write_outport(UInt16 cardno, UInt32 port_value);

        //�ƶ�����
        [DllImport("DMC2610.dll", EntryPoint = "d2610_decel_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_decel_stop(UInt16 axis, double Tdec);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_imd_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_imd_stop(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_emg_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_emg_stop();

        [DllImport("DMC2610.dll", EntryPoint = "d2610_simultaneous_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_simultaneous_stop(UInt16 axis);

        //λ�����úͶ�ȡ����
        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_position(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_position(UInt16 axis, Int32 current_position);


        //״̬��⺯��
        [DllImport("DMC2610.dll", EntryPoint = "d2610_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 d2610_check_done(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_prebuff_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 d2610_prebuff_status(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_axis_io_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 d2610_axis_io_status(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_axis_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 d2610_axis_status(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_rsts", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2610_get_rsts(UInt16 axis);


        //�ٶ�����
        [DllImport("DMC2610.dll", EntryPoint = "d2610_variety_speed_range", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_variety_speed_range(UInt16 axis, UInt16 chg_enable, double Max_Vel);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_current_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double d2610_read_current_speed(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_change_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_change_speed(UInt16 axis, double Curr_Vel);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_vector_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_vector_profile(double Min_Vel, double Max_Vel, double Tacc, double Tdec);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_profile(UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_s_profile(UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, Int32 Sacc, Int32 Sdec);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_st_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_st_profile(UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Tsacc, double Tsdec);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_reset_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_reset_target_position(UInt16 axis, Int32 dist);

        //����PCSλ�õľ���ֵ

        [DllImport("DMC2610.dll", EntryPoint = "d2610_reset_target_position2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_reset_target_position2(UInt16 axis, Int32 dist);


        //���ᶨ���˶�

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_ex_t_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_ex_t_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_s_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_s_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_ex_s_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_ex_s_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        //���������˶�

        [DllImport("DMC2610.dll", EntryPoint = "d2610_s_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_s_vmove(UInt16 axis, UInt16 dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_vmove(UInt16 axis, UInt16 dir);

        //���Բ岹

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line2(UInt16 axis1, Int32 Dist1, UInt16 axis2, Int32 Dist2, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line3", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line3(ref UInt16 axis, Int32 Dist1, Int32 Dist2, Int32 Dist3, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line4(UInt16 cardno, Int32 Dist1, Int32 Dist2, Int32 Dist3, Int32 Dist4, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line6", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line6(UInt16 cardno, ref Int32 p_dist, UInt16 posi_mode);

        //�����˶�

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_handwheel_inmode(UInt16 axis, UInt16 inmode, UInt16 count_dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_handwheel_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_handwheel_move(UInt16 axis, double vh);

        //��ԭ��
        /********************************************************************************
        ** ��������: d2610_config_home_mode
        ** ��������: ����home ģʽ
        ** �䡡  ��: axis, mode- 0:ֻ��org, 1:��org��EZ,  EZ_count: 1-16 ���ź�
			             mode: 0 - ֻ��org��   ����λ������
				               1 - ��org��EZ�� ����λ������
					           2 - ֻ��org��   ��λ������
				               3 - ��org��EZ�� ��λ������
        ** �� �� ֵ: ��
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_home_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_home_mode(UInt16 axis, UInt16 mode, UInt16 EZ_count);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_home_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_home_move(UInt16 axis, UInt16 home_mode, UInt16 vel_mode);

        //Բ���岹

        [DllImport("DMC2610.dll", EntryPoint = "d2610_arc_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_arc_move(ref UInt16 axis, ref Int32 target_pos, ref Int32 cen_pos, UInt16 arc_dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_rel_arc_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_rel_arc_move(ref UInt16 axis, ref Int32 rel_pos, ref Int32 rel_cen, UInt16 arc_dir);


        //���úͶ�ȡλ�ñȽ��ź�
        /********************************************************************************
        ** ��������: d2610_config_CMP_PIN
        ** ��������: ����CMP���Ӻ�out17 - 20�Ĺ���:  ����Ϊͨ�������λ�ñȽ����, Ĭ��Ϊͨ�������
        ** �䡡  ��: axis:���
        **			 cmp1_enable: 0: ��CMP��������Ϊͨ�ö��� 1: ����Ϊ�Ƚ����
                     cmp2_enable: 0: Ĭ������Ϊ0
                     CMP_logic: 0:���߼�, 1: ���߼�
        ** �� �� ֵ: ��
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_CMP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_CMP_PIN(UInt16 axis, UInt16 cmp1_enable, UInt16 cmp2_enable, UInt16 CMP_logic);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_CMP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2610_read_CMP_PIN(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_write_CMP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_write_CMP_PIN(UInt16 axis, UInt16 on_off);

        /********************************************************************************
        ** ��������: d2610_config_comparator
        ** ��������: �Ƚ������ƺ���
        ** �䡡  ��: axis  ���
			         cmp1_condition: �Ƚ���1 �Ĵ���������
			               0: �رձȽ������ܡ�
				           1: ��������ֵ���ڱȽ���
				           2: ��������ֵС�ڱȽ�����ֵ
				           3: ��������ֵ���ڱȽ�����ֵ
			         cmp2_condition: �Ƚ���2 �Ĵ���������
			               0: �رձȽ������ܡ�
				           1: ��������ֵ���ڱȽ���
				           2: ��������ֵС�ڱȽ�����ֵ
				           3: ��������ֵ���ڱȽ�����ֵ
                     source_sel - Ϊ�Ƚ���ѡ����Ƚϵļ���Դ, (��������Ϊ0���Ƚ�ָ��λ��)
                              0: �Ƚ���1,2��ѡ��ָ�����������,                   
                     SL_action: ��������Ϊ0, ��δ��
        ** �� �� ֵ: �� 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_comparator", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_comparator(UInt16 axis, UInt16 cmp1_condition, UInt16 cmp2_condition, UInt16 source_sel, UInt16 SL_action);

        /********************************************************************************
        ** ��������: d2610_set_comparator_data
        ** ��������: ���ñȽ����� 
        ** �䡡  ��: axis - ���
                     cmp1_data: �Ƚϵ�1������
			         cmp2_data: �Ƚϵ�2������
        **
        ** �� �� ֵ: �� 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_comparator_data", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_comparator_data(UInt16 axis, Int32 cmp1_data, Int32 cmp2_data);


        //---------------------   ��������������PLD  ----------------------//

        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_encoder(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_encoder(UInt16 axis, Int32 encoder_value);

        /********************************************************************************
        ** ��������: d2610_config_EZ_PIN
        ** ��������: ����EZ���߼���EZ������ʽ;
                     ��EA��EB��Ϊ���������롣
        ** �䡡  ��: axis 
			         ez_logic�� 0������Ч�� 1������Ч
        **           ez_mode:  
        **				   0��EZ�ź���Ч, EZ��LTC����, ��ΪLTC��Ч
        **                 1: ����1��EZ������ 
        **                 2: ����2��EZ��ԭ���ź� 
        **                 3: ����3��EZ��ԭ���ź� 
        ** �� �� ֵ: ��
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_EZ_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_EZ_PIN(UInt16 axis, UInt16 ez_logic, UInt16 ez_mode);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_LTC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_LTC_PIN(UInt16 axis, UInt16 ltc_logic, UInt16 ltc_mode);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_latch_mode(UInt16 cardno, UInt16 all_enable);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_counter_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_counter_config(UInt16 axis, UInt16 mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_latch_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_latch_value(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_latch_flag(UInt16 cardno);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_reset_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_reset_latch_flag(UInt16 cardno);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_reset_clear_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_reset_clear_flag(UInt16 cardno);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_triger_chunnel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_triger_chunnel(UInt16 cardno, UInt16 num);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_speaker_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_speaker_logic(UInt16 cardno, UInt16 logic);

        //other
        /********************************************************************************
        ** ��������: d2610_config_EMG_PIN
        ** ��������: EMG����
        ** �䡡  ��: axis - (0 - 3), enable - 0:��Ч; 1:��Ч
        **              emg_logic: 0:����Ч; 1:����Ч
        ** �� �� ֵ: �� 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_EMG_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_EMG_PIN(UInt16 cardno, UInt16 enable, UInt16 emg_logic);


        //�˲�������
        /********************************************************************************
        ** ��������: d2610_config_LTC_filter
        ** ��������: ����LTC�źŵ��˲�������������ͬʱ����
        ** �䡡  ��: cardno : ����
                     UInt16 width: 0-255;  ��Χ������Ϊ 8MHZ ~ 32K Hz, �����趨Ƶ�ʵ��źŻᱻ�˵�.
                          �˲�Ƶ�ʵļ���: f = 8M Hz / (width + 1)
                     UInt16 enable
        ** �� �� ֵ: ��
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_LTC_filter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_LTC_filter(UInt16 cardno, UInt16 width, UInt16 enable);

        /********************************************************************************
        ** ��������: d2610_config_encoder_filter
        ** ��������: ���ñ�����EA, EB, EZ���˲������������ᵥ������
        ** �䡡  ��: axis : ���, �࿨����ʱ�������������, ��ڶ��ſ�: ���(4 - 7) 
                     UInt16 width: 0-255;  ��Χ������Ϊ 8MHZ ~ 32K Hz, �����趨Ƶ�ʵ��źŻᱻ�˵�.
                          �˲�Ƶ�ʵļ���: f = 8M Hz / (width + 1) 
        ** �� �� ֵ: ��
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_encoder_filter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_encoder_filter(UInt16 axis, UInt16 width, UInt16 enable);


        //����ͬʱ��ͣ����
        /********************************************************************************
        ** ��������: d2610_set_t_move_all
        ** ��������: ����ͬ���˶��趨
        ** �䡡  ��: TotalAxes: ����,  pAxis:���б�, pDist:λ���б�
                     posi_mode: 0-���, 1-����
        ** �� �� ֵ: 1:��ȷ , -1:������
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_t_move_all", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_t_move_all(UInt16 TotalAxes, ref UInt16 pAxis, ref Int32 pDist, UInt16 posi_mode);

        /********************************************************************************
        ** ��������: d2610_start_move_all
        ** ��������: ����ͬ���˶�
        ** �䡡  ��: TotalAxes: ��һ�����
        ** �� �� ֵ: 1:��ȷ , -1:������  
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_start_move_all", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_start_move_all(UInt16 FirstAxis);

        /********************************************************************************
        ** ��������: d2610_set_sync_option
        ** ��������: ����ͬ��ѡ���趨, ע��: ʹ�ú����رմ˹���, ��sync_option1��0.
        ** �䡡  ��: axis:���
                     sync_stop_on: 1:��CSTOP �ź���ʱ,��ֹͣ; 
                     cstop_output_on: ���쳣ֹͣʱ��� CSTOP�ź�
                     sync_option1: 0:��������, 1: �ȴ�CSTA�ź� ������������ 
                     sync_option2: ����
        ** �� �� ֵ: 1:��ȷ , -1:������
        **    
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_sync_option", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_sync_option(UInt16 axis, UInt16 sync_stop_on, UInt16 cstop_output_on, UInt16 sync_option1, UInt16 sync_option2);

        /********************************************************************************
        ** ��������: d2610_set_sync_stop_mode
        ** ��������: ����ͬ��ֹͣ�ļ��ٷ�ʽ
        ** �䡡  ��: axis: ���
                     stop_mode:  0- ����ֹͣ, 1-����ֹͣ
        ** �� �� ֵ: 1:��ȷ , -1:������    
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_sync_stop_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_sync_stop_mode(UInt16 axis, UInt16 stop_mode);

        /********************************************************************************
        ** ��������: d2610_config_CSTA_PIN
        ** ��������: ����ͬ�������ź�, ֻ��Ϊ����Ч, ����Ϊ��ƽ���Ǳ����źŴ���,Ĭ��Ϊ��ƽ����
        ** �䡡  ��: axis: ���
                     edge_mode:  0- ��ƽ, 1-����
        ** �� �� ֵ: 1   
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_CSTA_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_config_CSTA_PIN(UInt16 axis, UInt16 edge_mode);

        //�������嵱������ز���

        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_equiv", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_equiv(UInt16 axis, ref double equiv);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_equiv", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_equiv(UInt16 axis, double new_equiv);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_position_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_position_unitmm(UInt16 axis, ref double pos_by_mm);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_position_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_position_unitmm(UInt16 axis, double pos_by_mm);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_current_speed_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_read_current_speed_unitmm(UInt16 axis, ref double current_speed);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_encoder_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_encoder_unitmm(UInt16 axis, ref double encoder_pos_by_mm);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_encoder_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_encoder_unitmm(UInt16 axis, double encoder_pos_by_mm);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_arc_move_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_arc_move_unitmm(ref UInt16 axis, ref double target_pos, ref double cen_pos, UInt16 arc_dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_rel_arc_move_unitmm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_rel_arc_move_unitmm(ref UInt16 axis, ref double rel_pos, ref double rel_cen, UInt16 arc_dir);


        //����ջ�����

        [DllImport("DMC2610.dll", EntryPoint = "d2610_pulse_loop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_pulse_loop(UInt16 axis);


        /********************************************************************************
        ** ��������: d2610_set_handwheel_inmode
        ** ��������: //�������뷽ʽ������
        ** �䡡  ��: 0:�رգ� 1���� �������� �޲���
        ** �� �� ֵ: �� 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_enable_handwheel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_enable_handwheel(UInt16 axis, UInt16 hand_enable);

        /********************************************************************************
        ** ��������: d2610_config_handle_freq
        ** ��������: ������������Ƶ������
        **            
        ** �䡡  ��: cardno: ����, 
        **           freq: ��Ӧ�����ֵ��������Ƶ�����ã� ������Ϊ�� 20 - 255                   
                      ��Ӧ�����Ƶ��ֵΪ�� f = 750 KHz / freq
			          Ĭ��ֵΪ75, ��Ƶ��Ϊ10K. 
        ** �� �� ֵ: �� 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_handle_freq", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_handle_freq(UInt16 cardno, UInt16 freq);

        /********************************************************************************
        ** ��������: d2610_config_handle_multi
        ** ��������: ��������ı�������
        **            
        ** �䡡  ��: cardno: ����, 
        **           multi: ��������ı������ã� ������Ϊ�� 1 - 127, Ĭ��ֵΪ1
                        ������multi = 2ʱ��������һ�����壬�����2������
        ** �� �� ֵ: �� 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_handle_multi", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_handle_multi(UInt16 cardno, UInt16 multi);





        //PC�������
        enum ERR_CODE_DMC
        {
            ERR_NOERR = 0,          //�ɹ�      
            ERR_UNKNOWN = 1,
            ERR_PARAERR = 2,

            ERR_TIMEOUT = 3,
            ERR_CONTROLLERBUSY = 4,
            ERR_CONNECT_TOOMANY = 5,

            ERR_CONTILINE = 40,
            ERR_CANNOT_CONNECTETH = 8,
            ERR_HANDLEERR = 9,
            ERR_SENDERR = 10,
            ERR_FIRMWAREERR = 12, //�̼��ļ�����
            ERR_FIRMWAR_MISMATCH = 14, //�̼���ƥ��

            ERR_FIRMWARE_INVALID_PARA = 20,  //�̼���������
            ERR_FIRMWARE_PARA_ERR = 20,  //�̼���������2
            ERR_FIRMWARE_STATE_ERR = 22, //�̼���ǰ״̬���������
            ERR_FIRMWARE_LIB_STATE_ERR = 22, //�̼���ǰ״̬���������2
            ERR_FIRMWARE_CARD_NOT_SUPPORT = 24,  //�̼���֧�ֵĹ��� ��������֧�ֵĹ���
            ERR_FIRMWARE_LIB_NOTSUPPORT = 24,    //�̼���֧�ֵĹ���2
        };

    }
}