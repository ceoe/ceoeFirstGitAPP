using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows;



namespace MotionTest
{
    
    #region 各种运动模式下的结构参数(T,SD,ST,Vector)

    public struct AxisResetModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
    }

    public struct AxisTModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
    }

    //S型加减速提供 STS 中S段长度的参数  Distance=（MAX+MIN）/2 * T， Distance*0.8/2
    // (MAX-MIN)/AccOrDec= TimeofAccORDec

    public struct AxisSPModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
        public int DistanceofSAcc;
        public int DistanceofSDec;
    }
    //S型加减速提供 STS 中S段时间的参数
    public struct AxisSTModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
        public double TimeofSAcc;
        public double TimeofSDec;
    }

    public struct AxisVectorModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
    }

    #endregion

    public class Axis
    {
        #region Field of AxisParameters 轴参数字段
        private double _pulseOfPerMilMeter;
        private ushort _axisId;
        private ushort _axisPulseOutMode;
        private long _maxRouteDistance;
        private int _logicOrgPosition;

        public AxisResetModeMoveParameters axisResetModeMoveParameters;
        public AxisTModeMoveParameters axisTModeMoveParameters;
        public AxisSPModeMoveParameters axisSPModeMoveParameters;
        public AxisSTModeMoveParameters axisSTModeMoveParameters;
        public AxisVectorModeMoveParameters axisVectorModeMoveParameters;
        public Stack<string>  AxisStatusStack=new Stack<string>();

        public double PulseOfPerMilMeter
        {
            get { return _pulseOfPerMilMeter; }
        }

        public long MaxRouteDistance
        {
            get { return _maxRouteDistance; }
        }

        public ushort AxisId
        {
            get { return _axisId; }
        }

        public ushort AxisPulseOutMode
        {
            get { return _axisPulseOutMode; }
        }

        public int LogicOrgPosition
        {
            get { return _logicOrgPosition; }
        }

        #endregion

        private double CalcTimeofAccDec(double StartVelocity, double EndVelocity, double AccOrDecVelocity)
        {
            return (EndVelocity * PulseOfPerMilMeter - StartVelocity * PulseOfPerMilMeter) / (AccOrDecVelocity * PulseOfPerMilMeter);
        }

        #region 构造方法  脉冲输出模式，毫米脉冲数，ALM有效电平及相应后的动作，INP信号，Encoder Count计数方式

        public Axis(AxisID id, AxisPulseOutMode axisPulseOutMode, double pulseOfMilMeter, long maxRouteDistance, long logicOrgPosition, AxisINPSIG inpsig)
        {
            _axisId = Convert.ToUInt16(id);
            _pulseOfPerMilMeter = pulseOfMilMeter;
            _maxRouteDistance = (long)(maxRouteDistance * PulseOfPerMilMeter);
            _logicOrgPosition = (int)(logicOrgPosition * PulseOfPerMilMeter);
            _axisPulseOutMode = Convert.ToUInt16(axisPulseOutMode);

            //轴脉冲输出模式
            Dmc2610.d2610_set_pulse_outmode(_axisId, Convert.ToUInt16(AxisPulseOutMode));
            //ALM信号定义： 低电平有效，触发后立即停止
            Dmc2610.d2610_config_ALM_PIN(_axisId, Convert.ToUInt16(AxisALMLogic.HighLevelVaild),
                Convert.ToUInt16(AxisALMStopMode.ImmediateStop));
            //INP信号低电平有效, 发送完成指令脉冲后立即置check_done 完成，无需等待，否则需得到INP为低电平才置位check_done
            if (_axisPulseOutMode<4)
            {
                Dmc2610.d2610_config_INP_PIN(_axisId, Convert.ToUInt16(AxisINPSIG.Enable), Convert.ToUInt16(AxisINPLogic.LowLevelVaild));
            }
            else
            {
                Dmc2610.d2610_config_INP_PIN(_axisId, Convert.ToUInt16(AxisINPSIG.Enable), Convert.ToUInt16(AxisINPLogic.HighLevelVaild));
            }
         

            //Emergy Stop 信号定义 0为1号卡  1允许，1 高电平有效
            Dmc2610.d2610_config_EMG_PIN(0,1,0);

            //编码器计数方式为： AB相 EA单路信号4倍。(无卡时，初始化这一项会出现内存存储违规，故暂时取消掉)
            Dmc2610.d2610_counter_config(_axisId, Convert.ToUInt16(EnCoderCountMode.ABPhased4xEA));
            //Dmc2610.d2610_set_encoder(_axisId, 0);


            //设置Home PIN的回原点以及滤波器开关。(无卡时，初始化这一项会出现内存存储违规，故暂时取消掉)
            Dmc2610.d2610_set_HOME_pin_logic(AxisId, Convert.ToUInt16(AxisHOMEOrgLogic.LowLevelVaild), Convert.ToUInt16(AxisHOMEUseFilter.Enable));
            Dmc2610.d2610_config_home_mode(AxisId, Convert.ToUInt16(AxisHomeMode.HomeCountOnly), Convert.ToUInt16(0));
        }

        #endregion

        #region 各种速度模式的配置参数集 Tmode, SPMode, STMode,VectorMode

        //设置T形速度方式 ，参数：最小，最大速度，加减速速度，
        //  T Constant T模式
        public void AxisSetTMoveParameters(double startVelocity, double maxVelocity, double accVelocity,
            double decVelocity)
        {
            double timeofAcc = CalcTimeofAccDec(startVelocity, maxVelocity, accVelocity);
            double timeofDec = CalcTimeofAccDec(startVelocity, maxVelocity, decVelocity);
            
            axisTModeMoveParameters.StartVelocity = startVelocity * PulseOfPerMilMeter;
            axisTModeMoveParameters.MaxVelocity = maxVelocity * PulseOfPerMilMeter ;


            axisTModeMoveParameters.TimeofAcc = timeofAcc;
            axisTModeMoveParameters.TimeofDec = timeofDec;

        }

        public void SetTModeProfile()
        {
            Dmc2610.d2610_set_profile(AxisId, Convert.ToDouble(axisTModeMoveParameters.StartVelocity),
                  Convert.ToDouble(axisTModeMoveParameters.MaxVelocity), Convert.ToDouble(axisTModeMoveParameters.TimeofAcc),
                   Convert.ToDouble(axisTModeMoveParameters.TimeofDec));
        }
        public void AxisSetResetMoveParameters(double startVelocity, double maxVelocity, double accVelocity,
           double decVelocity)
        {

            double timeofAcc = CalcTimeofAccDec(startVelocity, maxVelocity, accVelocity);
            double timeofDec = CalcTimeofAccDec(startVelocity, maxVelocity, decVelocity);

            axisResetModeMoveParameters.StartVelocity = startVelocity * PulseOfPerMilMeter;
            axisResetModeMoveParameters.MaxVelocity = maxVelocity * PulseOfPerMilMeter;
           
            axisResetModeMoveParameters.TimeofAcc = timeofAcc;
            axisResetModeMoveParameters.TimeofDec = timeofDec;

        }
        public void SetResetModeProfile()
        {
            Dmc2610.d2610_set_profile(AxisId, Convert.ToDouble(axisResetModeMoveParameters.StartVelocity),
                  Convert.ToDouble(axisResetModeMoveParameters.MaxVelocity), Convert.ToDouble(axisResetModeMoveParameters.TimeofAcc),
                   Convert.ToDouble(axisResetModeMoveParameters.TimeofDec));
        }
        //设置S形速度方式 ，参数：最小，最大速度，加减速速度，
        //  由此计算得到的总体加减速时间及加减速段距离，并将这段加减速距离按照一定比例分配给S段。
        //  STS Constant STS 模式
        public void AxisSetSPMoveParameters(double startVelocity, double maxVelocity, double accVelocity,
            double decVelocity, float SPscale)
        {

           
            double timeofAcc = CalcTimeofAccDec(startVelocity, maxVelocity, accVelocity);
            double timeofDec = CalcTimeofAccDec(startVelocity, maxVelocity, decVelocity);
            //  /5*4 =80%  Distance * 80%
            axisSPModeMoveParameters.DistanceofSAcc =
                Convert.ToInt32((maxVelocity * PulseOfPerMilMeter + startVelocity * PulseOfPerMilMeter) / 2 * timeofAcc * (SPscale > 0.8 ? 0.8 : SPscale) / 2);
            axisSPModeMoveParameters.DistanceofSDec =
                Convert.ToInt32((maxVelocity * PulseOfPerMilMeter + startVelocity * PulseOfPerMilMeter) / 2 * timeofDec * (SPscale > 0.8 ? 0.8 : SPscale) / 2);

            axisSPModeMoveParameters.StartVelocity = startVelocity * PulseOfPerMilMeter;
            axisSPModeMoveParameters.MaxVelocity = maxVelocity * PulseOfPerMilMeter;
            axisSPModeMoveParameters.TimeofAcc = timeofAcc;
            axisSPModeMoveParameters.TimeofDec = timeofDec;
        }

        public void SetSPModeProfile()
        {
            Dmc2610.d2610_set_s_profile(AxisId, axisSPModeMoveParameters.StartVelocity,
                 axisSPModeMoveParameters.MaxVelocity, axisSPModeMoveParameters.TimeofAcc,
                 axisSPModeMoveParameters.TimeofDec, axisSPModeMoveParameters.DistanceofSAcc, axisSPModeMoveParameters.DistanceofSDec);
        }

        //设置S形速度方式 ，参数：最小，最大速度，加减速速度，
        //  由此计算得到的总体加减速时间，并将这段加减速时间段按照一定比例分配给S段。
        //  STS Constant STS 模式
        public void AxisSetSTMoveParameters(double startVelocity, double maxVelocity, double accVelocity,
            double decVelocity, float STscale)
        {
           
            double timeofAcc = CalcTimeofAccDec(startVelocity, maxVelocity, accVelocity);
            double timeofDec = CalcTimeofAccDec(startVelocity, maxVelocity, decVelocity);
            //  /5*4 =80%  Distance * 80%
            axisSPModeMoveParameters.TimeofAcc = timeofAcc / 2 * (STscale > 0.9 ? 0.9 : STscale);
            axisSPModeMoveParameters.TimeofDec = timeofDec / 2 * (STscale > 0.9 ? 0.9 : STscale);

            axisSPModeMoveParameters.StartVelocity = startVelocity * PulseOfPerMilMeter;
            axisSPModeMoveParameters.MaxVelocity = maxVelocity * PulseOfPerMilMeter;
            axisSPModeMoveParameters.TimeofAcc = timeofAcc;
            axisSPModeMoveParameters.TimeofDec = timeofDec;
        }

        public void SetSTModeProfile()
        {
            Dmc2610.d2610_set_st_profile(AxisId, axisSPModeMoveParameters.StartVelocity,
                axisSPModeMoveParameters.MaxVelocity, axisSPModeMoveParameters.TimeofAcc,
                axisSPModeMoveParameters.TimeofDec, axisSPModeMoveParameters.TimeofAcc, axisSPModeMoveParameters.TimeofDec);
        }

        public void AxisSetVectorMoveParameters(double startVelocity, double maxVelocity, double accVelocity,
            double decVelocity, float Vscale)
        {
          
            double timeofAcc = CalcTimeofAccDec(startVelocity, maxVelocity, accVelocity);
            double timeofDec = CalcTimeofAccDec(startVelocity, maxVelocity, decVelocity);

            axisVectorModeMoveParameters.StartVelocity = startVelocity * PulseOfPerMilMeter * Vscale;
            axisVectorModeMoveParameters.MaxVelocity = maxVelocity * PulseOfPerMilMeter * Vscale;
            axisVectorModeMoveParameters.TimeofAcc = timeofAcc;
            axisVectorModeMoveParameters.TimeofDec = timeofDec;
        }

        public void SetVectorModeProfile()
        {
            Dmc2610.d2610_set_vector_profile(axisVectorModeMoveParameters.StartVelocity,
                axisVectorModeMoveParameters.MaxVelocity, axisVectorModeMoveParameters.TimeofAcc,
                axisVectorModeMoveParameters.TimeofDec);
        }

        #endregion

    }

    public class Motion2610Control
    {
        private long[] _logicOrgPosition = new long[6];
        private long[] _maxRouteDistance = new long[6];


        private const long MaxDistanceValue = 9000000000;
        private const long VelocityLimit = 50000000;
        private const double TimeofAccDec = 0.005;
        

        #region CheckStatus function

        public static bool GetAxisIsDoWell(Axis axis)
        {
            bool result = (Dmc2610.d2610_check_done(axis.AxisId) == 1) ? true : false;
            return result;
        }
        public static bool GetAxisIsEMGON(Axis axis)
        {
            bool result = (((ushort)Dmc2610.d2610_get_rsts(axis.AxisId) & (1 << 7)) == (1 << 7)) ? true : false;
            return result;
        }
        public static bool GetAxisIsINPON(Axis axis)
        {
            bool result = ((((ushort)Dmc2610.d2610_get_rsts(axis.AxisId)) & (1 << 15)) == (1 << 15)) ? true : false;
            return result;
        }
        public static bool GetAxisIsALMON(Axis axis)
        {
            bool result = (((Dmc2610.d2610_axis_io_status(axis.AxisId)) & (1 << 11)) == (1 << 11)) ? true : false;
            return result;
        }
        public static bool GetAxisIsORGON(Axis axis)
        {
            bool result = (((Dmc2610.d2610_axis_io_status(axis.AxisId)) & (1 << 14)) == (1 << 14)) ? true : false;
            return result;
        }
        public static bool GetAxisIsPELON(Axis axis)
        {
            bool result = ((Dmc2610.d2610_axis_io_status(axis.AxisId) & (1 << 12)) == (1 << 12)) ? true : false;
            return result;
        }
        public static bool GetAxisIsNELON(Axis axis)
        {
            bool result = ((Dmc2610.d2610_axis_io_status(axis.AxisId) & (1 << 13)) == (1 << 13)) ? true : false;
            return result;
        }

        public static bool GetAxisIsReadyPIN(Axis axis)
        {
            bool result = (Dmc2610.d2610_read_RDY_PIN(axis.AxisId) == (ushort)AxisReadyPINLogic.IsReady) ? true : false;
            return result;
        }
        #endregion

        public static void InitinalDMC2610()
        {
            // DMC2610卡的函数调用                       
            UInt16 nCard = 0;
            nCard = Dmc2610.d2610_board_init();//'为控制卡分配系统资源，并初始化控制卡。
            if (nCard <= 0)//DMC1000控制卡初始化
            {
                MessageBox.Show("未找到DMC2610控制卡!", "警告");
                return;//退出当前程序  
            }
        }
        public static void CloseDMC2610()
        {
            Dmc2610.d2610_board_close();
        }

        public static void ResetDMC2610()
        {
            Dmc2610.d2610_board_reset();
        }

        public  static  void HomeMove(Axis axis)
        {
            
            if ((axis.axisTModeMoveParameters.MaxVelocity > 0) && (axis.axisTModeMoveParameters.MaxVelocity < 50000000))
            {
                if (!((Dmc2610.d2610_read_RDY_PIN(axis.AxisId) == 0) && (GetAxisIsALMON(axis)) && (GetAxisIsEMGON(axis))))
                {
                    if (!(GetAxisIsNELON(axis) && GetAxisIsPELON(axis)))
                    {
                        if (!(GetAxisIsORGON(axis)))
                        {
                            axis.SetResetModeProfile();
                            Dmc2610.d2610_home_move(axis.AxisId, (ushort) AxisHomeMoveDirection.Reverse,
                                (ushort) AxisHomeVelocityMode.SlowlySpeedandStop);
                        }
                        else
                        {
                            if ((GetAxisIsORGON(axis)))
                            {
                                axis.SetResetModeProfile();
                                Dmc2610.d2610_t_pmove(axis.AxisId, 10000, (ushort) CoordinateMode.Relation);
                                while (!GetAxisIsDoWell(axis))
                                {

                                }
                                axis.SetResetModeProfile();
                                Dmc2610.d2610_home_move(axis.AxisId, (ushort) AxisHomeMoveDirection.Reverse,
                                    (ushort) AxisHomeVelocityMode.SlowlySpeedandStop);

                                while (!GetAxisIsDoWell(axis))
                                {
                                }
                                Dmc2610.d2610_set_position(axis.AxisId, 0);
                            }
                        }
                    }else
                    {
                        if (GetAxisIsNELON(axis) && (!GetAxisIsPELON(axis)))
                        {
                            axis.SetResetModeProfile();
                            Dmc2610.d2610_t_pmove(axis.AxisId, 10000, (ushort)CoordinateMode.Relation);
                            while (!GetAxisIsDoWell(axis))
                            {
                            }
                            axis.SetResetModeProfile();
                            Dmc2610.d2610_home_move(axis.AxisId, (ushort)AxisHomeMoveDirection.Reverse,
                                (ushort)AxisHomeVelocityMode.SlowlySpeedandStop);
                        }
                        else
                        {
                            axis.SetResetModeProfile();
                            Dmc2610.d2610_home_move(axis.AxisId, (ushort)AxisHomeMoveDirection.Reverse,
                                (ushort)AxisHomeVelocityMode.SlowlySpeedandStop);
                        }
                    }
                    while (!GetAxisIsDoWell(axis))
                    {
                    }
                    //axis.SetTModeProfile();
                    //Dmc2610.d2610_t_pmove(axis.AxisId, axis.LogicOrgPosition, (ushort)AxisPositionMode.Relation);
                    axis.SetResetModeProfile();
                    Dmc2610.d2610_set_position(axis.AxisId, 0);
                    Dmc2610.d2610_t_pmove(axis.AxisId, axis.LogicOrgPosition, (ushort) CoordinateMode.Absolut);
                    while (!GetAxisIsDoWell(axis))
                    {
                    }
                    Thread.Sleep(500);
                    Dmc2610.d2610_set_position(axis.AxisId, 0);
               
                }
                else
                {
                    MessageBox.Show("Axis is Not Ready or occur  EMG Stop !");
                }
            }
            else
            {
                MessageBox.Show("Axis Parameters of AcclerateVelocity is Incorrect !");
            }
        }

        public static void ArcMoveUseVectorMode(AxisID axis1, AxisID axis2, PointF tartgetPointF, PointF centroPointF,
            ArcDirectory arcDirectory)
        {
            var aixsGroup = new ushort[2];
            aixsGroup[0] = (ushort)axis1;
            aixsGroup[1] = (ushort)axis2;

            var targetPoint = new long[2];
            targetPoint[0] = (long)tartgetPointF.X;
            targetPoint[1] = (long)tartgetPointF.Y;
        }

        public static bool SigelAxisPMoveAbsolutUseTMode(Axis axis,float dis)
        {
            bool OrderIsCompeleted = false;
            int position = Convert.ToInt32(dis*axis.PulseOfPerMilMeter);
            if (axis.MaxRouteDistance > position && (position >= 0))
            {
                axis.SetTModeProfile();
                if (AxisQueryStatus(axis))
                {
                    Dmc2610.d2610_t_pmove(axis.AxisId,position,(ushort)CoordinateMode.Absolut);
                    while (!GetAxisIsDoWell(axis))
                    {
                    }
                    OrderIsCompeleted = true;
                }
            }
            return OrderIsCompeleted;
        }

// ReSharper disable InconsistentNaming
        public static bool XYPMoveAbsolutUseTMode(Axis axisX, Axis axisY, float x, float y)
// ReSharper restore InconsistentNaming
        {
            bool OrderIsCompeleted = false;
            int xposition = Convert.ToInt32(x * axisX.PulseOfPerMilMeter);
            int yposition = Convert.ToInt32(y * axisY.PulseOfPerMilMeter);
            if (axisX.MaxRouteDistance > xposition && (xposition >= 0))
            {
                if (axisY.MaxRouteDistance > yposition && (yposition >= 0))
                axisX.SetTModeProfile();
                axisY.SetTModeProfile();
                if (AxisQueryStatus(axisX) && AxisQueryStatus(axisY))
                {
                    Dmc2610.d2610_t_pmove(axisX.AxisId, xposition, (ushort)CoordinateMode.Absolut);
                    Dmc2610.d2610_t_pmove(axisY.AxisId, yposition, (ushort)CoordinateMode.Absolut);
                    //while ((!GetAxisIsINPON(axisX)) && (!GetAxisIsINPON(axisY)))
                    //{
                        
                    //}
                    while (!(GetAxisIsDoWell(axisX) && (GetAxisIsDoWell(axisY))))
                    {
                    }
                    OrderIsCompeleted = true;
                }
            }
            return OrderIsCompeleted;
        }


        public static bool AxisQueryStatus(Axis axis)
        {
            bool AxisIsReadytoMotion = false;

            if (axis.AxisStatusStack.Count>0)
            {
                axis.AxisStatusStack.Clear();
            }
            #region 对ReadyPIN ,ALM, EMG STOP,Negative Limite Positive Limited 进行判断
            if (GetAxisIsReadyPIN(axis))
            {
                string tempstr = axis.AxisId + " Axis Ready PIN is Not Ready! \n";
                axis.AxisStatusStack.Push(tempstr);
            }
            if ((GetAxisIsALMON(axis)))
            {
                string tempstr = axis.AxisId + " Axis Alarm PIN is Actived! \n";
                axis.AxisStatusStack.Push(tempstr);
            }
            if ((GetAxisIsEMGON(axis)))
            {
                string tempstr = axis.AxisId + " Axis Emergy Stop is Actived! \n";
                axis.AxisStatusStack.Push(tempstr);
            }
            if ((GetAxisIsNELON(axis)))
            {
                string tempstr = axis.AxisId + " Axis Negative Limit Sensor is Actived! \n";
                axis.AxisStatusStack.Push(tempstr);
            }
            if (GetAxisIsPELON(axis))
            {
                string tempstr = axis.AxisId + " Axis Positive Limit Sensor is Actived! \n";
                axis.AxisStatusStack.Push(tempstr);
            }

            #endregion
           #region 对所有模式下的速度，加速度以及加速时间进行判断
            if (axis.axisResetModeMoveParameters.StartVelocity > VelocityLimit || axis.axisTModeMoveParameters.StartVelocity > VelocityLimit || axis.axisSPModeMoveParameters.StartVelocity > VelocityLimit)
            {
                string tempstr = axis.AxisId + " Axis StartVelocity Out of Range " + VelocityLimit + "  ! \n";
                axis.AxisStatusStack.Push(tempstr);
            }
            if (axis.axisResetModeMoveParameters.MaxVelocity > VelocityLimit || axis.axisTModeMoveParameters.MaxVelocity > VelocityLimit || axis.axisSPModeMoveParameters.MaxVelocity > VelocityLimit)
            {
                string tempstr = axis.AxisId + " Axis MaxVelocity Out of Range " + VelocityLimit + "  ! \n";
                axis.AxisStatusStack.Push(tempstr);
            }
            if (axis.axisResetModeMoveParameters.TimeofAcc < TimeofAccDec || axis.axisTModeMoveParameters.TimeofAcc < TimeofAccDec || axis.axisSPModeMoveParameters.TimeofAcc < TimeofAccDec)
            {
                string tempstr = axis.AxisId + " Axis Time of Accelerate Out of Range " + TimeofAccDec + "  ! \n";
                axis.AxisStatusStack.Push(tempstr);
            }

            #endregion
            

            if (axis.AxisStatusStack.Count==0)
            {
                AxisIsReadytoMotion = true;
            }
            return AxisIsReadytoMotion;
        }

        public static void AllAxisEMGStop()
        {
            Dmc2610.d2610_emg_stop();
        }

    }

    }


