#ifndef _DMC_LIB_H
#define _DMC_LIB_H

#ifdef __cplusplus
extern "C" {
#endif 

//这一段无需改动  //This segment should not be modified
#ifndef TRUE
#define TRUE  1
#endif

#ifndef FALSE
#define FALSE 0
#endif

/* Define NULL pointer value */

#ifndef NULL
#ifdef  __cplusplus
#define NULL    0
#else
#define NULL    ((void *)0)
#endif
#endif


typedef unsigned long       DWORD;
typedef int                 BOOL;
typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef float               FLOAT;

typedef unsigned char  INT8U;                   /* defined for unsigned 8-bits integer variable 	无符号8位整型变量  */
typedef signed   char  INT8S;                   /* defined for signed 8-bits integer variable		有符号8位整型变量  */
typedef unsigned short INT16U;                  /* defined for unsigned 16-bits integer variable 	无符号16位整型变量 */
typedef signed   short INT16S;                  /* defined for signed 16-bits integer variable 		有符号16位整型变量 */
typedef unsigned int   INT32U;                  /* defined for unsigned 32-bits integer variable 	无符号32位整型变量 */
typedef int			   INT32S;                  /* defined for signed 32-bits integer variable 		有符号32位整型变量 */
typedef float		   FP32;                    /* single precision floating point variable (32bits) 单精度浮点数（32位长度） */
typedef double		   FP64;                    /* double precision floating point variable (64bits) 双精度浮点数（64位长度） */


#define __DMC2610_EXPORTS

//定义输入和输出
#ifdef __DMC2610_EXPORTS
	#define DMC2610_API __declspec(dllexport)
#else
	#define DMC2610_API __declspec(dllimport)
#endif

//---------------------   板卡初始和配置函数  ----------------------
/********************************************************************************
** 函数名称: d2610_board_init
** 功能描述: 控制板初始化，设置初始化和速度等设置
** 输　  入: 无
** 返 回 值: 0：无卡； 1-8：成功(实际卡数) 
*********************************************************************************/
DMC2610_API WORD __stdcall d2610_board_init(void);

/********************************************************************************
** 函数名称: d2610_board_close
** 功能描述: 关闭所有卡
** 输　  入: 无
** 返 回 值: 无
*********************************************************************************/
DMC2610_API void __stdcall d2610_board_close(void); 

/********************************************************************************
** 函数名称: 控制卡复位
** 功能描述: 复位所有卡，只能在初始化完成之后调用．
** 输　  入: 无
** 返 回 值: 无
*********************************************************************************/
DMC2610_API void __stdcall d2610_board_reset(void);


//脉冲输入输出配置
/********************************************************************************
** 函数名称: d2610_set_pulse_outmode
** 功能描述: 脉冲输出方式的设置
** 输　  入: axis - (0 - 3), outmode: 0 - 7
**           6:正交脉冲，A相超前; 7:正交脉冲，B相超前
** 返 回 值: 无 
*********************************************************************************/
DMC2610_API void __stdcall d2610_set_pulse_outmode(WORD axis,WORD outmode);

//专用信号设置函数
DMC2610_API void __stdcall d2610_config_SD_PIN(WORD axis,WORD enable, WORD sd_logic,WORD sd_mode);
DMC2610_API void __stdcall d2610_config_PCS_PIN(WORD axis,WORD enable,WORD pcs_logic);
DMC2610_API void __stdcall d2610_config_INP_PIN(WORD axis,WORD enable,WORD inp_logic);
DMC2610_API void __stdcall d2610_config_ERC_PIN(WORD axis,WORD enable,WORD erc_logic,
				WORD erc_width,WORD erc_off_time);

DMC2610_API void __stdcall d2610_config_ALM_PIN(WORD axis,WORD alm_logic,WORD alm_action);
//new
DMC2610_API void __stdcall d2610_config_EL_MODE(WORD axis,WORD el_mode);

DMC2610_API void __stdcall d2610_set_HOME_pin_logic(WORD axis,WORD org_logic,WORD filter);

DMC2610_API void __stdcall d2610_write_SEVON_PIN(WORD axis, WORD on_off);
DMC2610_API int __stdcall d2610_read_SEVON_PIN(WORD axis);

DMC2610_API void __stdcall d2610_write_ERC_PIN(WORD axis, WORD sel);
DMC2610_API int __stdcall d2610_read_RDY_PIN(WORD axis);

//通用输入/输出控制函数
DMC2610_API int __stdcall d2610_read_inbit(WORD cardno, WORD bitno);
DMC2610_API void __stdcall d2610_write_outbit(WORD cardno, WORD bitno,WORD on_off);
DMC2610_API int __stdcall  d2610_read_outbit(WORD cardno, WORD bitno) ;
DMC2610_API long __stdcall d2610_read_inport(WORD cardno);
DMC2610_API long __stdcall d2610_read_outport(WORD cardno) ;
DMC2610_API void __stdcall d2610_write_outport(WORD cardno, DWORD port_value);

//制动函数
DMC2610_API void __stdcall d2610_decel_stop(WORD axis,double Tdec);
DMC2610_API void __stdcall d2610_imd_stop(WORD axis);
DMC2610_API void __stdcall d2610_emg_stop(void) ;
DMC2610_API void __stdcall d2610_simultaneous_stop(WORD axis) ;

//位置设置和读取函数
DMC2610_API long __stdcall d2610_get_position(WORD axis);
DMC2610_API void __stdcall d2610_set_position(WORD axis,long current_position);


//状态检测函数
DMC2610_API WORD __stdcall  d2610_check_done(WORD axis) ;
DMC2610_API WORD __stdcall d2610_prebuff_status(WORD axis);
DMC2610_API WORD __stdcall d2610_axis_io_status(WORD axis);
DMC2610_API WORD __stdcall d2610_axis_status(WORD axis);
DMC2610_API DWORD __stdcall d2610_get_rsts(WORD axis) ;


//速度设置
DMC2610_API void __stdcall d2610_variety_speed_range(WORD axis,WORD chg_enable ,double Max_Vel);
DMC2610_API double __stdcall d2610_read_current_speed(WORD axis);
DMC2610_API void __stdcall d2610_change_speed(WORD axis,double Curr_Vel);
DMC2610_API void __stdcall d2610_set_vector_profile(double Min_Vel,double Max_Vel,double Tacc,double Tdec);
DMC2610_API void __stdcall d2610_set_profile(WORD axis,double Min_Vel,double Max_Vel,double Tacc,double Tdec);
DMC2610_API void __stdcall d2610_set_s_profile(WORD axis,double Min_Vel,double Max_Vel,double Tacc,double Tdec, long Sacc,long Sdec);
DMC2610_API void __stdcall d2610_set_st_profile(WORD axis,double Min_Vel, double Max_Vel,double Tacc,double Tdec, double Tsacc,double Tsdec);

DMC2610_API void __stdcall d2610_reset_target_position(WORD axis,long dist);

//设置PCS位置的距离值
DMC2610_API void __stdcall d2610_reset_target_position2(WORD axis,long dist);


//单轴定长运动
DMC2610_API void __stdcall d2610_t_pmove(WORD axis,long Dist,WORD posi_mode);
DMC2610_API void __stdcall d2610_ex_t_pmove(WORD axis,long Dist,WORD posi_mode);
DMC2610_API void __stdcall d2610_s_pmove(WORD axis,long Dist,WORD posi_mode);
DMC2610_API void __stdcall d2610_ex_s_pmove(WORD axis,long Dist,WORD posi_mode);

//单轴连续运动
DMC2610_API void __stdcall d2610_s_vmove(WORD axis,WORD dir);
DMC2610_API void __stdcall d2610_t_vmove(WORD axis,WORD dir);

//线性插补
DMC2610_API void __stdcall d2610_t_line2(WORD axis1,long Dist1,WORD axis2,long Dist2,WORD posi_mode);
DMC2610_API void __stdcall d2610_t_line3(WORD *axis,long Dist1,long Dist2,long Dist3,WORD posi_mode);
DMC2610_API void __stdcall d2610_t_line4(WORD cardno,long Dist1,long Dist2,long Dist3,long Dist4,WORD posi_mode);
DMC2610_API void __stdcall d2610_t_line6(WORD cardno, long *p_dist, WORD posi_mode);

//手轮运动
DMC2610_API void __stdcall d2610_set_handwheel_inmode(WORD axis,WORD inmode,WORD count_dir);
DMC2610_API void __stdcall d2610_handwheel_move(WORD axis,double vh);

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
DMC2610_API void __stdcall d2610_config_home_mode(WORD axis,WORD mode,WORD EZ_count);
DMC2610_API void __stdcall d2610_home_move(WORD axis,WORD home_mode,WORD vel_mode);

//圆弧插补
DMC2610_API void __stdcall d2610_arc_move(WORD *axis,long *target_pos,long *cen_pos, WORD arc_dir);
DMC2610_API void __stdcall d2610_rel_arc_move(WORD *axis,long *rel_pos,long *rel_cen, WORD arc_dir);


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
DMC2610_API void __stdcall d2610_config_CMP_PIN(WORD axis, WORD cmp1_enable,  WORD cmp2_enable, WORD CMP_logic);

DMC2610_API int __stdcall d2610_read_CMP_PIN(WORD axis);
DMC2610_API void __stdcall d2610_write_CMP_PIN(WORD axis, WORD on_off);

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
void __stdcall d2610_config_comparator(WORD axis, WORD cmp1_condition, WORD cmp2_condition, WORD source_sel,WORD SL_action);

/********************************************************************************
** 函数名称: d2610_set_comparator_data
** 功能描述: 设置比较数据 
** 输　  入: axis - 轴号
             cmp1_data: 比较点1的数据
			 cmp2_data: 比较点2的数据
**
** 返 回 值: 无 
*********************************************************************************/
void __stdcall d2610_set_comparator_data(WORD axis,long cmp1_data,long cmp2_data);


//---------------------   编码器计数功能PLD  ----------------------//
DMC2610_API long __stdcall d2610_get_encoder(WORD axis);
DMC2610_API void __stdcall d2610_set_encoder(WORD axis,long encoder_value);

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
DMC2610_API void __stdcall d2610_config_EZ_PIN(WORD axis,WORD ez_logic, WORD ez_mode);

DMC2610_API void __stdcall d2610_config_LTC_PIN(WORD axis,WORD ltc_logic, WORD ltc_mode);

DMC2610_API void __stdcall d2610_config_latch_mode(WORD cardno, WORD all_enable);
DMC2610_API void __stdcall d2610_counter_config(WORD axis,WORD mode);
DMC2610_API long __stdcall d2610_get_latch_value(WORD axis);
DMC2610_API long __stdcall d2610_get_latch_flag(WORD cardno);
DMC2610_API void __stdcall d2610_reset_latch_flag(WORD cardno);

DMC2610_API void __stdcall d2610_reset_clear_flag(WORD cardno);

DMC2610_API void __stdcall d2610_triger_chunnel(WORD cardno, WORD num);
DMC2610_API void __stdcall d2610_set_speaker_logic(WORD cardno, WORD logic);

//other
/********************************************************************************
** 函数名称: d2610_config_EMG_PIN
** 功能描述: EMG设置
** 输　  入: axis - (0 - 3), enable - 0:无效; 1:有效
**              emg_logic: 0:低有效; 1:高有效
** 返 回 值: 无 
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_EMG_PIN(WORD cardno, WORD enable,WORD emg_logic);


//滤波器配置
/********************************************************************************
** 函数名称: d2610_config_LTC_filter
** 功能描述: 配置LTC信号的滤波器参数，四轴同时配置
** 输　  入: cardno : 卡号
             WORD width: 0-255;  范围可配置为 8MHZ ~ 32K Hz, 高于设定频率的信号会被滤掉.
                  滤波频率的计算: f = 8M Hz / (width + 1)
             WORD enable
** 返 回 值: 无
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_LTC_filter(WORD cardno,WORD width, WORD enable);

/********************************************************************************
** 函数名称: d2610_config_encoder_filter
** 功能描述: 配置编码器EA, EB, EZ的滤波器参数，各轴单独配置
** 输　  入: axis : 轴号, 多卡运行时轴号依次往后排, 如第二张卡: 轴号(4 - 7) 
             WORD width: 0-255;  范围可配置为 8MHZ ~ 32K Hz, 高于设定频率的信号会被滤掉.
                  滤波频率的计算: f = 8M Hz / (width + 1) 
** 返 回 值: 无
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_encoder_filter(WORD axis,WORD width, WORD enable);


//增加同时起停操作
/********************************************************************************
** 函数名称: d2610_set_t_move_all
** 功能描述: 多轴同步运动设定
** 输　  入: TotalAxes: 轴数,  pAxis:轴列表, pDist:位移列表
             posi_mode: 0-相对, 1-绝对
** 返 回 值: 1:正确 , -1:参数错
*********************************************************************************/
INT32S __stdcall d2610_set_t_move_all(WORD TotalAxes, WORD *pAxis, long *pDist, WORD posi_mode);

/********************************************************************************
** 函数名称: d2610_start_move_all
** 功能描述: 多轴同步运动
** 输　  入: TotalAxes: 第一轴轴号
** 返 回 值: 1:正确 , -1:参数错  
*********************************************************************************/
INT32S __stdcall d2610_start_move_all(WORD FirstAxis);

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
INT32S __stdcall d2610_set_sync_option(WORD axis, WORD sync_stop_on, WORD cstop_output_on, WORD sync_option1, WORD sync_option2);

/********************************************************************************
** 函数名称: d2610_set_sync_stop_mode
** 功能描述: 设置同步停止的减速方式
** 输　  入: axis: 轴号
             stop_mode:  0- 立即停止, 1-减速停止
** 返 回 值: 1:正确 , -1:参数错    
*********************************************************************************/
INT32S __stdcall d2610_set_sync_stop_mode(WORD axis, WORD stop_mode); 

/********************************************************************************
** 函数名称: d2610_config_CSTA_PIN
** 功能描述: 设置同步启动信号, 只能为低有效, 配置为电平或是边沿信号触发,默认为电平触发
** 输　  入: axis: 轴号
             edge_mode:  0- 电平, 1-边沿
** 返 回 值: 1   
*********************************************************************************/
INT32S __stdcall d2610_config_CSTA_PIN(WORD axis, WORD edge_mode);

//设置脉冲当量和相关操作
INT32S __stdcall d2610_get_equiv(WORD axis, double *equiv);
INT32S __stdcall d2610_set_equiv(WORD axis, double new_equiv);

INT32S __stdcall d2610_get_position_unitmm(WORD axis, double * pos_by_mm);
INT32S __stdcall d2610_set_position_unitmm(WORD axis, double pos_by_mm);
INT32S __stdcall d2610_read_current_speed_unitmm(WORD axis, double *current_speed);

INT32S __stdcall d2610_get_encoder_unitmm(WORD axis, double *encoder_pos_by_mm);
INT32S __stdcall d2610_set_encoder_unitmm(WORD axis, double encoder_pos_by_mm);

void __stdcall d2610_arc_move_unitmm(WORD *axis,double *target_pos, double *cen_pos, WORD arc_dir);
void __stdcall d2610_rel_arc_move_unitmm(WORD *axis, double *rel_pos, double *rel_cen, WORD arc_dir);


//脉冲闭环操作
INT32S __stdcall d2610_pulse_loop(WORD axis);   


/********************************************************************************
** 函数名称: d2610_set_handwheel_inmode
** 功能描述: //手轮输入方式的允许
** 输　  入: 0:关闭， 1：打开 ，其他： 无操作
** 返 回 值: 无 
*********************************************************************************/
DMC2610_API void __stdcall d2610_enable_handwheel(WORD axis,WORD hand_enable);

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
DMC2610_API void __stdcall d2610_config_handle_freq(WORD cardno, WORD freq);

/********************************************************************************
** 函数名称: d2610_config_handle_multi
** 功能描述: 手轮脉冲的倍率设置
**            
** 输　  入: cardno: 卡号, 
**           multi: 手轮脉冲的倍率设置， 可设置为： 1 - 127, 默认值为1
                例，当multi = 2时，即输入一个脉冲，会输出2个脉冲
** 返 回 值: 无 
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_handle_multi(WORD cardno, WORD multi);

#ifdef __cplusplus
}
#endif

#endif 