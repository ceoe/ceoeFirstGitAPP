using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace MotionTest
{
    #region About DMC2610常量定义

    public enum AxisID : ushort
    {
        XAxis = 0,
        YAxis = 1,
        ZAxis = 2,
        UAxis = 3,
        AAxis = 4,
        BAxis = 5
    };

    public enum MotionMode : int
    {
        Home = 0,
        KeepMotion = 1,
        OnceMove = 2,
        RoundTrip = 3,
        LinearInterpolation = 4,
        CircularInterpolation = 5
    };

    public enum AccelerateCurveMode : int
    {
        TCurve = 0,
        SCurve = 1
    };

    public enum AxisReadyPINLogic : ushort
    {
        NotReady = 0,
        IsReady = 1
    };

    public enum AxisPulseOutMode : ushort
    {
        PM_PLDL = 0,
        PM_PHDL = 1,
        PM_PLDH = 2,
        PM_PHDH = 3,
        PM_PHDHPHDH = 4,
        PM_PLDLPLDL = 5
    };

    public enum CoordinateMode : ushort
    {
        Relation = 0,
        Absolut = 1
    };

    public enum ArcDirectory : ushort
    {
        DirCW = (ushort)0,
        DirCCW = (ushort)1
    };

    public enum EnCoderCountMode : ushort
    {
        PulseAndDir = 0,
        ABPhased1xEA = 1,
        ABPhased2xEA = 2,
        ABPhased4xEA = 3
    };

    public enum AxisINPLogic : ushort
    {
        HighLevelVaild = 0,
        LowLevelVaild = 1
    };

    public enum AxisINPSIG : ushort
    {
        Disable = 0,
        Enable = 1
    };

    public enum AxisALMLogic : ushort
    {
        LowLevelVaild = 0,
        HighLevelVaild = 1
    };

    public enum AxisALMStopMode : ushort
    {
        ImmediateStop = 0,
        DecelerateStop = 1
    };

    public enum AxisStopAction : ushort
    {
        ImmediatelyStop = (ushort)0,
        SlowlyFalling = (ushort)1
    };

    public enum AxisHOMEOrgLogic : ushort
    {
        LowLevelVaild = 0,
        HighLevelVaild = 1
    };

    public enum AxisHOMEUseFilter : ushort
    {
        Disable = 0,
        Enable = 1
    };

    public enum AxisHomeMode : ushort
    {
        HomeCountOnly = 0,
        HomeAndEZCount = 1
    };

    public enum AxisHomeMoveDirection : ushort
    {
        Forward = 1,
        Reverse = 2
    };

    public enum AxisHomeVelocityMode : ushort
    {
        SlowlySpeedandStop = 0,
        HighSpeedAndDecelerStop = 1
    };

    public enum AxisServoON : ushort
    {
        OutPutLow = 0,
        OutputHigh = 1
    };

    public enum EMGResponse : ushort
    {
        Diable = 0,
        Enable = 1
    };

    public enum EMGLogic : ushort
    {
        LowLevelVaild = 0,
        HighLevelVaild = 1
    };

    public enum EZEnable : ushort
    {
        SearchHomeOnly = 0,
        SearchHomeAndEZCount = 1
    };

    public enum LTCLogic : ushort
    {
        VaildLOW = 0,
        VaildHIGH = 1
    };

    public enum FeedBackPulseINMode : ushort
    {
        PulseMinusDir = 0,

        // ReSharper disable once InconsistentNaming
        ABPluse = 1,

        // ReSharper disable once InconsistentNaming
        ABDouble = 2,

        // ReSharper disable once InconsistentNaming
        ABQuardruple = 3
    };

    public enum AxiseEL_Mode : ushort
    {
        LowLevelandImmediateStop = 0,
        LowLevelandDecelerateStop = 1,
        HighLevelandImmediateStop = 2,
        HighLevelandDecelerateStop = 3
    }

    #endregion About DMC2610常量定义

    public class GroupAxisParametersSets
    {
        private string axisName;
        private ushort axisID;
        private double initialSpeed;
        private double driveSpeed;
        private double tacc;
        private double tSacc;
        private bool ccw;
        private long endPosition;

        public string AxisName
        {
            get { return axisName; }
            set { axisName = value; }
        }

        public ushort AxisId
        {
            get { return axisID; }
            set { axisID = value; }
        }

        public double InitialSpeed
        {
            get { return initialSpeed; }
            set { initialSpeed = value; }
        }

        public double DriveSpeed
        {
            get { return driveSpeed; }
            set { driveSpeed = value; }
        }

        public double Tacc
        {
            get { return tacc; }
            set { tacc = value; }
        }

        public double TSacc
        {
            get { return tSacc; }
            set { tSacc = value; }
        }

        public bool CCWDIR
        {
            get { return ccw; }
            set { ccw = value; }
        }

        public long EndPosition
        {
            get { return endPosition; }
            set { endPosition = value; }
        }

        public GroupAxisParametersSets(int index)
        {
            this.axisID = (ushort)index;
            switch (index)
            {
                case 0:
                    axisName = "X";
                    break;

                case 1:
                    axisName = "Y";
                    break;

                case 2:
                    axisName = "Z";
                    break;

                case 3:
                    axisName = "U";
                    break;

                case 4:
                    axisName = "A";
                    break;

                case 5:
                    axisName = "B";
                    break;

                default:
                    axisName = "unkown";
                    break;
            }
        }
    }

    public class SingleAxisParameter
    {
        public AxisID IDnum { get; set; }

        public AxisPulseOutMode PULSEOUTMODE { get; set; }

        public AxisHomeMode HOMEMODE { get; set; }

        public AxisHOMEOrgLogic HOMELOGIC { get; set; }

        public AxisHomeVelocityMode HOMESPEEDMODE { get; set; }

        public LTCLogic LTCLOGIC { get; set; }

        public FeedBackPulseINMode PULSEINMODE { get; set; }

        public AxisINPSIG INPENABLE { get; set; }

        public AxisINPLogic INPLOGIC { get; set; }

        public AxisALMLogic ALMLOGIC { get; set; }

        public AxisALMStopMode ALMSTOPMODE { get; set; }

        public AxiseEL_Mode AxiseElMode { get; set; }

        public bool Elmode;
        public bool Ellogic;

        public void SetAxiseElMode()
        {
            if (Elmode && Ellogic)
            {
                AxiseElMode = AxiseEL_Mode.LowLevelandImmediateStop;
            }
            if (!Elmode && !Ellogic)
            {
                AxiseElMode = AxiseEL_Mode.HighLevelandDecelerateStop;
            }
            if (Elmode && !Ellogic)
            {
                AxiseElMode = AxiseEL_Mode.LowLevelandDecelerateStop;
            }
            if (!Elmode && Ellogic)
            {
                AxiseElMode = AxiseEL_Mode.HighLevelandImmediateStop;
            }
        }

        public override string ToString()
        {
            return IDnum.ToString();
        }



    }

    public class MotionSet
    {
        private MotionMode motionMode;
        private CoordinateMode coordinateMode;
        private AxisStopAction axisStopAction;

        public GroupAxisParametersSets[] GroupParametersSetses;

        public GroupAxisParametersSets this[int index]
        {
            set { GroupParametersSetses[index] = value; }
            get { return GroupParametersSetses[index]; }
        }

        public MotionSet(string path)
        {
            GroupParametersSetses = new GroupAxisParametersSets[6];
            int idnum = -1;
            string tempstr1;
            try
            {
                var m_SW = new StreamReader(path);

                var idstr = new Regex(@"\[AXES(?<ID>\d{1})\]", RegexOptions.IgnoreCase);

                var starSpeed = new Regex(@"STRVEL=(?<startspeed>\d*)",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                var maxSpeed = new Regex(@"MAXVEL=(?<maxspeed>\d*)",
                     RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                var endPosition = new Regex(@"POSITION=(?<endposition>\d*)",
                      RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                var timeOfAcc = new Regex(@"TACC=(?<timeofacc>\d{1}\.\d*)",
                      RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                var timeOfSAcc = new Regex(@"TSACC=(?<timeofsacc>\d{1}\.\d*)",
                      RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                var ccwDir = new Regex(@"DIR=(?<ccwdir>\d{1})",
                     RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                do
                {
                    tempstr1 = m_SW.ReadLine();
                    if (tempstr1.Contains("UTILITY"))
                    {
                        break;
                    }
                    Match axisOrdermatchs = idstr.Match(tempstr1);
                    if (axisOrdermatchs.Length > 0)
                    {
                        idnum = Convert.ToInt32(axisOrdermatchs.Result("${ID}"));
                        GroupParametersSetses[idnum] = new GroupAxisParametersSets(idnum);
                        continue;
                    }

                    Match rgMatch = starSpeed.Match(tempstr1);
                    if (rgMatch.Length > 0)
                    {
                        double speed = Convert.ToDouble(rgMatch.Result("${startspeed}"));
                        GroupParametersSetses[idnum].InitialSpeed = speed;
                        continue;
                    }

                    rgMatch = maxSpeed.Match(tempstr1);
                    if (rgMatch.Length > 0)
                    {
                        double speed = Convert.ToDouble(rgMatch.Result("${maxspeed}"));
                        GroupParametersSetses[idnum].DriveSpeed = speed;
                        continue;
                    }

                    rgMatch = endPosition.Match(tempstr1);
                    if (rgMatch.Length > 0)
                    {
                        long dst = Convert.ToInt64(rgMatch.Result("${endposition}"));
                        GroupParametersSetses[idnum].EndPosition = dst;
                        continue;
                    }

                    rgMatch = timeOfAcc.Match(tempstr1);
                    if (rgMatch.Length > 0)
                    {
                        double tacc = Convert.ToDouble(rgMatch.Result("${timeofacc}"));
                        GroupParametersSetses[idnum].Tacc = tacc;
                        continue;
                    }

                    rgMatch = timeOfSAcc.Match(tempstr1);
                    if (rgMatch.Length > 0)
                    {
                        double tsacc = Convert.ToDouble(rgMatch.Result("${timeofsacc}"));
                        GroupParametersSetses[idnum].TSacc = tsacc;
                        continue;
                    }

                    rgMatch = ccwDir.Match(tempstr1);
                    if (rgMatch.Length > 0)
                    {
                        int ccwdir = Convert.ToInt32(rgMatch.Result("${ccwdir}"));
                        GroupParametersSetses[idnum].CCWDIR = (ccwdir == 0) ? true : false;
                        continue;
                    }
                } while (tempstr1 != null);
            }
            catch (IOException ex)
            {
                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }
        }
    }

    public class AxisParaSet
    {
        public static EMGResponse EMGENABLE { get; set; }

        public static EMGLogic EMGLOGIC { get; set; }

        public List<SingleAxisParameter> ListAxisParametersSets = new List<SingleAxisParameter>();
        public SingleAxisParameter[] GroupAxisParametersSets;

        public SingleAxisParameter this[int index]
        {
            set { GroupAxisParametersSets[index] = value; }
            get { return GroupAxisParametersSets[index]; }
        }

        public AxisParaSet(string path)
        {
            GroupAxisParametersSets = new SingleAxisParameter[6];
            int setvalue = -1;
            string tempstr1;

            var idstr = new Regex(@"\[AXES(?<ID>\d{1})\]", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            SingleAxisParameter axis = null;
            try
            {
                Match match;
                var m_SW = new StreamReader(path);
                tempstr1 = m_SW.ReadLine();

                do
                {
                    #region 控制卡全局设置

                    var rguti = new Regex(@"\[UTILITY\]",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                    var rgemgenable = new Regex(@"EMGENABLE=(?<emgenable>\d{1})",
                      RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                    var emglogic = new Regex(@"EMGLOGIC=(?<emglogic>\d{1})",
                      RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

                    if (tempstr1.Contains("UTILITY"))
                    {
                        #region 判断是否为综合设置字段

                        do
                        {
                            tempstr1 = m_SW.ReadLine();

                            if (tempstr1.Contains("AXES"))
                            {
                                break;
                            }

                            match = rgemgenable.Match(tempstr1);
                            if (match.Length > 0)
                            {
                                setvalue = Convert.ToInt32(match.Result("${emgenable}"));
                                switch (setvalue)
                                {
                                    case 0:
                                        AxisParaSet.EMGENABLE = EMGResponse.Diable;
                                        break;

                                    case 1:
                                        AxisParaSet.EMGENABLE = EMGResponse.Enable;
                                        break;

                                    default:
                                        AxisParaSet.EMGENABLE = EMGResponse.Enable;
                                        break;
                                }
                                continue;
                            }

                            match = emglogic.Match(tempstr1);
                            if (match.Length > 0)
                            {
                                setvalue = Convert.ToInt32(match.Result("${emglogic}"));
                                switch (setvalue)
                                {
                                    case 0:
                                        AxisParaSet.EMGLOGIC = EMGLogic.LowLevelVaild;
                                        break;

                                    case 1:
                                        AxisParaSet.EMGLOGIC = EMGLogic.HighLevelVaild;
                                        break;

                                    default:
                                        AxisParaSet.EMGLOGIC = EMGLogic.HighLevelVaild;
                                        break;
                                }
                                continue;
                            }
                        } while (true);

                        #endregion 判断是否为综合设置字段
                    }

                    #endregion MyRegion


                    //若不是综合设置字段就开始生成Axis参数对象组
                    #region 轴组设置
                    if (tempstr1.Contains("AXES"))
                    {
                        match = idstr.Match(tempstr1);
                        if (match.Length > 0)
                        {
                            setvalue = Convert.ToInt32(match.Result("${ID}"));
                            axis = new SingleAxisParameter();
                            switch (setvalue)
                            {
                                case 0:
                                    axis.IDnum = AxisID.XAxis;
                                    break;

                                case 1:
                                    axis.IDnum = AxisID.YAxis;
                                    break;

                                case 2:
                                    axis.IDnum = AxisID.ZAxis;
                                    break;

                                case 3:
                                    axis.IDnum = AxisID.UAxis;
                                    break;

                                case 4:
                                    axis.IDnum = AxisID.AAxis;
                                    break;

                                case 5:
                                    axis.IDnum = AxisID.BAxis;
                                    break;
                            }
                            do
                            {
                                tempstr1 = m_SW.ReadLine();

                                if (tempstr1 == null)
                                {
                                    break;
                                }

                                CheckandSetSingleAxisPara(tempstr1, axis);

                                Debug.Print(tempstr1);
                            } while (!tempstr1.Contains("AXES"));

                            if (axis != null)
                            {
                                axis.SetAxiseElMode();
                                ListAxisParametersSets.Add(axis);
                            }
                        }
                    }
                } while (!m_SW.EndOfStream);
            }
            catch (IOException ex)
            {
                MessageBox.Show("This is a IO Exception :" + ex.Message);
            }
                    #endregion

                  
        }

        public void CheckandSetSingleAxisPara(string tempstr1, SingleAxisParameter axis)
        {
            #region 各种识别正则表达式

            var rgpulsemode = new Regex(@"PULSEOUTMODE=\s(?<pulsemode>\d{1})",
                RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rghomemode = new Regex(@"HOMEMODE=(?<homemode>\d{1})",
                 RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rghomelogic = new Regex(@"HOMELOGIC=(?<homelogic>\d{1})",
                  RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rghomespeedmode = new Regex(@"HOMESPEEDMODE=(?<homespeedmode>\d{1})",
                  RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rgezenable = new Regex(@"EZLOGIC=(?<ezenable>\d{1})",
                  RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rgezlogic = new Regex(@"EZLOGIC=(?<ezlogic>\d{1})",
                 RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rgltclogic = new Regex(@"LTCLOGIC=(?<ltclogic>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rgpluseinmode = new Regex(@"PULSEINMODE=(?<pluseinmode>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rginpenable = new Regex(@"INPENABLE=(?<inpenable>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rginplogic = new Regex(@"INPLOGIC=(?<inplogic>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rgalmlogic = new Regex(@"ALMLOGIC=(?<almlogic>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            var rgalmstopmode = new Regex(@"ALMSTOPMODE=(?<almstopmode>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            var rgelmode = new Regex(@"HPLSTOP=(?<elmode>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            var rgellogic = new Regex(@"HPLLOGIC=(?<ellogic>\d{1})",
               RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            #endregion 各种识别正则表达式

            Match match;
            int setvalue = -1;
            match = rgpulsemode.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${pulsemode}"));
                switch (setvalue)
                {
                    case 0:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PLDL;
                        break;

                    case 1:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PHDL;
                        break;

                    case 2:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PLDH;
                        break;

                    case 3:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PHDH;
                        break;

                    case 4:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PHDHPHDH;
                        break;

                    case 5:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PLDLPLDL;
                        break;

                    default:
                        axis.PULSEOUTMODE = AxisPulseOutMode.PM_PLDL;
                        break;
                }
                return;
            }

            match = rghomemode.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${homemode}"));
                switch (setvalue)
                {
                    case 0:
                        axis.HOMEMODE = AxisHomeMode.HomeCountOnly;
                        break;

                    case 1:
                        axis.HOMEMODE = AxisHomeMode.HomeAndEZCount;
                        break;

                    default:
                        axis.HOMEMODE = AxisHomeMode.HomeCountOnly;
                        break;
                }
                return;
            }

            match = rghomelogic.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${homelogic}"));
                switch (setvalue)
                {
                    case 0:
                        axis.HOMELOGIC = AxisHOMEOrgLogic.LowLevelVaild;
                        break;

                    case 1:
                        axis.HOMELOGIC = AxisHOMEOrgLogic.HighLevelVaild;
                        break;

                    default:
                        axis.HOMELOGIC = AxisHOMEOrgLogic.LowLevelVaild;
                        break;
                }
                return;
            }

            match = rghomespeedmode.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${homespeedmode}"));
                switch (setvalue)
                {
                    case 0:
                        axis.HOMESPEEDMODE = AxisHomeVelocityMode.SlowlySpeedandStop;
                        break;

                    case 1:
                        axis.HOMESPEEDMODE = AxisHomeVelocityMode.HighSpeedAndDecelerStop;
                        break;

                    default:
                        axis.HOMESPEEDMODE = AxisHomeVelocityMode.SlowlySpeedandStop;
                        break;
                }
                return;
            }

            match = rgltclogic.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${ltclogic}"));
                switch (setvalue)
                {
                    case 0:
                        axis.LTCLOGIC=LTCLogic.VaildLOW;
                        break;

                    case 1:
                         axis.LTCLOGIC=LTCLogic.VaildHIGH;
                        break;

                    default:
                         axis.LTCLOGIC=LTCLogic.VaildLOW;
                        break;
                }
                return;
            }

            match = rgpluseinmode.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${pluseinmode}"));
                switch (setvalue)
                {
                    case 0:
                        axis.PULSEINMODE=FeedBackPulseINMode.PulseMinusDir;
                        break;

                    case 1:
                       axis.PULSEINMODE=FeedBackPulseINMode.ABPluse;
                        break;

                    case 2:
                       axis.PULSEINMODE=FeedBackPulseINMode.ABDouble;
                        break;

                    case 3:
                       axis.PULSEINMODE=FeedBackPulseINMode.ABQuardruple;
                        break;

                    default:
                          axis.PULSEINMODE=FeedBackPulseINMode.PulseMinusDir;
                        break;
                }
                return;
            }
             match = rginpenable.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${inpenable}"));
                switch (setvalue)
                {
                    case 0:
                        axis.INPENABLE=AxisINPSIG.Disable;
                        break;

                    case 1:
                            axis.INPENABLE=AxisINPSIG.Enable;
                        break;

                    default:
                            axis.INPENABLE=AxisINPSIG.Disable;
                        break;
                }
                return;
            }

             match = rginplogic.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${inplogic}"));
                switch (setvalue)
                {
                    case 0:
                        axis.INPLOGIC=AxisINPLogic.LowLevelVaild;
                        break;

                    case 1:
                           axis.INPLOGIC=AxisINPLogic.HighLevelVaild;
                        break;

                    default:
                            axis.INPLOGIC=AxisINPLogic.LowLevelVaild;
                        break;
                }
                return;
            }

              match = rgalmlogic.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${almlogic}"));
                switch (setvalue)
                {
                    case 0:
                        axis.ALMLOGIC=AxisALMLogic.LowLevelVaild;
                        break;

                    case 1:
                           axis.ALMLOGIC=AxisALMLogic.HighLevelVaild;
                        break;

                    default:
                             axis.ALMLOGIC=AxisALMLogic.LowLevelVaild;
                        break;
                }
                return;
            }

             match = rgelmode.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${elmode}"));
                switch (setvalue)
                {
                    case 0:
                        axis.Elmode=false;
                        break;

                    case 1:
                        axis.Elmode=true;
                        break;

                    default:
                              axis.Elmode=false;
                        break;
                }
                return;
            }

            match = rgellogic.Match(tempstr1);
            if (match.Length > 0)
            {
                setvalue = Convert.ToInt32(match.Result("${ellogic}"));
                switch (setvalue)
                {
                    case 0:
                        axis.Ellogic=false;
                        break;

                    case 1:
                        axis.Ellogic=true;
                        break;

                    default :
                      axis.Ellogic=false;
                        break;
                }
                return;
            }
         
        }


    }
}