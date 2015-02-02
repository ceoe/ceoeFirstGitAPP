using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using DrilTapeTest1;

namespace DrilTapeTest1
{

    #region About DMC2610常量定义

    internal enum AxisID : ushort
    {
        XAxis = 0,
        YAxis = 1,
        ZAxis = 2,
        UAxis = 3,
        AAxis = 4,
        BAxis = 5
    };


    internal enum AxisPulseOutMode : ushort
    {
        PM_PLDL = 0,
        PM_PHDL = 1,
        PM_PLDH = 2,
        PM_PHDH = 3,
        PM_PHDHPHDH = 4,
        PM_PLDLPLDL = 5
    };

    internal enum AxisPositionMode : ushort
    {
        Relation = 0,
        Absolut = 1
    };

    internal enum ArcDirectory : ushort
    {
        DirCW = 0,
        DirCCW = 1
    };
    internal enum EnCoderCountMode : ushort
    {
        PulseAndDir = 0,
        ABPhased1xEA = 1,
        ABPhased2xEA = 2,
        ABPhased4xEA = 3
    };
    internal enum AxisINPLogic : ushort
    {
        HighLevelVaild = 0,
        LowLevelVaild = 1
    };

    internal enum AxisINPSIG : ushort
    {
        Disable = 0,
        Enable = 1
    };

    internal enum AxisALMLogic : ushort
    {
        LowLevelVaild = 0,
        HighLevelVaild = 1
    };

    internal enum AxisALMAction : ushort
    {
        ImmediatelyStop = 0,
        SlowlyFalling = 1
    };

    internal enum AxisHOMEOrgLogic : ushort
    {
        LowLevelVaild = 0,
        HighLevelVaild = 1
    };

    internal enum AxisHOMEUseFilter : ushort
    {
        Disable = 0,
        Enable = 1
    };

    internal enum AxisHomeMode : ushort
    {
        HomeCountOnly = 0,
        HomeAndEZCount = 1
    };

    internal enum AxisHomeMoveDirection : ushort
    {
        Forward = 1,
        Reverse = 2
    };

    internal enum AxisHomeVelocityMode : ushort
    {
        SlowlySpeedandStop = 0,
        HighSpeedAndDecelerStop = 1
    };

    internal enum AxisServoON : ushort
    {
        OutPutLow = 0,
        OutputHigh = 1
    };

    internal enum AxisConfigEMGResponse : ushort
    {
        Diable = 0,
        Enable = 1
    };

    internal enum AxisConfigEMGLogic : ushort
    {
        LowLevelVaild = 0,
        HighLevelVaild = 1
    };

    #endregion

    #region 各种运动模式下的结构参数(T,SD,ST,Vector)

    internal struct AxisTModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
    }

    //S型加减速提供 STS 中S段长度的参数  Distance=（MAX+MIN）/2 * T， Distance*0.8/2
    // (MAX-MIN)/AccOrDec= TimeofAccORDec

    internal struct AxisSPModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
        public int DistanceofSAcc;
        public int DistanceofSDec;
    }
    //S型加减速提供 STS 中S段时间的参数
    internal struct AxisSTModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
        public double TimeofSAcc;
        public double TimeofSDec;
    }

    internal struct AxisVectorModeMoveParameters
    {
        public double StartVelocity;
        public double MaxVelocity;
        public double TimeofAcc;
        public double TimeofDec;
    }

    #endregion

    internal class Axis
    {
        #region Field of AxisParameters 轴参数字段

        private int pulseOfPerMeter;
        private ushort _axisId;
        private ushort _axisPulseOutMode;
        private long _logicOrgPosition;
        private long _maxRouteDistance;


        private const long MaxDistanceValue = 9000000000;
        private const long VelocityLimit = 5000000;

        private AxisTModeMoveParameters AxisTModeMoveParameters;
        private AxisSPModeMoveParameters AxisSPModeMoveParameters;
        private AxisSTModeMoveParameters AxisSTModeMoveParameters;
        private AxisVectorModeMoveParameters AxisVectorModeMoveParameters;

        #endregion

        private double CalcTimeofAccDec(double StartVelocity, double EndVelocity, double AccOrDecVelocity)
        {
            return (EndVelocity - StartVelocity)/AccOrDecVelocity;
        }

        #region 构造方法  脉冲输出模式，ALM有效电平及相应后的动作，INP信号，Encoder Count计数方式

        public Axis(AxisID id, AxisPulseOutMode axisPulseOutMode, AxisINPSIG inpsig, long logicORGPosition,
            long maxRouteDistance)
        {
            this._axisId = Convert.ToUInt16(id);
            this._axisPulseOutMode = Convert.ToUInt16(axisPulseOutMode);
            this._logicOrgPosition = logicORGPosition;
            this._maxRouteDistance = maxRouteDistance;
            //轴脉冲输出模式
            Dmc2610.d2610_set_pulse_outmode(_axisId, _axisPulseOutMode);
            //ALM信号定义： 低电平有效，触发后立即停止
            Dmc2610.d2610_config_ALM_PIN(_axisId, Convert.ToUInt16(AxisALMLogic.LowLevelVaild),
                Convert.ToUInt16(AxisALMAction.ImmediatelyStop));
            //INP信号低电平有效, 发送完成指令脉冲后立即置check_done 完成，无需等待，否则需得到INP为低电平才置位check_done
            Dmc2610.d2610_config_INP_PIN(_axisId, Convert.ToUInt16(inpsig), Convert.ToUInt16(AxisINPLogic.LowLevelVaild));
            //编码器计数方式为： AB相 EA单路信号4倍。
            Dmc2610.d2610_counter_config(_axisId, Convert.ToUInt16(EnCoderCountMode.ABPhased4xEA));


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

            AxisTModeMoveParameters.StartVelocity = startVelocity;
            AxisTModeMoveParameters.MaxVelocity = maxVelocity;
            AxisTModeMoveParameters.TimeofAcc = timeofAcc;
            AxisTModeMoveParameters.TimeofDec = timeofDec;

            Dmc2610.d2610_set_profile(_axisId, this.AxisTModeMoveParameters.StartVelocity,
                this.AxisTModeMoveParameters.MaxVelocity, AxisTModeMoveParameters.TimeofAcc,
                AxisTModeMoveParameters.TimeofDec);
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
            int distanceOfSAcc =
                Convert.ToInt32((maxVelocity + startVelocity)/2*timeofAcc*(SPscale > 0.8 ? 0.8 : SPscale)/2);
            int distanceOfSDec =
                Convert.ToInt32((maxVelocity + startVelocity)/2*timeofDec*(SPscale > 0.8 ? 0.8 : SPscale)/2);

            AxisSPModeMoveParameters.StartVelocity = startVelocity;
            AxisSPModeMoveParameters.MaxVelocity = maxVelocity;
            AxisSPModeMoveParameters.TimeofAcc = timeofAcc;
            AxisSPModeMoveParameters.TimeofDec = timeofDec;

            Dmc2610.d2610_set_s_profile(_axisId, AxisSPModeMoveParameters.StartVelocity,
                AxisSPModeMoveParameters.MaxVelocity, AxisSPModeMoveParameters.TimeofAcc,
                AxisSPModeMoveParameters.TimeofDec, distanceOfSAcc, distanceOfSDec);
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
            double timeOfSAcc = timeofAcc/2*(STscale > 0.9 ? 0.9 : STscale);
            double timeOfSDec = timeofDec/2*(STscale > 0.9 ? 0.9 : STscale);

            AxisSPModeMoveParameters.StartVelocity = startVelocity;
            AxisSPModeMoveParameters.MaxVelocity = maxVelocity;
            AxisSPModeMoveParameters.TimeofAcc = timeofAcc;
            AxisSPModeMoveParameters.TimeofDec = timeofDec;

            Dmc2610.d2610_set_st_profile(_axisId, AxisSPModeMoveParameters.StartVelocity,
                AxisSPModeMoveParameters.MaxVelocity, AxisSPModeMoveParameters.TimeofAcc,
                AxisSPModeMoveParameters.TimeofDec, timeOfSAcc, timeOfSDec);
        }

        public void AxisSetVectorMoveParameters(double startVelocity, double maxVelocity, double accVelocity,
            double decVelocity)
        {
            double timeofAcc = CalcTimeofAccDec(startVelocity, maxVelocity, accVelocity);
            double timeofDec = CalcTimeofAccDec(startVelocity, maxVelocity, decVelocity);

            AxisVectorModeMoveParameters.StartVelocity = startVelocity;
            AxisVectorModeMoveParameters.MaxVelocity = maxVelocity;
            AxisVectorModeMoveParameters.TimeofAcc = timeofAcc;
            AxisVectorModeMoveParameters.TimeofDec = timeofDec;

            Dmc2610.d2610_set_vector_profile(AxisVectorModeMoveParameters.StartVelocity,
                AxisVectorModeMoveParameters.MaxVelocity, AxisVectorModeMoveParameters.TimeofAcc,
                AxisVectorModeMoveParameters.TimeofDec);
        }

        #endregion



        public void ArcMoveUseVectorMode(AxisID axis1, AxisID axis2, PointF tartgetPointF, PointF centroPointF,
            ArcDirectory arcDirectory)
        {
            var aixsGroup = new ushort[2];
            aixsGroup[0] = (ushort) axis1;
            aixsGroup[1] = (ushort) axis2;

            var targetPoint = new long[2];
            targetPoint[0] = (long)tartgetPointF.X;
            targetPoint[1] = (long)tartgetPointF.Y;


        }
    }




}
