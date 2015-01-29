#ifndef _DMC_LIB_H
#define _DMC_LIB_H

#ifdef __cplusplus
extern "C" {
#endif 

//��һ������Ķ�  //This segment should not be modified
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

typedef unsigned char  INT8U;                   /* defined for unsigned 8-bits integer variable 	�޷���8λ���ͱ���  */
typedef signed   char  INT8S;                   /* defined for signed 8-bits integer variable		�з���8λ���ͱ���  */
typedef unsigned short INT16U;                  /* defined for unsigned 16-bits integer variable 	�޷���16λ���ͱ��� */
typedef signed   short INT16S;                  /* defined for signed 16-bits integer variable 		�з���16λ���ͱ��� */
typedef unsigned int   INT32U;                  /* defined for unsigned 32-bits integer variable 	�޷���32λ���ͱ��� */
typedef int			   INT32S;                  /* defined for signed 32-bits integer variable 		�з���32λ���ͱ��� */
typedef float		   FP32;                    /* single precision floating point variable (32bits) �����ȸ�������32λ���ȣ� */
typedef double		   FP64;                    /* double precision floating point variable (64bits) ˫���ȸ�������64λ���ȣ� */


#define __DMC2610_EXPORTS

//������������
#ifdef __DMC2610_EXPORTS
	#define DMC2610_API __declspec(dllexport)
#else
	#define DMC2610_API __declspec(dllimport)
#endif

//---------------------   �忨��ʼ�����ú���  ----------------------
/********************************************************************************
** ��������: d2610_board_init
** ��������: ���ư��ʼ�������ó�ʼ�����ٶȵ�����
** �䡡  ��: ��
** �� �� ֵ: 0���޿��� 1-8���ɹ�(ʵ�ʿ���) 
*********************************************************************************/
DMC2610_API WORD __stdcall d2610_board_init(void);

/********************************************************************************
** ��������: d2610_board_close
** ��������: �ر����п�
** �䡡  ��: ��
** �� �� ֵ: ��
*********************************************************************************/
DMC2610_API void __stdcall d2610_board_close(void); 

/********************************************************************************
** ��������: ���ƿ���λ
** ��������: ��λ���п���ֻ���ڳ�ʼ�����֮����ã�
** �䡡  ��: ��
** �� �� ֵ: ��
*********************************************************************************/
DMC2610_API void __stdcall d2610_board_reset(void);


//���������������
/********************************************************************************
** ��������: d2610_set_pulse_outmode
** ��������: ���������ʽ������
** �䡡  ��: axis - (0 - 3), outmode: 0 - 7
**           6:�������壬A�೬ǰ; 7:�������壬B�೬ǰ
** �� �� ֵ: �� 
*********************************************************************************/
DMC2610_API void __stdcall d2610_set_pulse_outmode(WORD axis,WORD outmode);

//ר���ź����ú���
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

//ͨ������/������ƺ���
DMC2610_API int __stdcall d2610_read_inbit(WORD cardno, WORD bitno);
DMC2610_API void __stdcall d2610_write_outbit(WORD cardno, WORD bitno,WORD on_off);
DMC2610_API int __stdcall  d2610_read_outbit(WORD cardno, WORD bitno) ;
DMC2610_API long __stdcall d2610_read_inport(WORD cardno);
DMC2610_API long __stdcall d2610_read_outport(WORD cardno) ;
DMC2610_API void __stdcall d2610_write_outport(WORD cardno, DWORD port_value);

//�ƶ�����
DMC2610_API void __stdcall d2610_decel_stop(WORD axis,double Tdec);
DMC2610_API void __stdcall d2610_imd_stop(WORD axis);
DMC2610_API void __stdcall d2610_emg_stop(void) ;
DMC2610_API void __stdcall d2610_simultaneous_stop(WORD axis) ;

//λ�����úͶ�ȡ����
DMC2610_API long __stdcall d2610_get_position(WORD axis);
DMC2610_API void __stdcall d2610_set_position(WORD axis,long current_position);


//״̬��⺯��
DMC2610_API WORD __stdcall  d2610_check_done(WORD axis) ;
DMC2610_API WORD __stdcall d2610_prebuff_status(WORD axis);
DMC2610_API WORD __stdcall d2610_axis_io_status(WORD axis);
DMC2610_API WORD __stdcall d2610_axis_status(WORD axis);
DMC2610_API DWORD __stdcall d2610_get_rsts(WORD axis) ;


//�ٶ�����
DMC2610_API void __stdcall d2610_variety_speed_range(WORD axis,WORD chg_enable ,double Max_Vel);
DMC2610_API double __stdcall d2610_read_current_speed(WORD axis);
DMC2610_API void __stdcall d2610_change_speed(WORD axis,double Curr_Vel);
DMC2610_API void __stdcall d2610_set_vector_profile(double Min_Vel,double Max_Vel,double Tacc,double Tdec);
DMC2610_API void __stdcall d2610_set_profile(WORD axis,double Min_Vel,double Max_Vel,double Tacc,double Tdec);
DMC2610_API void __stdcall d2610_set_s_profile(WORD axis,double Min_Vel,double Max_Vel,double Tacc,double Tdec, long Sacc,long Sdec);
DMC2610_API void __stdcall d2610_set_st_profile(WORD axis,double Min_Vel, double Max_Vel,double Tacc,double Tdec, double Tsacc,double Tsdec);

DMC2610_API void __stdcall d2610_reset_target_position(WORD axis,long dist);

//����PCSλ�õľ���ֵ
DMC2610_API void __stdcall d2610_reset_target_position2(WORD axis,long dist);


//���ᶨ���˶�
DMC2610_API void __stdcall d2610_t_pmove(WORD axis,long Dist,WORD posi_mode);
DMC2610_API void __stdcall d2610_ex_t_pmove(WORD axis,long Dist,WORD posi_mode);
DMC2610_API void __stdcall d2610_s_pmove(WORD axis,long Dist,WORD posi_mode);
DMC2610_API void __stdcall d2610_ex_s_pmove(WORD axis,long Dist,WORD posi_mode);

//���������˶�
DMC2610_API void __stdcall d2610_s_vmove(WORD axis,WORD dir);
DMC2610_API void __stdcall d2610_t_vmove(WORD axis,WORD dir);

//���Բ岹
DMC2610_API void __stdcall d2610_t_line2(WORD axis1,long Dist1,WORD axis2,long Dist2,WORD posi_mode);
DMC2610_API void __stdcall d2610_t_line3(WORD *axis,long Dist1,long Dist2,long Dist3,WORD posi_mode);
DMC2610_API void __stdcall d2610_t_line4(WORD cardno,long Dist1,long Dist2,long Dist3,long Dist4,WORD posi_mode);
DMC2610_API void __stdcall d2610_t_line6(WORD cardno, long *p_dist, WORD posi_mode);

//�����˶�
DMC2610_API void __stdcall d2610_set_handwheel_inmode(WORD axis,WORD inmode,WORD count_dir);
DMC2610_API void __stdcall d2610_handwheel_move(WORD axis,double vh);

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
DMC2610_API void __stdcall d2610_config_home_mode(WORD axis,WORD mode,WORD EZ_count);
DMC2610_API void __stdcall d2610_home_move(WORD axis,WORD home_mode,WORD vel_mode);

//Բ���岹
DMC2610_API void __stdcall d2610_arc_move(WORD *axis,long *target_pos,long *cen_pos, WORD arc_dir);
DMC2610_API void __stdcall d2610_rel_arc_move(WORD *axis,long *rel_pos,long *rel_cen, WORD arc_dir);


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
DMC2610_API void __stdcall d2610_config_CMP_PIN(WORD axis, WORD cmp1_enable,  WORD cmp2_enable, WORD CMP_logic);

DMC2610_API int __stdcall d2610_read_CMP_PIN(WORD axis);
DMC2610_API void __stdcall d2610_write_CMP_PIN(WORD axis, WORD on_off);

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
void __stdcall d2610_config_comparator(WORD axis, WORD cmp1_condition, WORD cmp2_condition, WORD source_sel,WORD SL_action);

/********************************************************************************
** ��������: d2610_set_comparator_data
** ��������: ���ñȽ����� 
** �䡡  ��: axis - ���
             cmp1_data: �Ƚϵ�1������
			 cmp2_data: �Ƚϵ�2������
**
** �� �� ֵ: �� 
*********************************************************************************/
void __stdcall d2610_set_comparator_data(WORD axis,long cmp1_data,long cmp2_data);


//---------------------   ��������������PLD  ----------------------//
DMC2610_API long __stdcall d2610_get_encoder(WORD axis);
DMC2610_API void __stdcall d2610_set_encoder(WORD axis,long encoder_value);

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
** ��������: d2610_config_EMG_PIN
** ��������: EMG����
** �䡡  ��: axis - (0 - 3), enable - 0:��Ч; 1:��Ч
**              emg_logic: 0:����Ч; 1:����Ч
** �� �� ֵ: �� 
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_EMG_PIN(WORD cardno, WORD enable,WORD emg_logic);


//�˲�������
/********************************************************************************
** ��������: d2610_config_LTC_filter
** ��������: ����LTC�źŵ��˲�������������ͬʱ����
** �䡡  ��: cardno : ����
             WORD width: 0-255;  ��Χ������Ϊ 8MHZ ~ 32K Hz, �����趨Ƶ�ʵ��źŻᱻ�˵�.
                  �˲�Ƶ�ʵļ���: f = 8M Hz / (width + 1)
             WORD enable
** �� �� ֵ: ��
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_LTC_filter(WORD cardno,WORD width, WORD enable);

/********************************************************************************
** ��������: d2610_config_encoder_filter
** ��������: ���ñ�����EA, EB, EZ���˲������������ᵥ������
** �䡡  ��: axis : ���, �࿨����ʱ�������������, ��ڶ��ſ�: ���(4 - 7) 
             WORD width: 0-255;  ��Χ������Ϊ 8MHZ ~ 32K Hz, �����趨Ƶ�ʵ��źŻᱻ�˵�.
                  �˲�Ƶ�ʵļ���: f = 8M Hz / (width + 1) 
** �� �� ֵ: ��
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_encoder_filter(WORD axis,WORD width, WORD enable);


//����ͬʱ��ͣ����
/********************************************************************************
** ��������: d2610_set_t_move_all
** ��������: ����ͬ���˶��趨
** �䡡  ��: TotalAxes: ����,  pAxis:���б�, pDist:λ���б�
             posi_mode: 0-���, 1-����
** �� �� ֵ: 1:��ȷ , -1:������
*********************************************************************************/
INT32S __stdcall d2610_set_t_move_all(WORD TotalAxes, WORD *pAxis, long *pDist, WORD posi_mode);

/********************************************************************************
** ��������: d2610_start_move_all
** ��������: ����ͬ���˶�
** �䡡  ��: TotalAxes: ��һ�����
** �� �� ֵ: 1:��ȷ , -1:������  
*********************************************************************************/
INT32S __stdcall d2610_start_move_all(WORD FirstAxis);

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
INT32S __stdcall d2610_set_sync_option(WORD axis, WORD sync_stop_on, WORD cstop_output_on, WORD sync_option1, WORD sync_option2);

/********************************************************************************
** ��������: d2610_set_sync_stop_mode
** ��������: ����ͬ��ֹͣ�ļ��ٷ�ʽ
** �䡡  ��: axis: ���
             stop_mode:  0- ����ֹͣ, 1-����ֹͣ
** �� �� ֵ: 1:��ȷ , -1:������    
*********************************************************************************/
INT32S __stdcall d2610_set_sync_stop_mode(WORD axis, WORD stop_mode); 

/********************************************************************************
** ��������: d2610_config_CSTA_PIN
** ��������: ����ͬ�������ź�, ֻ��Ϊ����Ч, ����Ϊ��ƽ���Ǳ����źŴ���,Ĭ��Ϊ��ƽ����
** �䡡  ��: axis: ���
             edge_mode:  0- ��ƽ, 1-����
** �� �� ֵ: 1   
*********************************************************************************/
INT32S __stdcall d2610_config_CSTA_PIN(WORD axis, WORD edge_mode);

//�������嵱������ز���
INT32S __stdcall d2610_get_equiv(WORD axis, double *equiv);
INT32S __stdcall d2610_set_equiv(WORD axis, double new_equiv);

INT32S __stdcall d2610_get_position_unitmm(WORD axis, double * pos_by_mm);
INT32S __stdcall d2610_set_position_unitmm(WORD axis, double pos_by_mm);
INT32S __stdcall d2610_read_current_speed_unitmm(WORD axis, double *current_speed);

INT32S __stdcall d2610_get_encoder_unitmm(WORD axis, double *encoder_pos_by_mm);
INT32S __stdcall d2610_set_encoder_unitmm(WORD axis, double encoder_pos_by_mm);

void __stdcall d2610_arc_move_unitmm(WORD *axis,double *target_pos, double *cen_pos, WORD arc_dir);
void __stdcall d2610_rel_arc_move_unitmm(WORD *axis, double *rel_pos, double *rel_cen, WORD arc_dir);


//����ջ�����
INT32S __stdcall d2610_pulse_loop(WORD axis);   


/********************************************************************************
** ��������: d2610_set_handwheel_inmode
** ��������: //�������뷽ʽ������
** �䡡  ��: 0:�رգ� 1���� �������� �޲���
** �� �� ֵ: �� 
*********************************************************************************/
DMC2610_API void __stdcall d2610_enable_handwheel(WORD axis,WORD hand_enable);

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
DMC2610_API void __stdcall d2610_config_handle_freq(WORD cardno, WORD freq);

/********************************************************************************
** ��������: d2610_config_handle_multi
** ��������: ��������ı�������
**            
** �䡡  ��: cardno: ����, 
**           multi: ��������ı������ã� ������Ϊ�� 1 - 127, Ĭ��ֵΪ1
                ������multi = 2ʱ��������һ�����壬�����2������
** �� �� ֵ: �� 
*********************************************************************************/
DMC2610_API void __stdcall d2610_config_handle_multi(WORD cardno, WORD multi);

#ifdef __cplusplus
}
#endif

#endif 