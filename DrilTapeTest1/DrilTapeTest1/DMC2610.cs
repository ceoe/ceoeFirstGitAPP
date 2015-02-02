using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace DrilTapeTest1


{
    public class Dmc2610
    {
        //---------------------   板卡初始和配置函数  ----------------------
        /********************************************************************************
        ** 函数名称: d2610_board_init
        ** 功能描述: 控制板初始化，设置初始化和速度等设置
        ** 输　  入: 无
        ** 返 回 值: 0：无卡； 1-8：成功(实际卡数) 
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt16 d2610_board_init();

        /********************************************************************************
        ** 函数名称: d2610_board_close
        ** 功能描述: 关闭所有卡
        ** 输　  入: 无
        ** 返 回 值: 无
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_board_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_board_close();

        /********************************************************************************
        ** 函数名称: 控制卡复位
        ** 功能描述: 复位所有卡，只能在初始化完成之后调用．
        ** 输　  入: 无
        ** 返 回 值: 无
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_board_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_board_reset();


        //脉冲输入输出配置
        /********************************************************************************
        ** 函数名称: d2610_set_pulse_outmode
        ** 功能描述: 脉冲输出方式的设置
        ** 输　  入: axis - (0 - 3), outmode: 0 - 7
        **           6:正交脉冲，A相超前; 7:正交脉冲，B相超前
        ** 返 回 值: 无 
        *********************************************************************************/
        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_pulse_outmode(UInt16 axis, UInt16 outmode);

        //专用信号设置函数
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

        //通用输入/输出控制函数
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

        //制动函数
        [DllImport("DMC2610.dll", EntryPoint = "d2610_decel_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_decel_stop(UInt16 axis, double Tdec);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_imd_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_imd_stop(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_emg_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_emg_stop();

        [DllImport("DMC2610.dll", EntryPoint = "d2610_simultaneous_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_simultaneous_stop(UInt16 axis);

        //位置设置和读取函数
        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_position(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_position(UInt16 axis, Int32 current_position);


        //状态检测函数
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


        //速度设置
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

        //设置PCS位置的距离值

        [DllImport("DMC2610.dll", EntryPoint = "d2610_reset_target_position2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_reset_target_position2(UInt16 axis, Int32 dist);


        //单轴定长运动

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_ex_t_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_ex_t_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_s_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_s_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_ex_s_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_ex_s_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        //单轴连续运动

        [DllImport("DMC2610.dll", EntryPoint = "d2610_s_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_s_vmove(UInt16 axis, UInt16 dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_vmove(UInt16 axis, UInt16 dir);

        //线性插补

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line2(UInt16 axis1, Int32 Dist1, UInt16 axis2, Int32 Dist2, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line3", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line3(ref UInt16 axis, Int32 Dist1, Int32 Dist2, Int32 Dist3, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line4(UInt16 cardno, Int32 Dist1, Int32 Dist2, Int32 Dist3, Int32 Dist4, UInt16 posi_mode);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_t_line6", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_t_line6(UInt16 cardno, ref Int32 p_dist, UInt16 posi_mode);

        //手轮运动

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_handwheel_inmode(UInt16 axis, UInt16 inmode, UInt16 count_dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_handwheel_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_handwheel_move(UInt16 axis, double vh);

        //找原点
        /********************************************************************************
        ** 函数名称: d2610_config_home_mode
        ** 功能描述: 设置home 模式
        ** 输　  入: axis, mode- 0:只计org, 1:计org和EZ,  EZ_count: 1-16 个信号
			             mode: 0 - 只计org，   不复位计数器
				               1 - 计org和EZ， 不复位计数器
					           2 - 只计org，   复位计数器
				               3 - 计org和EZ， 复位计数器
        ** 返 回 值: 无
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_home_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_home_mode(UInt16 axis, UInt16 mode, UInt16 EZ_count);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_home_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_home_move(UInt16 axis, UInt16 home_mode, UInt16 vel_mode);

        //圆弧插补

        [DllImport("DMC2610.dll", EntryPoint = "d2610_arc_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_arc_move(ref UInt16 axis, ref Int32 target_pos, ref Int32 cen_pos, UInt16 arc_dir);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_rel_arc_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_rel_arc_move(ref UInt16 axis, ref Int32 rel_pos, ref Int32 rel_cen, UInt16 arc_dir);


        //设置和读取位置比较信号
        /********************************************************************************
        ** 函数名称: d2610_config_CMP_PIN
        ** 功能描述: 控制CMP端子和out17 - 20的功能:  配置为通用输出或位置比较输出, 默认为通用输出口
        ** 输　  入: axis:轴号
        **			 cmp1_enable: 0: 将CMP端子配置为通用端子 1: 配置为比较输出
                     cmp2_enable: 0: 默认设置为0
                     CMP_logic: 0:负逻辑, 1: 正逻辑
        ** 返 回 值: 无
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_CMP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_CMP_PIN(UInt16 axis, UInt16 cmp1_enable, UInt16 cmp2_enable, UInt16 CMP_logic);


        [DllImport("DMC2610.dll", EntryPoint = "d2610_read_CMP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2610_read_CMP_PIN(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_write_CMP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_write_CMP_PIN(UInt16 axis, UInt16 on_off);

        /********************************************************************************
        ** 函数名称: d2610_config_comparator
        ** 功能描述: 比较器控制函数
        ** 输　  入: axis  轴号
			         cmp1_condition: 比较器1 的触发条件，
			               0: 关闭比较器功能。
				           1: 计数器的值等于比较器
				           2: 计数器的值小于比较器的值
				           3: 计数器的值大于比较器的值
			         cmp2_condition: 比较器2 的触发条件，
			               0: 关闭比较器功能。
				           1: 计数器的值等于比较器
				           2: 计数器的值小于比较器的值
				           3: 计数器的值大于比较器的值
                     source_sel - 为比较器选择相比较的计数源, (保留设置为0，比较指令位置)
                              0: 比较器1,2均选择指令脉冲计数器,                   
                     SL_action: 保留设置为0, 暂未用
        ** 返 回 值: 无 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_comparator", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_comparator(UInt16 axis, UInt16 cmp1_condition, UInt16 cmp2_condition, UInt16 source_sel, UInt16 SL_action);

        /********************************************************************************
        ** 函数名称: d2610_set_comparator_data
        ** 功能描述: 设置比较数据 
        ** 输　  入: axis - 轴号
                     cmp1_data: 比较点1的数据
			         cmp2_data: 比较点2的数据
        **
        ** 返 回 值: 无 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_comparator_data", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_comparator_data(UInt16 axis, Int32 cmp1_data, Int32 cmp2_data);


        //---------------------   编码器计数功能PLD  ----------------------//

        [DllImport("DMC2610.dll", EntryPoint = "d2610_get_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_get_encoder(UInt16 axis);

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_set_encoder(UInt16 axis, Int32 encoder_value);

        /********************************************************************************
        ** 函数名称: d2610_config_EZ_PIN
        ** 功能描述: 配置EZ的逻辑和EZ工作方式;
                     将EA，EB改为了允许输入。
        ** 输　  入: axis 
			         ez_logic： 0：低有效， 1：高有效
        **           ez_mode:  
        **				   0：EZ信号无效, EZ和LTC复用, 置为LTC有效
        **                 1: 功能1：EZ是索引 
        **                 2: 功能2：EZ是原点信号 
        **                 3: 功能3：EZ是原点信号 
        ** 返 回 值: 无
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
        ** 函数名称: d2610_config_EMG_PIN
        ** 功能描述: EMG设置
        ** 输　  入: axis - (0 - 3), enable - 0:无效; 1:有效
        **              emg_logic: 0:低有效; 1:高有效
        ** 返 回 值: 无 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_EMG_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_EMG_PIN(UInt16 cardno, UInt16 enable, UInt16 emg_logic);


        //滤波器配置
        /********************************************************************************
        ** 函数名称: d2610_config_LTC_filter
        ** 功能描述: 配置LTC信号的滤波器参数，四轴同时配置
        ** 输　  入: cardno : 卡号
                     UInt16 width: 0-255;  范围可配置为 8MHZ ~ 32K Hz, 高于设定频率的信号会被滤掉.
                          滤波频率的计算: f = 8M Hz / (width + 1)
                     UInt16 enable
        ** 返 回 值: 无
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_LTC_filter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_LTC_filter(UInt16 cardno, UInt16 width, UInt16 enable);

        /********************************************************************************
        ** 函数名称: d2610_config_encoder_filter
        ** 功能描述: 配置编码器EA, EB, EZ的滤波器参数，各轴单独配置
        ** 输　  入: axis : 轴号, 多卡运行时轴号依次往后排, 如第二张卡: 轴号(4 - 7) 
                     UInt16 width: 0-255;  范围可配置为 8MHZ ~ 32K Hz, 高于设定频率的信号会被滤掉.
                          滤波频率的计算: f = 8M Hz / (width + 1) 
        ** 返 回 值: 无
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_encoder_filter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_encoder_filter(UInt16 axis, UInt16 width, UInt16 enable);


        //增加同时起停操作
        /********************************************************************************
        ** 函数名称: d2610_set_t_move_all
        ** 功能描述: 多轴同步运动设定
        ** 输　  入: TotalAxes: 轴数,  pAxis:轴列表, pDist:位移列表
                     posi_mode: 0-相对, 1-绝对
        ** 返 回 值: 1:正确 , -1:参数错
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_t_move_all", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_t_move_all(UInt16 TotalAxes, ref UInt16 pAxis, ref Int32 pDist, UInt16 posi_mode);

        /********************************************************************************
        ** 函数名称: d2610_start_move_all
        ** 功能描述: 多轴同步运动
        ** 输　  入: TotalAxes: 第一轴轴号
        ** 返 回 值: 1:正确 , -1:参数错  
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_start_move_all", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_start_move_all(UInt16 FirstAxis);

        /********************************************************************************
        ** 函数名称: d2610_set_sync_option
        ** 功能描述: 多轴同步选项设定, 注意: 使用后必须关闭此功能, 将sync_option1清0.
        ** 输　  入: axis:轴号
                     sync_stop_on: 1:当CSTOP 信号来时,轴停止; 
                     cstop_output_on: 当异常停止时输出 CSTOP信号
                     sync_option1: 0:立即启动, 1: 等待CSTA信号 或是启动命令 
                     sync_option2: 无用
        ** 返 回 值: 1:正确 , -1:参数错
        **    
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_sync_option", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_sync_option(UInt16 axis, UInt16 sync_stop_on, UInt16 cstop_output_on, UInt16 sync_option1, UInt16 sync_option2);

        /********************************************************************************
        ** 函数名称: d2610_set_sync_stop_mode
        ** 功能描述: 设置同步停止的减速方式
        ** 输　  入: axis: 轴号
                     stop_mode:  0- 立即停止, 1-减速停止
        ** 返 回 值: 1:正确 , -1:参数错    
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_set_sync_stop_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_set_sync_stop_mode(UInt16 axis, UInt16 stop_mode);

        /********************************************************************************
        ** 函数名称: d2610_config_CSTA_PIN
        ** 功能描述: 设置同步启动信号, 只能为低有效, 配置为电平或是边沿信号触发,默认为电平触发
        ** 输　  入: axis: 轴号
                     edge_mode:  0- 电平, 1-边沿
        ** 返 回 值: 1   
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_CSTA_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_config_CSTA_PIN(UInt16 axis, UInt16 edge_mode);

        //设置脉冲当量和相关操作

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


        //脉冲闭环操作

        [DllImport("DMC2610.dll", EntryPoint = "d2610_pulse_loop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2610_pulse_loop(UInt16 axis);


        /********************************************************************************
        ** 函数名称: d2610_set_handwheel_inmode
        ** 功能描述: //手轮输入方式的允许
        ** 输　  入: 0:关闭， 1：打开 ，其他： 无操作
        ** 返 回 值: 无 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_enable_handwheel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_enable_handwheel(UInt16 axis, UInt16 hand_enable);

        /********************************************************************************
        ** 函数名称: d2610_config_handle_freq
        ** 功能描述: 手轮脉冲的输出频率设置
        **            
        ** 输　  入: cardno: 卡号, 
        **           freq: 对应到手轮的脉冲输出频率设置， 可设置为： 20 - 255                   
                      对应的输出频率值为： f = 750 KHz / freq
			          默认值为75, 即频率为10K. 
        ** 返 回 值: 无 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_handle_freq", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_handle_freq(UInt16 cardno, UInt16 freq);

        /********************************************************************************
        ** 函数名称: d2610_config_handle_multi
        ** 功能描述: 手轮脉冲的倍率设置
        **            
        ** 输　  入: cardno: 卡号, 
        **           multi: 手轮脉冲的倍率设置， 可设置为： 1 - 127, 默认值为1
                        例，当multi = 2时，即输入一个脉冲，会输出2个脉冲
        ** 返 回 值: 无 
        *********************************************************************************/

        [DllImport("DMC2610.dll", EntryPoint = "d2610_config_handle_multi", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2610_config_handle_multi(UInt16 cardno, UInt16 multi);





        //PC库错误码
        enum ERR_CODE_DMC
        {
            ERR_NOERR = 0,          //成功      
            ERR_UNKNOWN = 1,
            ERR_PARAERR = 2,

            ERR_TIMEOUT = 3,
            ERR_CONTROLLERBUSY = 4,
            ERR_CONNECT_TOOMANY = 5,

            ERR_CONTILINE = 40,
            ERR_CANNOT_CONNECTETH = 8,
            ERR_HANDLEERR = 9,
            ERR_SENDERR = 10,
            ERR_FIRMWAREERR = 12, //固件文件错误
            ERR_FIRMWAR_MISMATCH = 14, //固件不匹配

            ERR_FIRMWARE_INVALID_PARA = 20,  //固件参数错误
            ERR_FIRMWARE_PARA_ERR = 20,  //固件参数错误2
            ERR_FIRMWARE_STATE_ERR = 22, //固件当前状态不允许操作
            ERR_FIRMWARE_LIB_STATE_ERR = 22, //固件当前状态不允许操作2
            ERR_FIRMWARE_CARD_NOT_SUPPORT = 24,  //固件不支持的功能 控制器不支持的功能
            ERR_FIRMWARE_LIB_NOTSUPPORT = 24,    //固件不支持的功能2
        };

    }
}