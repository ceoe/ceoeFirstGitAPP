namespace 雷泰DMC2610运动控制卡CSharp2010程序
{
    partial class DMC2610操作画面
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer位置显示 = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.单轴位置启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单轴启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单轴连续启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直线插补ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.圆弧插补ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer1驱动器接口检测 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.text改变目标位置 = new System.Windows.Forms.TextBox();
            this.CheckPCS变终 = new System.Windows.Forms.CheckBox();
            this.CheckU轴 = new System.Windows.Forms.CheckBox();
            this.Check电机方向选择 = new System.Windows.Forms.CheckBox();
            this.CheckB轴 = new System.Windows.Forms.CheckBox();
            this.CheckZ轴 = new System.Windows.Forms.CheckBox();
            this.CheckA轴 = new System.Windows.Forms.CheckBox();
            this.CheckY轴 = new System.Windows.Forms.CheckBox();
            this.CheckX轴 = new System.Windows.Forms.CheckBox();
            this.CheckSD减速 = new System.Windows.Forms.CheckBox();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.LaB缓冲 = new System.Windows.Forms.Label();
            this.LaA缓冲 = new System.Windows.Forms.Label();
            this.LaX缓冲 = new System.Windows.Forms.Label();
            this.LaZ缓冲 = new System.Windows.Forms.Label();
            this.LaY缓冲 = new System.Windows.Forms.Label();
            this.LaU缓冲 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.La速度方式 = new System.Windows.Forms.Label();
            this.Radio多轴插补速度 = new System.Windows.Forms.RadioButton();
            this.Radio设置S形速度 = new System.Windows.Forms.RadioButton();
            this.Radio设置T形速度 = new System.Windows.Forms.RadioButton();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Radio单轴立即停止 = new System.Windows.Forms.RadioButton();
            this.Radio单轴减速停止 = new System.Windows.Forms.RadioButton();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.La3输出 = new System.Windows.Forms.Label();
            this.La2输出 = new System.Windows.Forms.Label();
            this.La1输出 = new System.Windows.Forms.Label();
            this.La输入3 = new System.Windows.Forms.Label();
            this.La输入2 = new System.Windows.Forms.Label();
            this.La输入1 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.la变速度 = new System.Windows.Forms.Label();
            this.But插补启动 = new System.Windows.Forms.Button();
            this.Check单轴变速 = new System.Windows.Forms.CheckBox();
            this.Check比较 = new System.Windows.Forms.CheckBox();
            this.HScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.Text8B轴速度 = new System.Windows.Forms.TextBox();
            this.Text6U轴速度 = new System.Windows.Forms.TextBox();
            this.Text7A轴速度 = new System.Windows.Forms.TextBox();
            this.Text5Z轴速度 = new System.Windows.Forms.TextBox();
            this.Text4Y轴速度 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Text3X轴速度 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.But原点 = new System.Windows.Forms.Button();
            this.Text5B轴当前位置 = new System.Windows.Forms.TextBox();
            this.But退出 = new System.Windows.Forms.Button();
            this.Text4A轴当前位置 = new System.Windows.Forms.TextBox();
            this.Text3U轴当前位置 = new System.Windows.Forms.TextBox();
            this.Text2Z轴当前位置 = new System.Windows.Forms.TextBox();
            this.Text1Y轴当前位置 = new System.Windows.Forms.TextBox();
            this.But清零 = new System.Windows.Forms.Button();
            this.Text0X轴当前位置 = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Text比较数据 = new System.Windows.Forms.TextBox();
            this.Text轴数 = new System.Windows.Forms.TextBox();
            this.La比较数值 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.TextA轴位置 = new System.Windows.Forms.TextBox();
            this.TextZ轴位置 = new System.Windows.Forms.TextBox();
            this.TextY轴位置 = new System.Windows.Forms.TextBox();
            this.TextX轴位置 = new System.Windows.Forms.TextBox();
            this.Text加速脉冲 = new System.Windows.Forms.TextBox();
            this.TextB轴位置 = new System.Windows.Forms.TextBox();
            this.Text加速时间 = new System.Windows.Forms.TextBox();
            this.TextU轴位置 = new System.Windows.Forms.TextBox();
            this.Text减速脉冲 = new System.Windows.Forms.TextBox();
            this.Text减速时间 = new System.Windows.Forms.TextBox();
            this.Text起始速度 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Text运行速度 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.La加速脉冲 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.radio六轴直线插补 = new System.Windows.Forms.RadioButton();
            this.Radio四轴直线插补 = new System.Windows.Forms.RadioButton();
            this.Radio三轴直线插补 = new System.Windows.Forms.RadioButton();
            this.Radio圆弧插补 = new System.Windows.Forms.RadioButton();
            this.Radio两轴直线插补 = new System.Windows.Forms.RadioButton();
            this.La运行方式 = new System.Windows.Forms.Label();
            this.Radio单轴S形位置运动非 = new System.Windows.Forms.RadioButton();
            this.Radio单轴S形位置运动对 = new System.Windows.Forms.RadioButton();
            this.Radio单轴T形位置运动非 = new System.Windows.Forms.RadioButton();
            this.Radio单轴T形位置运动对 = new System.Windows.Forms.RadioButton();
            this.Radio单轴S形连续运动 = new System.Windows.Forms.RadioButton();
            this.Radio单轴T形连续运动 = new System.Windows.Forms.RadioButton();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.But单轴启动 = new System.Windows.Forms.Button();
            this.But同步停止 = new System.Windows.Forms.Button();
            this.But紧急停止 = new System.Windows.Forms.Button();
            this.But单轴停止 = new System.Windows.Forms.Button();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.La0启动命令 = new System.Windows.Forms.Label();
            this.La16X轴DIR信号 = new System.Windows.Forms.Label();
            this.La15X轴INP信号 = new System.Windows.Forms.Label();
            this.La9X轴ERC信号 = new System.Windows.Forms.Label();
            this.La8X轴PCS信号 = new System.Windows.Forms.Label();
            this.La7X轴急停 = new System.Windows.Forms.Label();
            this.La1X轴脉冲输出 = new System.Windows.Forms.Label();
            this.La15X轴SD = new System.Windows.Forms.Label();
            this.La14X轴ORG = new System.Windows.Forms.Label();
            this.La13X轴MEL = new System.Windows.Forms.Label();
            this.La12X轴PEL = new System.Windows.Forms.Label();
            this.La11X轴ALM = new System.Windows.Forms.Label();
            this.La10X轴FC = new System.Windows.Forms.Label();
            this.La9X轴FD = new System.Windows.Forms.Label();
            this.La8X轴FU = new System.Windows.Forms.Label();
            this.LaY位置比较 = new System.Windows.Forms.Label();
            this.LaX位置比较 = new System.Windows.Forms.Label();
            this.LaY准备RDY = new System.Windows.Forms.Label();
            this.LaX准备RDY = new System.Windows.Forms.Label();
            this.LaY使能 = new System.Windows.Forms.Label();
            this.LaX使能 = new System.Windows.Forms.Label();
            this.Lab运检测 = new System.Windows.Forms.Label();
            this.radio相对模式 = new System.Windows.Forms.RadioButton();
            this.radio绝对模式 = new System.Windows.Forms.RadioButton();
            this.MenuStrip1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer位置显示
            // 
            this.Timer位置显示.Enabled = true;
            this.Timer位置显示.Tick += new System.EventHandler(this.Timer位置显示_Tick);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单轴位置启动ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuStrip1.Size = new System.Drawing.Size(686, 24);
            this.MenuStrip1.TabIndex = 11;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // 单轴位置启动ToolStripMenuItem
            // 
            this.单轴位置启动ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单轴启动ToolStripMenuItem,
            this.单轴连续启动ToolStripMenuItem,
            this.直线插补ToolStripMenuItem,
            this.圆弧插补ToolStripMenuItem});
            this.单轴位置启动ToolStripMenuItem.Name = "单轴位置启动ToolStripMenuItem";
            this.单轴位置启动ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.单轴位置启动ToolStripMenuItem.Text = "启动模式";
            // 
            // 单轴启动ToolStripMenuItem
            // 
            this.单轴启动ToolStripMenuItem.Name = "单轴启动ToolStripMenuItem";
            this.单轴启动ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.单轴启动ToolStripMenuItem.Text = "单轴启动";
            this.单轴启动ToolStripMenuItem.Click += new System.EventHandler(this.单轴启动ToolStripMenuItem_Click);
            // 
            // 单轴连续启动ToolStripMenuItem
            // 
            this.单轴连续启动ToolStripMenuItem.Name = "单轴连续启动ToolStripMenuItem";
            this.单轴连续启动ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.单轴连续启动ToolStripMenuItem.Text = "多轴连续启动";
            this.单轴连续启动ToolStripMenuItem.Click += new System.EventHandler(this.单轴连续启动ToolStripMenuItem_Click);
            // 
            // 直线插补ToolStripMenuItem
            // 
            this.直线插补ToolStripMenuItem.Name = "直线插补ToolStripMenuItem";
            this.直线插补ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.直线插补ToolStripMenuItem.Text = "直线插补启动";
            this.直线插补ToolStripMenuItem.Click += new System.EventHandler(this.直线插补ToolStripMenuItem_Click);
            // 
            // 圆弧插补ToolStripMenuItem
            // 
            this.圆弧插补ToolStripMenuItem.Name = "圆弧插补ToolStripMenuItem";
            this.圆弧插补ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.圆弧插补ToolStripMenuItem.Text = "圆弧插补启动";
            this.圆弧插补ToolStripMenuItem.Click += new System.EventHandler(this.圆弧插补ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Timer1驱动器接口检测
            // 
            this.Timer1驱动器接口检测.Enabled = true;
            this.Timer1驱动器接口检测.Tick += new System.EventHandler(this.Timer1驱动器专用接口_Tick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label18);
            this.GroupBox2.Controls.Add(this.text改变目标位置);
            this.GroupBox2.Controls.Add(this.CheckPCS变终);
            this.GroupBox2.Controls.Add(this.CheckU轴);
            this.GroupBox2.Controls.Add(this.Check电机方向选择);
            this.GroupBox2.Controls.Add(this.CheckB轴);
            this.GroupBox2.Controls.Add(this.CheckZ轴);
            this.GroupBox2.Controls.Add(this.CheckA轴);
            this.GroupBox2.Controls.Add(this.CheckY轴);
            this.GroupBox2.Controls.Add(this.CheckX轴);
            this.GroupBox2.Location = new System.Drawing.Point(8, 37);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(143, 101);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "驱动轴选择";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(86, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 23;
            this.label18.Text = "目标位置";
            // 
            // text改变目标位置
            // 
            this.text改变目标位置.Location = new System.Drawing.Point(80, 78);
            this.text改变目标位置.Name = "text改变目标位置";
            this.text改变目标位置.Size = new System.Drawing.Size(60, 21);
            this.text改变目标位置.TabIndex = 23;
            this.text改变目标位置.Text = "100";
            // 
            // CheckPCS变终
            // 
            this.CheckPCS变终.AutoSize = true;
            this.CheckPCS变终.Location = new System.Drawing.Point(5, 80);
            this.CheckPCS变终.Name = "CheckPCS变终";
            this.CheckPCS变终.Size = new System.Drawing.Size(78, 16);
            this.CheckPCS变终.TabIndex = 16;
            this.CheckPCS变终.Text = "PCS变终关";
            this.CheckPCS变终.UseVisualStyleBackColor = true;
            // 
            // CheckU轴
            // 
            this.CheckU轴.AutoSize = true;
            this.CheckU轴.Location = new System.Drawing.Point(5, 41);
            this.CheckU轴.Name = "CheckU轴";
            this.CheckU轴.Size = new System.Drawing.Size(42, 16);
            this.CheckU轴.TabIndex = 13;
            this.CheckU轴.Text = "U轴";
            this.CheckU轴.UseVisualStyleBackColor = true;
            // 
            // Check电机方向选择
            // 
            this.Check电机方向选择.AutoSize = true;
            this.Check电机方向选择.Location = new System.Drawing.Point(4, 59);
            this.Check电机方向选择.Name = "Check电机方向选择";
            this.Check电机方向选择.Size = new System.Drawing.Size(90, 16);
            this.Check电机方向选择.TabIndex = 4;
            this.Check电机方向选择.Text = "脉冲+正方向";
            this.Check电机方向选择.UseVisualStyleBackColor = true;
            this.Check电机方向选择.CheckedChanged += new System.EventHandler(this.Check电机方向选择_CheckedChanged);
            // 
            // CheckB轴
            // 
            this.CheckB轴.AutoSize = true;
            this.CheckB轴.Location = new System.Drawing.Point(90, 40);
            this.CheckB轴.Name = "CheckB轴";
            this.CheckB轴.Size = new System.Drawing.Size(42, 16);
            this.CheckB轴.TabIndex = 2;
            this.CheckB轴.Text = "B轴";
            this.CheckB轴.UseVisualStyleBackColor = true;
            // 
            // CheckZ轴
            // 
            this.CheckZ轴.AutoSize = true;
            this.CheckZ轴.Location = new System.Drawing.Point(91, 20);
            this.CheckZ轴.Name = "CheckZ轴";
            this.CheckZ轴.Size = new System.Drawing.Size(42, 16);
            this.CheckZ轴.TabIndex = 2;
            this.CheckZ轴.Text = "Z轴";
            this.CheckZ轴.UseVisualStyleBackColor = true;
            // 
            // CheckA轴
            // 
            this.CheckA轴.AutoSize = true;
            this.CheckA轴.Location = new System.Drawing.Point(47, 40);
            this.CheckA轴.Name = "CheckA轴";
            this.CheckA轴.Size = new System.Drawing.Size(42, 16);
            this.CheckA轴.TabIndex = 1;
            this.CheckA轴.Text = "A轴";
            this.CheckA轴.UseVisualStyleBackColor = true;
            // 
            // CheckY轴
            // 
            this.CheckY轴.AutoSize = true;
            this.CheckY轴.Location = new System.Drawing.Point(47, 20);
            this.CheckY轴.Name = "CheckY轴";
            this.CheckY轴.Size = new System.Drawing.Size(42, 16);
            this.CheckY轴.TabIndex = 1;
            this.CheckY轴.Text = "Y轴";
            this.CheckY轴.UseVisualStyleBackColor = true;
            // 
            // CheckX轴
            // 
            this.CheckX轴.AutoSize = true;
            this.CheckX轴.Location = new System.Drawing.Point(5, 20);
            this.CheckX轴.Name = "CheckX轴";
            this.CheckX轴.Size = new System.Drawing.Size(42, 16);
            this.CheckX轴.TabIndex = 0;
            this.CheckX轴.Text = "X轴";
            this.CheckX轴.UseVisualStyleBackColor = true;
            // 
            // CheckSD减速
            // 
            this.CheckSD减速.AutoSize = true;
            this.CheckSD减速.Location = new System.Drawing.Point(7, 63);
            this.CheckSD减速.Name = "CheckSD减速";
            this.CheckSD减速.Size = new System.Drawing.Size(72, 16);
            this.CheckSD减速.TabIndex = 16;
            this.CheckSD减速.Text = "SD减速关";
            this.CheckSD减速.UseVisualStyleBackColor = true;
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.LaB缓冲);
            this.GroupBox7.Controls.Add(this.LaA缓冲);
            this.GroupBox7.Controls.Add(this.LaX缓冲);
            this.GroupBox7.Controls.Add(this.LaZ缓冲);
            this.GroupBox7.Controls.Add(this.LaY缓冲);
            this.GroupBox7.Controls.Add(this.LaU缓冲);
            this.GroupBox7.Location = new System.Drawing.Point(279, 43);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(151, 84);
            this.GroupBox7.TabIndex = 14;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "各轴缓冲区";
            // 
            // LaB缓冲
            // 
            this.LaB缓冲.AutoSize = true;
            this.LaB缓冲.Location = new System.Drawing.Point(87, 58);
            this.LaB缓冲.Name = "LaB缓冲";
            this.LaB缓冲.Size = new System.Drawing.Size(59, 12);
            this.LaB缓冲.TabIndex = 5;
            this.LaB缓冲.Text = "B轴缓冲区";
            // 
            // LaA缓冲
            // 
            this.LaA缓冲.AutoSize = true;
            this.LaA缓冲.Location = new System.Drawing.Point(6, 57);
            this.LaA缓冲.Name = "LaA缓冲";
            this.LaA缓冲.Size = new System.Drawing.Size(59, 12);
            this.LaA缓冲.TabIndex = 4;
            this.LaA缓冲.Text = "A轴缓冲区";
            // 
            // LaX缓冲
            // 
            this.LaX缓冲.AutoSize = true;
            this.LaX缓冲.Location = new System.Drawing.Point(6, 17);
            this.LaX缓冲.Name = "LaX缓冲";
            this.LaX缓冲.Size = new System.Drawing.Size(59, 12);
            this.LaX缓冲.TabIndex = 3;
            this.LaX缓冲.Text = "X轴缓冲区";
            // 
            // LaZ缓冲
            // 
            this.LaZ缓冲.AutoSize = true;
            this.LaZ缓冲.Location = new System.Drawing.Point(6, 37);
            this.LaZ缓冲.Name = "LaZ缓冲";
            this.LaZ缓冲.Size = new System.Drawing.Size(59, 12);
            this.LaZ缓冲.TabIndex = 2;
            this.LaZ缓冲.Text = "Z轴缓冲区";
            // 
            // LaY缓冲
            // 
            this.LaY缓冲.AutoSize = true;
            this.LaY缓冲.Location = new System.Drawing.Point(85, 15);
            this.LaY缓冲.Name = "LaY缓冲";
            this.LaY缓冲.Size = new System.Drawing.Size(59, 12);
            this.LaY缓冲.TabIndex = 1;
            this.LaY缓冲.Text = "Y轴缓冲区";
            // 
            // LaU缓冲
            // 
            this.LaU缓冲.AutoSize = true;
            this.LaU缓冲.Location = new System.Drawing.Point(86, 36);
            this.LaU缓冲.Name = "LaU缓冲";
            this.LaU缓冲.Size = new System.Drawing.Size(59, 12);
            this.LaU缓冲.TabIndex = 0;
            this.LaU缓冲.Text = "U轴缓冲区";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.La速度方式);
            this.GroupBox1.Controls.Add(this.Radio多轴插补速度);
            this.GroupBox1.Controls.Add(this.Radio设置S形速度);
            this.GroupBox1.Controls.Add(this.Radio设置T形速度);
            this.GroupBox1.Location = new System.Drawing.Point(301, 354);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(113, 85);
            this.GroupBox1.TabIndex = 15;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "运动速度设置";
            // 
            // La速度方式
            // 
            this.La速度方式.AutoSize = true;
            this.La速度方式.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La速度方式.ForeColor = System.Drawing.Color.Blue;
            this.La速度方式.Location = new System.Drawing.Point(2, 69);
            this.La速度方式.Name = "La速度方式";
            this.La速度方式.Size = new System.Drawing.Size(63, 14);
            this.La速度方式.TabIndex = 1;
            this.La速度方式.Text = "速度方式";
            // 
            // Radio多轴插补速度
            // 
            this.Radio多轴插补速度.AutoSize = true;
            this.Radio多轴插补速度.Location = new System.Drawing.Point(6, 50);
            this.Radio多轴插补速度.Name = "Radio多轴插补速度";
            this.Radio多轴插补速度.Size = new System.Drawing.Size(95, 16);
            this.Radio多轴插补速度.TabIndex = 0;
            this.Radio多轴插补速度.Text = "多轴插补速度";
            this.Radio多轴插补速度.UseVisualStyleBackColor = true;
            // 
            // Radio设置S形速度
            // 
            this.Radio设置S形速度.AutoSize = true;
            this.Radio设置S形速度.Location = new System.Drawing.Point(6, 32);
            this.Radio设置S形速度.Name = "Radio设置S形速度";
            this.Radio设置S形速度.Size = new System.Drawing.Size(89, 16);
            this.Radio设置S形速度.TabIndex = 0;
            this.Radio设置S形速度.Text = "设置S形速度";
            this.Radio设置S形速度.UseVisualStyleBackColor = true;
            // 
            // Radio设置T形速度
            // 
            this.Radio设置T形速度.AutoSize = true;
            this.Radio设置T形速度.Checked = true;
            this.Radio设置T形速度.Location = new System.Drawing.Point(6, 14);
            this.Radio设置T形速度.Name = "Radio设置T形速度";
            this.Radio设置T形速度.Size = new System.Drawing.Size(89, 16);
            this.Radio设置T形速度.TabIndex = 0;
            this.Radio设置T形速度.TabStop = true;
            this.Radio设置T形速度.Text = "设置T形速度";
            this.Radio设置T形速度.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Radio单轴立即停止);
            this.GroupBox4.Controls.Add(this.Radio单轴减速停止);
            this.GroupBox4.Controls.Add(this.CheckSD减速);
            this.GroupBox4.Location = new System.Drawing.Point(163, 43);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(110, 85);
            this.GroupBox4.TabIndex = 16;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "停止选择方式";
            // 
            // Radio单轴立即停止
            // 
            this.Radio单轴立即停止.AutoSize = true;
            this.Radio单轴立即停止.Location = new System.Drawing.Point(6, 41);
            this.Radio单轴立即停止.Name = "Radio单轴立即停止";
            this.Radio单轴立即停止.Size = new System.Drawing.Size(95, 16);
            this.Radio单轴立即停止.TabIndex = 0;
            this.Radio单轴立即停止.Text = "单轴立即停止";
            this.Radio单轴立即停止.UseVisualStyleBackColor = true;
            // 
            // Radio单轴减速停止
            // 
            this.Radio单轴减速停止.AutoSize = true;
            this.Radio单轴减速停止.Checked = true;
            this.Radio单轴减速停止.Location = new System.Drawing.Point(6, 20);
            this.Radio单轴减速停止.Name = "Radio单轴减速停止";
            this.Radio单轴减速停止.Size = new System.Drawing.Size(95, 16);
            this.Radio单轴减速停止.TabIndex = 0;
            this.Radio单轴减速停止.TabStop = true;
            this.Radio单轴减速停止.Text = "单轴减速停止";
            this.Radio单轴减速停止.UseVisualStyleBackColor = true;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.La3输出);
            this.GroupBox8.Controls.Add(this.La2输出);
            this.GroupBox8.Controls.Add(this.La1输出);
            this.GroupBox8.Controls.Add(this.La输入3);
            this.GroupBox8.Controls.Add(this.La输入2);
            this.GroupBox8.Controls.Add(this.La输入1);
            this.GroupBox8.Location = new System.Drawing.Point(443, 34);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(116, 125);
            this.GroupBox8.TabIndex = 17;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "输入输出信号";
            // 
            // La3输出
            // 
            this.La3输出.AutoSize = true;
            this.La3输出.Location = new System.Drawing.Point(6, 107);
            this.La3输出.Name = "La3输出";
            this.La3输出.Size = new System.Drawing.Size(83, 12);
            this.La3输出.TabIndex = 1;
            this.La3输出.Text = "输出3：无信号";
            // 
            // La2输出
            // 
            this.La2输出.AutoSize = true;
            this.La2输出.Location = new System.Drawing.Point(6, 90);
            this.La2输出.Name = "La2输出";
            this.La2输出.Size = new System.Drawing.Size(83, 12);
            this.La2输出.TabIndex = 1;
            this.La2输出.Text = "输出2：无信号";
            // 
            // La1输出
            // 
            this.La1输出.AutoSize = true;
            this.La1输出.Location = new System.Drawing.Point(6, 72);
            this.La1输出.Name = "La1输出";
            this.La1输出.Size = new System.Drawing.Size(83, 12);
            this.La1输出.TabIndex = 1;
            this.La1输出.Text = "输出1：无信号";
            // 
            // La输入3
            // 
            this.La输入3.AutoSize = true;
            this.La输入3.Location = new System.Drawing.Point(6, 55);
            this.La输入3.Name = "La输入3";
            this.La输入3.Size = new System.Drawing.Size(83, 12);
            this.La输入3.TabIndex = 0;
            this.La输入3.Text = "输入3：无信号";
            // 
            // La输入2
            // 
            this.La输入2.AutoSize = true;
            this.La输入2.Location = new System.Drawing.Point(6, 38);
            this.La输入2.Name = "La输入2";
            this.La输入2.Size = new System.Drawing.Size(83, 12);
            this.La输入2.TabIndex = 0;
            this.La输入2.Text = "输入2：无信号";
            // 
            // La输入1
            // 
            this.La输入1.AutoSize = true;
            this.La输入1.Location = new System.Drawing.Point(6, 21);
            this.La输入1.Name = "La输入1";
            this.La输入1.Size = new System.Drawing.Size(83, 12);
            this.La输入1.TabIndex = 0;
            this.La输入1.Text = "输入1：无信号";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.radio绝对模式);
            this.GroupBox3.Controls.Add(this.radio相对模式);
            this.GroupBox3.Controls.Add(this.la变速度);
            this.GroupBox3.Controls.Add(this.But插补启动);
            this.GroupBox3.Controls.Add(this.Check单轴变速);
            this.GroupBox3.Controls.Add(this.Check比较);
            this.GroupBox3.Controls.Add(this.HScrollBar1);
            this.GroupBox3.Controls.Add(this.Text8B轴速度);
            this.GroupBox3.Controls.Add(this.Text6U轴速度);
            this.GroupBox3.Controls.Add(this.Text7A轴速度);
            this.GroupBox3.Controls.Add(this.Text5Z轴速度);
            this.GroupBox3.Controls.Add(this.Text4Y轴速度);
            this.GroupBox3.Controls.Add(this.label20);
            this.GroupBox3.Controls.Add(this.Text3X轴速度);
            this.GroupBox3.Controls.Add(this.label19);
            this.GroupBox3.Controls.Add(this.Label16);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.Label11);
            this.GroupBox3.Controls.Add(this.But原点);
            this.GroupBox3.Controls.Add(this.Text5B轴当前位置);
            this.GroupBox3.Controls.Add(this.But退出);
            this.GroupBox3.Controls.Add(this.Text4A轴当前位置);
            this.GroupBox3.Controls.Add(this.Text3U轴当前位置);
            this.GroupBox3.Controls.Add(this.Text2Z轴当前位置);
            this.GroupBox3.Controls.Add(this.Text1Y轴当前位置);
            this.GroupBox3.Controls.Add(this.But清零);
            this.GroupBox3.Controls.Add(this.Text0X轴当前位置);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.Text比较数据);
            this.GroupBox3.Controls.Add(this.Text轴数);
            this.GroupBox3.Controls.Add(this.La比较数值);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.TextA轴位置);
            this.GroupBox3.Controls.Add(this.TextZ轴位置);
            this.GroupBox3.Controls.Add(this.TextY轴位置);
            this.GroupBox3.Controls.Add(this.TextX轴位置);
            this.GroupBox3.Controls.Add(this.Text加速脉冲);
            this.GroupBox3.Controls.Add(this.TextB轴位置);
            this.GroupBox3.Controls.Add(this.Text加速时间);
            this.GroupBox3.Controls.Add(this.TextU轴位置);
            this.GroupBox3.Controls.Add(this.Text减速脉冲);
            this.GroupBox3.Controls.Add(this.Text减速时间);
            this.GroupBox3.Controls.Add(this.Text起始速度);
            this.GroupBox3.Controls.Add(this.label22);
            this.GroupBox3.Controls.Add(this.Text运行速度);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.label21);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.Label15);
            this.GroupBox3.Controls.Add(this.Label17);
            this.GroupBox3.Controls.Add(this.La加速脉冲);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Location = new System.Drawing.Point(10, 144);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(285, 411);
            this.GroupBox3.TabIndex = 18;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "参数设置";
            // 
            // la变速度
            // 
            this.la变速度.AutoSize = true;
            this.la变速度.Location = new System.Drawing.Point(221, 384);
            this.la变速度.Name = "la变速度";
            this.la变速度.Size = new System.Drawing.Size(35, 12);
            this.la变速度.TabIndex = 23;
            this.la变速度.Text = "速度0";
            // 
            // But插补启动
            // 
            this.But插补启动.Location = new System.Drawing.Point(191, 216);
            this.But插补启动.Name = "But插补启动";
            this.But插补启动.Size = new System.Drawing.Size(62, 26);
            this.But插补启动.TabIndex = 13;
            this.But插补启动.Text = "插补启动";
            this.But插补启动.UseVisualStyleBackColor = true;
            this.But插补启动.Click += new System.EventHandler(this.But插补启动_Click);
            // 
            // Check单轴变速
            // 
            this.Check单轴变速.AutoSize = true;
            this.Check单轴变速.Location = new System.Drawing.Point(8, 383);
            this.Check单轴变速.Name = "Check单轴变速";
            this.Check单轴变速.Size = new System.Drawing.Size(72, 16);
            this.Check单轴变速.TabIndex = 13;
            this.Check单轴变速.Text = "单轴变速";
            this.Check单轴变速.UseVisualStyleBackColor = true;
            // 
            // Check比较
            // 
            this.Check比较.AutoSize = true;
            this.Check比较.Location = new System.Drawing.Point(6, 178);
            this.Check比较.Name = "Check比较";
            this.Check比较.Size = new System.Drawing.Size(60, 16);
            this.Check比较.TabIndex = 0;
            this.Check比较.Text = "比较关";
            this.Check比较.UseVisualStyleBackColor = true;
            // 
            // HScrollBar1
            // 
            this.HScrollBar1.AllowDrop = true;
            this.HScrollBar1.Location = new System.Drawing.Point(83, 378);
            this.HScrollBar1.Maximum = 38897;
            this.HScrollBar1.Minimum = 12;
            this.HScrollBar1.Name = "HScrollBar1";
            this.HScrollBar1.Size = new System.Drawing.Size(135, 21);
            this.HScrollBar1.TabIndex = 13;
            this.HScrollBar1.Value = 30000;
            // 
            // Text8B轴速度
            // 
            this.Text8B轴速度.Location = new System.Drawing.Point(109, 353);
            this.Text8B轴速度.Name = "Text8B轴速度";
            this.Text8B轴速度.Size = new System.Drawing.Size(71, 21);
            this.Text8B轴速度.TabIndex = 28;
            // 
            // Text6U轴速度
            // 
            this.Text6U轴速度.Location = new System.Drawing.Point(109, 300);
            this.Text6U轴速度.Name = "Text6U轴速度";
            this.Text6U轴速度.Size = new System.Drawing.Size(71, 21);
            this.Text6U轴速度.TabIndex = 28;
            // 
            // Text7A轴速度
            // 
            this.Text7A轴速度.Location = new System.Drawing.Point(109, 326);
            this.Text7A轴速度.Name = "Text7A轴速度";
            this.Text7A轴速度.Size = new System.Drawing.Size(71, 21);
            this.Text7A轴速度.TabIndex = 28;
            // 
            // Text5Z轴速度
            // 
            this.Text5Z轴速度.Location = new System.Drawing.Point(109, 273);
            this.Text5Z轴速度.Name = "Text5Z轴速度";
            this.Text5Z轴速度.Size = new System.Drawing.Size(71, 21);
            this.Text5Z轴速度.TabIndex = 28;
            // 
            // Text4Y轴速度
            // 
            this.Text4Y轴速度.Location = new System.Drawing.Point(109, 246);
            this.Text4Y轴速度.Name = "Text4Y轴速度";
            this.Text4Y轴速度.Size = new System.Drawing.Size(71, 21);
            this.Text4Y轴速度.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 358);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 12);
            this.label20.TabIndex = 25;
            this.label20.Text = "B轴";
            // 
            // Text3X轴速度
            // 
            this.Text3X轴速度.Location = new System.Drawing.Point(109, 219);
            this.Text3X轴速度.Name = "Text3X轴速度";
            this.Text3X轴速度.Size = new System.Drawing.Size(71, 21);
            this.Text3X轴速度.TabIndex = 26;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 331);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 12);
            this.label19.TabIndex = 25;
            this.label19.Text = "A轴";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(8, 305);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(23, 12);
            this.Label16.TabIndex = 25;
            this.Label16.Text = "U轴";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(8, 278);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(23, 12);
            this.Label14.TabIndex = 25;
            this.Label14.Text = "Z轴";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(8, 251);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(23, 12);
            this.Label13.TabIndex = 24;
            this.Label13.Text = "Y轴";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(8, 224);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(23, 12);
            this.Label12.TabIndex = 23;
            this.Label12.Text = "X轴";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(119, 204);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(53, 12);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "当前速度";
            // 
            // But原点
            // 
            this.But原点.Location = new System.Drawing.Point(191, 277);
            this.But原点.Name = "But原点";
            this.But原点.Size = new System.Drawing.Size(62, 27);
            this.But原点.TabIndex = 6;
            this.But原点.Text = "原点归零";
            this.But原点.UseVisualStyleBackColor = true;
            this.But原点.Click += new System.EventHandler(this.But原点_Click);
            // 
            // Text5B轴当前位置
            // 
            this.Text5B轴当前位置.Location = new System.Drawing.Point(31, 353);
            this.Text5B轴当前位置.Name = "Text5B轴当前位置";
            this.Text5B轴当前位置.Size = new System.Drawing.Size(71, 21);
            this.Text5B轴当前位置.TabIndex = 21;
            // 
            // But退出
            // 
            this.But退出.Location = new System.Drawing.Point(191, 308);
            this.But退出.Name = "But退出";
            this.But退出.Size = new System.Drawing.Size(62, 25);
            this.But退出.TabIndex = 22;
            this.But退出.Text = "退出";
            this.But退出.UseVisualStyleBackColor = true;
            this.But退出.Click += new System.EventHandler(this.But退出_Click);
            // 
            // Text4A轴当前位置
            // 
            this.Text4A轴当前位置.Location = new System.Drawing.Point(31, 326);
            this.Text4A轴当前位置.Name = "Text4A轴当前位置";
            this.Text4A轴当前位置.Size = new System.Drawing.Size(71, 21);
            this.Text4A轴当前位置.TabIndex = 21;
            // 
            // Text3U轴当前位置
            // 
            this.Text3U轴当前位置.Location = new System.Drawing.Point(31, 300);
            this.Text3U轴当前位置.Name = "Text3U轴当前位置";
            this.Text3U轴当前位置.Size = new System.Drawing.Size(71, 21);
            this.Text3U轴当前位置.TabIndex = 21;
            // 
            // Text2Z轴当前位置
            // 
            this.Text2Z轴当前位置.Location = new System.Drawing.Point(31, 273);
            this.Text2Z轴当前位置.Name = "Text2Z轴当前位置";
            this.Text2Z轴当前位置.Size = new System.Drawing.Size(71, 21);
            this.Text2Z轴当前位置.TabIndex = 21;
            // 
            // Text1Y轴当前位置
            // 
            this.Text1Y轴当前位置.Location = new System.Drawing.Point(31, 246);
            this.Text1Y轴当前位置.Name = "Text1Y轴当前位置";
            this.Text1Y轴当前位置.Size = new System.Drawing.Size(71, 21);
            this.Text1Y轴当前位置.TabIndex = 20;
            // 
            // But清零
            // 
            this.But清零.Location = new System.Drawing.Point(191, 247);
            this.But清零.Name = "But清零";
            this.But清零.Size = new System.Drawing.Size(62, 26);
            this.But清零.TabIndex = 19;
            this.But清零.Text = "位置清零";
            this.But清零.UseVisualStyleBackColor = true;
            this.But清零.Click += new System.EventHandler(this.But清零_Click);
            // 
            // Text0X轴当前位置
            // 
            this.Text0X轴当前位置.Location = new System.Drawing.Point(31, 219);
            this.Text0X轴当前位置.Name = "Text0X轴当前位置";
            this.Text0X轴当前位置.Size = new System.Drawing.Size(71, 21);
            this.Text0X轴当前位置.TabIndex = 18;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(42, 203);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(53, 12);
            this.Label10.TabIndex = 17;
            this.Label10.Text = "当前位置";
            // 
            // Text比较数据
            // 
            this.Text比较数据.Location = new System.Drawing.Point(120, 173);
            this.Text比较数据.Name = "Text比较数据";
            this.Text比较数据.Size = new System.Drawing.Size(53, 21);
            this.Text比较数据.TabIndex = 16;
            this.Text比较数据.Text = "1000";
            // 
            // Text轴数
            // 
            this.Text轴数.Location = new System.Drawing.Point(235, 175);
            this.Text轴数.Name = "Text轴数";
            this.Text轴数.Size = new System.Drawing.Size(26, 21);
            this.Text轴数.TabIndex = 16;
            this.Text轴数.Text = "0";
            // 
            // La比较数值
            // 
            this.La比较数值.AutoSize = true;
            this.La比较数值.Location = new System.Drawing.Point(64, 179);
            this.La比较数值.Name = "La比较数值";
            this.La比较数值.Size = new System.Drawing.Size(53, 12);
            this.La比较数值.TabIndex = 15;
            this.La比较数值.Text = "比较位置";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(180, 180);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(53, 12);
            this.Label9.TabIndex = 15;
            this.Label9.Text = "插补轴数";
            // 
            // TextA轴位置
            // 
            this.TextA轴位置.Location = new System.Drawing.Point(178, 118);
            this.TextA轴位置.Name = "TextA轴位置";
            this.TextA轴位置.Size = new System.Drawing.Size(71, 21);
            this.TextA轴位置.TabIndex = 14;
            this.TextA轴位置.Text = "2500";
            // 
            // TextZ轴位置
            // 
            this.TextZ轴位置.Location = new System.Drawing.Point(178, 67);
            this.TextZ轴位置.Name = "TextZ轴位置";
            this.TextZ轴位置.Size = new System.Drawing.Size(71, 21);
            this.TextZ轴位置.TabIndex = 14;
            this.TextZ轴位置.Text = "2000";
            // 
            // TextY轴位置
            // 
            this.TextY轴位置.Location = new System.Drawing.Point(178, 41);
            this.TextY轴位置.Name = "TextY轴位置";
            this.TextY轴位置.Size = new System.Drawing.Size(71, 21);
            this.TextY轴位置.TabIndex = 13;
            this.TextY轴位置.Text = "4000";
            // 
            // TextX轴位置
            // 
            this.TextX轴位置.Location = new System.Drawing.Point(178, 14);
            this.TextX轴位置.Name = "TextX轴位置";
            this.TextX轴位置.Size = new System.Drawing.Size(71, 21);
            this.TextX轴位置.TabIndex = 12;
            this.TextX轴位置.Text = "3500";
            // 
            // Text加速脉冲
            // 
            this.Text加速脉冲.Location = new System.Drawing.Point(62, 115);
            this.Text加速脉冲.Name = "Text加速脉冲";
            this.Text加速脉冲.Size = new System.Drawing.Size(71, 21);
            this.Text加速脉冲.TabIndex = 11;
            this.Text加速脉冲.Text = "10";
            // 
            // TextB轴位置
            // 
            this.TextB轴位置.Location = new System.Drawing.Point(178, 143);
            this.TextB轴位置.Name = "TextB轴位置";
            this.TextB轴位置.Size = new System.Drawing.Size(71, 21);
            this.TextB轴位置.TabIndex = 10;
            this.TextB轴位置.Text = "1800";
            // 
            // Text加速时间
            // 
            this.Text加速时间.Location = new System.Drawing.Point(62, 63);
            this.Text加速时间.Name = "Text加速时间";
            this.Text加速时间.Size = new System.Drawing.Size(71, 21);
            this.Text加速时间.TabIndex = 11;
            this.Text加速时间.Text = "0.1";
            // 
            // TextU轴位置
            // 
            this.TextU轴位置.Location = new System.Drawing.Point(178, 92);
            this.TextU轴位置.Name = "TextU轴位置";
            this.TextU轴位置.Size = new System.Drawing.Size(71, 21);
            this.TextU轴位置.TabIndex = 10;
            this.TextU轴位置.Text = "1500";
            // 
            // Text减速脉冲
            // 
            this.Text减速脉冲.Location = new System.Drawing.Point(62, 140);
            this.Text减速脉冲.Name = "Text减速脉冲";
            this.Text减速脉冲.Size = new System.Drawing.Size(71, 21);
            this.Text减速脉冲.TabIndex = 10;
            this.Text减速脉冲.Text = "10";
            // 
            // Text减速时间
            // 
            this.Text减速时间.Location = new System.Drawing.Point(62, 88);
            this.Text减速时间.Name = "Text减速时间";
            this.Text减速时间.Size = new System.Drawing.Size(71, 21);
            this.Text减速时间.TabIndex = 10;
            this.Text减速时间.Text = "0.1";
            // 
            // Text起始速度
            // 
            this.Text起始速度.Location = new System.Drawing.Point(62, 14);
            this.Text起始速度.Name = "Text起始速度";
            this.Text起始速度.Size = new System.Drawing.Size(71, 21);
            this.Text起始速度.TabIndex = 9;
            this.Text起始速度.Text = "500";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(149, 122);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(23, 12);
            this.label22.TabIndex = 7;
            this.label22.Text = "A轴";
            // 
            // Text运行速度
            // 
            this.Text运行速度.Location = new System.Drawing.Point(62, 38);
            this.Text运行速度.Name = "Text运行速度";
            this.Text运行速度.Size = new System.Drawing.Size(71, 21);
            this.Text运行速度.TabIndex = 8;
            this.Text运行速度.Text = "5000";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(149, 71);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(23, 12);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Z轴";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(149, 45);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(23, 12);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "Y轴";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(149, 147);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 12);
            this.label21.TabIndex = 4;
            this.label21.Text = "B轴";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(149, 18);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(23, 12);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "X轴";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(149, 96);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(23, 12);
            this.Label15.TabIndex = 4;
            this.Label15.Text = "U轴";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(6, 145);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(53, 12);
            this.Label17.TabIndex = 4;
            this.Label17.Text = "减速脉冲";
            // 
            // La加速脉冲
            // 
            this.La加速脉冲.AutoSize = true;
            this.La加速脉冲.Location = new System.Drawing.Point(6, 120);
            this.La加速脉冲.Name = "La加速脉冲";
            this.La加速脉冲.Size = new System.Drawing.Size(53, 12);
            this.La加速脉冲.TabIndex = 3;
            this.La加速脉冲.Text = "加速脉冲";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 93);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(53, 12);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "减速时间";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 69);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(53, 12);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "加速时间";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 41);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(0, 12);
            this.Label3.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(53, 12);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "驱动速度";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "起始速度";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.radio六轴直线插补);
            this.GroupBox5.Controls.Add(this.Radio四轴直线插补);
            this.GroupBox5.Controls.Add(this.Radio三轴直线插补);
            this.GroupBox5.Controls.Add(this.Radio圆弧插补);
            this.GroupBox5.Controls.Add(this.Radio两轴直线插补);
            this.GroupBox5.Controls.Add(this.La运行方式);
            this.GroupBox5.Controls.Add(this.Radio单轴S形位置运动非);
            this.GroupBox5.Controls.Add(this.Radio单轴S形位置运动对);
            this.GroupBox5.Controls.Add(this.Radio单轴T形位置运动非);
            this.GroupBox5.Controls.Add(this.Radio单轴T形位置运动对);
            this.GroupBox5.Controls.Add(this.Radio单轴S形连续运动);
            this.GroupBox5.Controls.Add(this.Radio单轴T形连续运动);
            this.GroupBox5.Location = new System.Drawing.Point(300, 131);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(130, 218);
            this.GroupBox5.TabIndex = 19;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "运动模式";
            // 
            // radio六轴直线插补
            // 
            this.radio六轴直线插补.AutoSize = true;
            this.radio六轴直线插补.Location = new System.Drawing.Point(4, 166);
            this.radio六轴直线插补.Name = "radio六轴直线插补";
            this.radio六轴直线插补.Size = new System.Drawing.Size(95, 16);
            this.radio六轴直线插补.TabIndex = 10;
            this.radio六轴直线插补.TabStop = true;
            this.radio六轴直线插补.Text = "六轴直线插补";
            this.radio六轴直线插补.UseVisualStyleBackColor = true;
            // 
            // Radio四轴直线插补
            // 
            this.Radio四轴直线插补.AutoSize = true;
            this.Radio四轴直线插补.Location = new System.Drawing.Point(4, 150);
            this.Radio四轴直线插补.Name = "Radio四轴直线插补";
            this.Radio四轴直线插补.Size = new System.Drawing.Size(95, 16);
            this.Radio四轴直线插补.TabIndex = 9;
            this.Radio四轴直线插补.TabStop = true;
            this.Radio四轴直线插补.Text = "四轴直线插补";
            this.Radio四轴直线插补.UseVisualStyleBackColor = true;
            // 
            // Radio三轴直线插补
            // 
            this.Radio三轴直线插补.AutoSize = true;
            this.Radio三轴直线插补.Location = new System.Drawing.Point(4, 133);
            this.Radio三轴直线插补.Name = "Radio三轴直线插补";
            this.Radio三轴直线插补.Size = new System.Drawing.Size(95, 16);
            this.Radio三轴直线插补.TabIndex = 9;
            this.Radio三轴直线插补.TabStop = true;
            this.Radio三轴直线插补.Text = "三轴直线插补";
            this.Radio三轴直线插补.UseVisualStyleBackColor = true;
            // 
            // Radio圆弧插补
            // 
            this.Radio圆弧插补.AutoSize = true;
            this.Radio圆弧插补.Location = new System.Drawing.Point(4, 183);
            this.Radio圆弧插补.Name = "Radio圆弧插补";
            this.Radio圆弧插补.Size = new System.Drawing.Size(71, 16);
            this.Radio圆弧插补.TabIndex = 8;
            this.Radio圆弧插补.TabStop = true;
            this.Radio圆弧插补.Text = "圆弧插补";
            this.Radio圆弧插补.UseVisualStyleBackColor = true;
            // 
            // Radio两轴直线插补
            // 
            this.Radio两轴直线插补.AutoSize = true;
            this.Radio两轴直线插补.Location = new System.Drawing.Point(4, 116);
            this.Radio两轴直线插补.Name = "Radio两轴直线插补";
            this.Radio两轴直线插补.Size = new System.Drawing.Size(95, 16);
            this.Radio两轴直线插补.TabIndex = 7;
            this.Radio两轴直线插补.TabStop = true;
            this.Radio两轴直线插补.Text = "两轴直线插补";
            this.Radio两轴直线插补.UseVisualStyleBackColor = true;
            // 
            // La运行方式
            // 
            this.La运行方式.AutoSize = true;
            this.La运行方式.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La运行方式.ForeColor = System.Drawing.Color.Red;
            this.La运行方式.Location = new System.Drawing.Point(3, 203);
            this.La运行方式.Name = "La运行方式";
            this.La运行方式.Size = new System.Drawing.Size(53, 12);
            this.La运行方式.TabIndex = 6;
            this.La运行方式.Text = "运行方式";
            // 
            // Radio单轴S形位置运动非
            // 
            this.Radio单轴S形位置运动非.AutoSize = true;
            this.Radio单轴S形位置运动非.Location = new System.Drawing.Point(4, 100);
            this.Radio单轴S形位置运动非.Name = "Radio单轴S形位置运动非";
            this.Radio单轴S形位置运动非.Size = new System.Drawing.Size(125, 16);
            this.Radio单轴S形位置运动非.TabIndex = 5;
            this.Radio单轴S形位置运动非.TabStop = true;
            this.Radio单轴S形位置运动非.Text = "单轴S形位置运动非";
            this.Radio单轴S形位置运动非.UseVisualStyleBackColor = true;
            // 
            // Radio单轴S形位置运动对
            // 
            this.Radio单轴S形位置运动对.AutoSize = true;
            this.Radio单轴S形位置运动对.Location = new System.Drawing.Point(4, 83);
            this.Radio单轴S形位置运动对.Name = "Radio单轴S形位置运动对";
            this.Radio单轴S形位置运动对.Size = new System.Drawing.Size(125, 16);
            this.Radio单轴S形位置运动对.TabIndex = 4;
            this.Radio单轴S形位置运动对.TabStop = true;
            this.Radio单轴S形位置运动对.Text = "单轴S形位置运动对";
            this.Radio单轴S形位置运动对.UseVisualStyleBackColor = true;
            // 
            // Radio单轴T形位置运动非
            // 
            this.Radio单轴T形位置运动非.AutoSize = true;
            this.Radio单轴T形位置运动非.Location = new System.Drawing.Point(4, 66);
            this.Radio单轴T形位置运动非.Name = "Radio单轴T形位置运动非";
            this.Radio单轴T形位置运动非.Size = new System.Drawing.Size(125, 16);
            this.Radio单轴T形位置运动非.TabIndex = 3;
            this.Radio单轴T形位置运动非.TabStop = true;
            this.Radio单轴T形位置运动非.Text = "单轴T形位置运动非";
            this.Radio单轴T形位置运动非.UseVisualStyleBackColor = true;
            // 
            // Radio单轴T形位置运动对
            // 
            this.Radio单轴T形位置运动对.AutoSize = true;
            this.Radio单轴T形位置运动对.Location = new System.Drawing.Point(4, 49);
            this.Radio单轴T形位置运动对.Name = "Radio单轴T形位置运动对";
            this.Radio单轴T形位置运动对.Size = new System.Drawing.Size(125, 16);
            this.Radio单轴T形位置运动对.TabIndex = 2;
            this.Radio单轴T形位置运动对.TabStop = true;
            this.Radio单轴T形位置运动对.Text = "单轴T形位置运动对";
            this.Radio单轴T形位置运动对.UseVisualStyleBackColor = true;
            // 
            // Radio单轴S形连续运动
            // 
            this.Radio单轴S形连续运动.AutoSize = true;
            this.Radio单轴S形连续运动.Location = new System.Drawing.Point(4, 32);
            this.Radio单轴S形连续运动.Name = "Radio单轴S形连续运动";
            this.Radio单轴S形连续运动.Size = new System.Drawing.Size(113, 16);
            this.Radio单轴S形连续运动.TabIndex = 1;
            this.Radio单轴S形连续运动.Text = "单轴S形连续运动";
            this.Radio单轴S形连续运动.UseVisualStyleBackColor = true;
            // 
            // Radio单轴T形连续运动
            // 
            this.Radio单轴T形连续运动.AutoSize = true;
            this.Radio单轴T形连续运动.Checked = true;
            this.Radio单轴T形连续运动.Location = new System.Drawing.Point(4, 15);
            this.Radio单轴T形连续运动.Name = "Radio单轴T形连续运动";
            this.Radio单轴T形连续运动.Size = new System.Drawing.Size(113, 16);
            this.Radio单轴T形连续运动.TabIndex = 0;
            this.Radio单轴T形连续运动.TabStop = true;
            this.Radio单轴T形连续运动.Text = "单轴T形连续运动";
            this.Radio单轴T形连续运动.UseVisualStyleBackColor = true;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.But单轴启动);
            this.GroupBox6.Controls.Add(this.But同步停止);
            this.GroupBox6.Controls.Add(this.But紧急停止);
            this.GroupBox6.Controls.Add(this.But单轴停止);
            this.GroupBox6.Location = new System.Drawing.Point(300, 441);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(115, 114);
            this.GroupBox6.TabIndex = 20;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "启动停止方式";
            // 
            // But单轴启动
            // 
            this.But单轴启动.Location = new System.Drawing.Point(22, 14);
            this.But单轴启动.Name = "But单轴启动";
            this.But单轴启动.Size = new System.Drawing.Size(75, 23);
            this.But单轴启动.TabIndex = 0;
            this.But单轴启动.Text = "单轴启动";
            this.But单轴启动.UseVisualStyleBackColor = true;
            this.But单轴启动.Click += new System.EventHandler(this.But单轴启动_Click);
            // 
            // But同步停止
            // 
            this.But同步停止.Location = new System.Drawing.Point(22, 62);
            this.But同步停止.Name = "But同步停止";
            this.But同步停止.Size = new System.Drawing.Size(75, 23);
            this.But同步停止.TabIndex = 1;
            this.But同步停止.Text = "同步停止";
            this.But同步停止.UseVisualStyleBackColor = true;
            this.But同步停止.Click += new System.EventHandler(this.But同步停止_Click);
            // 
            // But紧急停止
            // 
            this.But紧急停止.Location = new System.Drawing.Point(22, 87);
            this.But紧急停止.Name = "But紧急停止";
            this.But紧急停止.Size = new System.Drawing.Size(75, 23);
            this.But紧急停止.TabIndex = 2;
            this.But紧急停止.Text = "紧急停止";
            this.But紧急停止.UseVisualStyleBackColor = true;
            this.But紧急停止.Click += new System.EventHandler(this.But紧急停止_Click);
            // 
            // But单轴停止
            // 
            this.But单轴停止.Location = new System.Drawing.Point(22, 39);
            this.But单轴停止.Name = "But单轴停止";
            this.But单轴停止.Size = new System.Drawing.Size(74, 22);
            this.But单轴停止.TabIndex = 7;
            this.But单轴停止.Text = "单轴停止";
            this.But单轴停止.UseVisualStyleBackColor = true;
            this.But单轴停止.Click += new System.EventHandler(this.But单轴停止_Click);
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.La0启动命令);
            this.GroupBox9.Controls.Add(this.La16X轴DIR信号);
            this.GroupBox9.Controls.Add(this.La15X轴INP信号);
            this.GroupBox9.Controls.Add(this.La9X轴ERC信号);
            this.GroupBox9.Controls.Add(this.La8X轴PCS信号);
            this.GroupBox9.Controls.Add(this.La7X轴急停);
            this.GroupBox9.Controls.Add(this.La1X轴脉冲输出);
            this.GroupBox9.Controls.Add(this.La15X轴SD);
            this.GroupBox9.Controls.Add(this.La14X轴ORG);
            this.GroupBox9.Controls.Add(this.La13X轴MEL);
            this.GroupBox9.Controls.Add(this.La12X轴PEL);
            this.GroupBox9.Controls.Add(this.La11X轴ALM);
            this.GroupBox9.Controls.Add(this.La10X轴FC);
            this.GroupBox9.Controls.Add(this.La9X轴FD);
            this.GroupBox9.Controls.Add(this.La8X轴FU);
            this.GroupBox9.Controls.Add(this.LaY位置比较);
            this.GroupBox9.Controls.Add(this.LaX位置比较);
            this.GroupBox9.Controls.Add(this.LaY准备RDY);
            this.GroupBox9.Controls.Add(this.LaX准备RDY);
            this.GroupBox9.Controls.Add(this.LaY使能);
            this.GroupBox9.Controls.Add(this.LaX使能);
            this.GroupBox9.Location = new System.Drawing.Point(434, 216);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(138, 335);
            this.GroupBox9.TabIndex = 21;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "驱动器信号";
            // 
            // La0启动命令
            // 
            this.La0启动命令.AutoSize = true;
            this.La0启动命令.ForeColor = System.Drawing.Color.Blue;
            this.La0启动命令.Location = new System.Drawing.Point(6, 229);
            this.La0启动命令.Name = "La0启动命令";
            this.La0启动命令.Size = new System.Drawing.Size(95, 12);
            this.La0启动命令.TabIndex = 0;
            this.La0启动命令.Text = "0X轴启动命令OFF";
            // 
            // La16X轴DIR信号
            // 
            this.La16X轴DIR信号.AutoSize = true;
            this.La16X轴DIR信号.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.La16X轴DIR信号.Location = new System.Drawing.Point(5, 320);
            this.La16X轴DIR信号.Name = "La16X轴DIR信号";
            this.La16X轴DIR信号.Size = new System.Drawing.Size(101, 12);
            this.La16X轴DIR信号.TabIndex = 0;
            this.La16X轴DIR信号.Text = "16X轴DIR信号正向";
            // 
            // La15X轴INP信号
            // 
            this.La15X轴INP信号.AutoSize = true;
            this.La15X轴INP信号.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.La15X轴INP信号.Location = new System.Drawing.Point(6, 305);
            this.La15X轴INP信号.Name = "La15X轴INP信号";
            this.La15X轴INP信号.Size = new System.Drawing.Size(95, 12);
            this.La15X轴INP信号.TabIndex = 0;
            this.La15X轴INP信号.Text = "15X轴INP信号OFF";
            // 
            // La9X轴ERC信号
            // 
            this.La9X轴ERC信号.AutoSize = true;
            this.La9X轴ERC信号.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.La9X轴ERC信号.Location = new System.Drawing.Point(6, 290);
            this.La9X轴ERC信号.Name = "La9X轴ERC信号";
            this.La9X轴ERC信号.Size = new System.Drawing.Size(89, 12);
            this.La9X轴ERC信号.TabIndex = 0;
            this.La9X轴ERC信号.Text = "9X轴ERC信号OFF";
            // 
            // La8X轴PCS信号
            // 
            this.La8X轴PCS信号.AutoSize = true;
            this.La8X轴PCS信号.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.La8X轴PCS信号.Location = new System.Drawing.Point(6, 274);
            this.La8X轴PCS信号.Name = "La8X轴PCS信号";
            this.La8X轴PCS信号.Size = new System.Drawing.Size(89, 12);
            this.La8X轴PCS信号.TabIndex = 0;
            this.La8X轴PCS信号.Text = "8X轴PCS信号OFF";
            // 
            // La7X轴急停
            // 
            this.La7X轴急停.AutoSize = true;
            this.La7X轴急停.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.La7X轴急停.Location = new System.Drawing.Point(6, 259);
            this.La7X轴急停.Name = "La7X轴急停";
            this.La7X轴急停.Size = new System.Drawing.Size(71, 12);
            this.La7X轴急停.TabIndex = 0;
            this.La7X轴急停.Text = "7X轴急停OFF";
            // 
            // La1X轴脉冲输出
            // 
            this.La1X轴脉冲输出.AutoSize = true;
            this.La1X轴脉冲输出.ForeColor = System.Drawing.Color.Blue;
            this.La1X轴脉冲输出.Location = new System.Drawing.Point(6, 244);
            this.La1X轴脉冲输出.Name = "La1X轴脉冲输出";
            this.La1X轴脉冲输出.Size = new System.Drawing.Size(71, 12);
            this.La1X轴脉冲输出.TabIndex = 0;
            this.La1X轴脉冲输出.Text = "1X轴脉冲OFF";
            // 
            // La15X轴SD
            // 
            this.La15X轴SD.AutoSize = true;
            this.La15X轴SD.Location = new System.Drawing.Point(6, 214);
            this.La15X轴SD.Name = "La15X轴SD";
            this.La15X轴SD.Size = new System.Drawing.Size(47, 12);
            this.La15X轴SD.TabIndex = 0;
            this.La15X轴SD.Text = "15X轴SD";
            // 
            // La14X轴ORG
            // 
            this.La14X轴ORG.AutoSize = true;
            this.La14X轴ORG.Location = new System.Drawing.Point(6, 200);
            this.La14X轴ORG.Name = "La14X轴ORG";
            this.La14X轴ORG.Size = new System.Drawing.Size(77, 12);
            this.La14X轴ORG.TabIndex = 0;
            this.La14X轴ORG.Text = "14X轴ORG原点";
            // 
            // La13X轴MEL
            // 
            this.La13X轴MEL.AutoSize = true;
            this.La13X轴MEL.Location = new System.Drawing.Point(6, 186);
            this.La13X轴MEL.Name = "La13X轴MEL";
            this.La13X轴MEL.Size = new System.Drawing.Size(89, 12);
            this.La13X轴MEL.TabIndex = 0;
            this.La13X轴MEL.Text = "13X轴MEL负限位";
            // 
            // La12X轴PEL
            // 
            this.La12X轴PEL.AutoSize = true;
            this.La12X轴PEL.Location = new System.Drawing.Point(5, 171);
            this.La12X轴PEL.Name = "La12X轴PEL";
            this.La12X轴PEL.Size = new System.Drawing.Size(89, 12);
            this.La12X轴PEL.TabIndex = 0;
            this.La12X轴PEL.Text = "12X轴PEL正限位";
            // 
            // La11X轴ALM
            // 
            this.La11X轴ALM.AutoSize = true;
            this.La11X轴ALM.Location = new System.Drawing.Point(5, 156);
            this.La11X轴ALM.Name = "La11X轴ALM";
            this.La11X轴ALM.Size = new System.Drawing.Size(77, 12);
            this.La11X轴ALM.TabIndex = 0;
            this.La11X轴ALM.Text = "11X轴ALM报警";
            // 
            // La10X轴FC
            // 
            this.La10X轴FC.AutoSize = true;
            this.La10X轴FC.Location = new System.Drawing.Point(5, 140);
            this.La10X轴FC.Name = "La10X轴FC";
            this.La10X轴FC.Size = new System.Drawing.Size(71, 12);
            this.La10X轴FC.TabIndex = 0;
            this.La10X轴FC.Text = "10X轴FC低速";
            // 
            // La9X轴FD
            // 
            this.La9X轴FD.AutoSize = true;
            this.La9X轴FD.Location = new System.Drawing.Point(6, 125);
            this.La9X轴FD.Name = "La9X轴FD";
            this.La9X轴FD.Size = new System.Drawing.Size(65, 12);
            this.La9X轴FD.TabIndex = 0;
            this.La9X轴FD.Text = "9X轴FD减速";
            // 
            // La8X轴FU
            // 
            this.La8X轴FU.AutoSize = true;
            this.La8X轴FU.Location = new System.Drawing.Point(6, 109);
            this.La8X轴FU.Name = "La8X轴FU";
            this.La8X轴FU.Size = new System.Drawing.Size(65, 12);
            this.La8X轴FU.TabIndex = 0;
            this.La8X轴FU.Text = "8X轴FU加速";
            // 
            // LaY位置比较
            // 
            this.LaY位置比较.AutoSize = true;
            this.LaY位置比较.Location = new System.Drawing.Point(6, 94);
            this.LaY位置比较.Name = "LaY位置比较";
            this.LaY位置比较.Size = new System.Drawing.Size(53, 12);
            this.LaY位置比较.TabIndex = 0;
            this.LaY位置比较.Text = "YCMP比较";
            // 
            // LaX位置比较
            // 
            this.LaX位置比较.AutoSize = true;
            this.LaX位置比较.Location = new System.Drawing.Point(6, 80);
            this.LaX位置比较.Name = "LaX位置比较";
            this.LaX位置比较.Size = new System.Drawing.Size(53, 12);
            this.LaX位置比较.TabIndex = 0;
            this.LaX位置比较.Text = "XCMP比较";
            // 
            // LaY准备RDY
            // 
            this.LaY准备RDY.AutoSize = true;
            this.LaY准备RDY.Location = new System.Drawing.Point(6, 66);
            this.LaY准备RDY.Name = "LaY准备RDY";
            this.LaY准备RDY.Size = new System.Drawing.Size(35, 12);
            this.LaY准备RDY.TabIndex = 0;
            this.LaY准备RDY.Text = "Y准备";
            // 
            // LaX准备RDY
            // 
            this.LaX准备RDY.AutoSize = true;
            this.LaX准备RDY.Location = new System.Drawing.Point(6, 51);
            this.LaX准备RDY.Name = "LaX准备RDY";
            this.LaX准备RDY.Size = new System.Drawing.Size(35, 12);
            this.LaX准备RDY.TabIndex = 0;
            this.LaX准备RDY.Text = "X准备";
            // 
            // LaY使能
            // 
            this.LaY使能.AutoSize = true;
            this.LaY使能.Location = new System.Drawing.Point(6, 35);
            this.LaY使能.Name = "LaY使能";
            this.LaY使能.Size = new System.Drawing.Size(35, 12);
            this.LaY使能.TabIndex = 0;
            this.LaY使能.Text = "Y使能";
            // 
            // LaX使能
            // 
            this.LaX使能.AutoSize = true;
            this.LaX使能.Location = new System.Drawing.Point(6, 19);
            this.LaX使能.Name = "LaX使能";
            this.LaX使能.Size = new System.Drawing.Size(35, 12);
            this.LaX使能.TabIndex = 0;
            this.LaX使能.Text = "X使能";
            // 
            // Lab运检测
            // 
            this.Lab运检测.AutoSize = true;
            this.Lab运检测.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab运检测.ForeColor = System.Drawing.Color.Red;
            this.Lab运检测.Location = new System.Drawing.Point(7, 558);
            this.Lab运检测.Name = "Lab运检测";
            this.Lab运检测.Size = new System.Drawing.Size(53, 12);
            this.Lab运检测.TabIndex = 22;
            this.Lab运检测.Text = "运动检测";
            // 
            // radio相对模式
            // 
            this.radio相对模式.AutoSize = true;
            this.radio相对模式.Checked = true;
            this.radio相对模式.Location = new System.Drawing.Point(191, 339);
            this.radio相对模式.Name = "radio相对模式";
            this.radio相对模式.Size = new System.Drawing.Size(71, 16);
            this.radio相对模式.TabIndex = 29;
            this.radio相对模式.TabStop = true;
            this.radio相对模式.Text = "相对模式";
            this.radio相对模式.UseVisualStyleBackColor = true;
            // 
            // radio绝对模式
            // 
            this.radio绝对模式.AutoSize = true;
            this.radio绝对模式.Location = new System.Drawing.Point(190, 360);
            this.radio绝对模式.Name = "radio绝对模式";
            this.radio绝对模式.Size = new System.Drawing.Size(71, 16);
            this.radio绝对模式.TabIndex = 30;
            this.radio绝对模式.Text = "绝对模式";
            this.radio绝对模式.UseVisualStyleBackColor = true;
            // 
            // DMC2610操作画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 593);
            this.Controls.Add(this.Lab运检测);
            this.Controls.Add(this.GroupBox9);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox8);
            this.Controls.Add(this.GroupBox7);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "DMC2610操作画面";
            this.Text = "雷泰DMC2610控制卡";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DMC2610操作画面_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DMC2610操作画面_FormClosed);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Timer Timer位置显示;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem 单轴位置启动ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem 单轴启动ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem 单轴连续启动ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem 直线插补ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem 圆弧插补ToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        internal System.Windows.Forms.Timer Timer1驱动器接口检测;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox CheckPCS变终;
        internal System.Windows.Forms.CheckBox CheckSD减速;
        internal System.Windows.Forms.CheckBox CheckU轴;
        internal System.Windows.Forms.CheckBox Check电机方向选择;
        internal System.Windows.Forms.CheckBox CheckZ轴;
        internal System.Windows.Forms.CheckBox CheckY轴;
        internal System.Windows.Forms.CheckBox CheckX轴;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.Label LaX缓冲;
        internal System.Windows.Forms.Label LaZ缓冲;
        internal System.Windows.Forms.Label LaY缓冲;
        internal System.Windows.Forms.Label LaU缓冲;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label La速度方式;
        internal System.Windows.Forms.RadioButton Radio多轴插补速度;
        internal System.Windows.Forms.RadioButton Radio设置S形速度;
        internal System.Windows.Forms.RadioButton Radio设置T形速度;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton Radio单轴立即停止;
        internal System.Windows.Forms.RadioButton Radio单轴减速停止;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Label La3输出;
        internal System.Windows.Forms.Label La2输出;
        internal System.Windows.Forms.Label La1输出;
        internal System.Windows.Forms.Label La输入3;
        internal System.Windows.Forms.Label La输入2;
        internal System.Windows.Forms.Label La输入1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button But插补启动;
        internal System.Windows.Forms.CheckBox Check单轴变速;
        internal System.Windows.Forms.CheckBox Check比较;
        internal System.Windows.Forms.HScrollBar HScrollBar1;
        internal System.Windows.Forms.TextBox Text6U轴速度;
        internal System.Windows.Forms.TextBox Text5Z轴速度;
        internal System.Windows.Forms.TextBox Text4Y轴速度;
        internal System.Windows.Forms.TextBox Text3X轴速度;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Button But原点;
        internal System.Windows.Forms.Button But退出;
        internal System.Windows.Forms.TextBox Text3U轴当前位置;
        internal System.Windows.Forms.TextBox Text2Z轴当前位置;
        internal System.Windows.Forms.TextBox Text1Y轴当前位置;
        internal System.Windows.Forms.Button But清零;
        internal System.Windows.Forms.TextBox Text0X轴当前位置;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox Text比较数据;
        internal System.Windows.Forms.TextBox Text轴数;
        internal System.Windows.Forms.Label La比较数值;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox TextZ轴位置;
        internal System.Windows.Forms.TextBox TextY轴位置;
        internal System.Windows.Forms.TextBox TextX轴位置;
        internal System.Windows.Forms.TextBox Text加速脉冲;
        internal System.Windows.Forms.TextBox Text加速时间;
        internal System.Windows.Forms.TextBox TextU轴位置;
        internal System.Windows.Forms.TextBox Text减速脉冲;
        internal System.Windows.Forms.TextBox Text减速时间;
        internal System.Windows.Forms.TextBox Text起始速度;
        internal System.Windows.Forms.TextBox Text运行速度;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label La加速脉冲;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton Radio四轴直线插补;
        internal System.Windows.Forms.RadioButton Radio三轴直线插补;
        internal System.Windows.Forms.RadioButton Radio圆弧插补;
        internal System.Windows.Forms.RadioButton Radio两轴直线插补;
        internal System.Windows.Forms.Label La运行方式;
        internal System.Windows.Forms.RadioButton Radio单轴S形位置运动非;
        internal System.Windows.Forms.RadioButton Radio单轴S形位置运动对;
        internal System.Windows.Forms.RadioButton Radio单轴T形位置运动非;
        internal System.Windows.Forms.RadioButton Radio单轴T形位置运动对;
        internal System.Windows.Forms.RadioButton Radio单轴S形连续运动;
        internal System.Windows.Forms.RadioButton Radio单轴T形连续运动;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button But单轴启动;
        internal System.Windows.Forms.Button But同步停止;
        internal System.Windows.Forms.Button But紧急停止;
        internal System.Windows.Forms.Button But单轴停止;
        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.Label La0启动命令;
        internal System.Windows.Forms.Label La16X轴DIR信号;
        internal System.Windows.Forms.Label La15X轴INP信号;
        internal System.Windows.Forms.Label La9X轴ERC信号;
        internal System.Windows.Forms.Label La8X轴PCS信号;
        internal System.Windows.Forms.Label La7X轴急停;
        internal System.Windows.Forms.Label La1X轴脉冲输出;
        internal System.Windows.Forms.Label La15X轴SD;
        internal System.Windows.Forms.Label La14X轴ORG;
        internal System.Windows.Forms.Label La13X轴MEL;
        internal System.Windows.Forms.Label La12X轴PEL;
        internal System.Windows.Forms.Label La11X轴ALM;
        internal System.Windows.Forms.Label La10X轴FC;
        internal System.Windows.Forms.Label La9X轴FD;
        internal System.Windows.Forms.Label La8X轴FU;
        internal System.Windows.Forms.Label LaY位置比较;
        internal System.Windows.Forms.Label LaX位置比较;
        internal System.Windows.Forms.Label LaY准备RDY;
        internal System.Windows.Forms.Label LaX准备RDY;
        internal System.Windows.Forms.Label LaY使能;
        internal System.Windows.Forms.Label LaX使能;
        internal System.Windows.Forms.Label Lab运检测;
        private System.Windows.Forms.Label la变速度;
        private System.Windows.Forms.TextBox text改变目标位置;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox Text8B轴速度;
        internal System.Windows.Forms.TextBox Text7A轴速度;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.TextBox Text5B轴当前位置;
        internal System.Windows.Forms.TextBox Text4A轴当前位置;
        internal System.Windows.Forms.TextBox TextA轴位置;
        internal System.Windows.Forms.TextBox TextB轴位置;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.CheckBox CheckB轴;
        internal System.Windows.Forms.CheckBox CheckA轴;
        private System.Windows.Forms.RadioButton radio六轴直线插补;
        private System.Windows.Forms.Label LaB缓冲;
        private System.Windows.Forms.Label LaA缓冲;
        private System.Windows.Forms.RadioButton radio绝对模式;
        private System.Windows.Forms.RadioButton radio相对模式;

    }
}

