namespace DrilTapeTest1
{
    partial class Form1
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
            this.tb_MiscOP = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.btnDrawDrl = new System.Windows.Forms.Button();
            this.btnFindMinMax = new System.Windows.Forms.Button();
            this.btnFillDataGR1 = new System.Windows.Forms.Button();
            this.dataGR1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.lbKindofTools = new System.Windows.Forms.Label();
            this.lbTotalNumofHole = new System.Windows.Forms.Label();
            this.lbMinCoordXY = new System.Windows.Forms.Label();
            this.lbMaxCoordXY = new System.Windows.Forms.Label();
            this.numUDbox = new System.Windows.Forms.NumericUpDown();
            this.btnLoadAxisPara = new System.Windows.Forms.Button();
            this.btnInitialization = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label_POSITION = new System.Windows.Forms.Label();
            this.lbAxisStatus = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGR1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDbox)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_MiscOP
            // 
            this.tb_MiscOP.Location = new System.Drawing.Point(623, 60);
            this.tb_MiscOP.Multiline = true;
            this.tb_MiscOP.Name = "tb_MiscOP";
            this.tb_MiscOP.ReadOnly = true;
            this.tb_MiscOP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_MiscOP.Size = new System.Drawing.Size(285, 199);
            this.tb_MiscOP.TabIndex = 15;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(623, 24);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "开始测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // picBox1
            // 
            this.picBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.picBox1.Location = new System.Drawing.Point(12, 54);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(602, 610);
            this.picBox1.TabIndex = 3;
            this.picBox1.TabStop = false;
            this.picBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picBox1_MouseDoubleClick);
            // 
            // btnDrawDrl
            // 
            this.btnDrawDrl.Location = new System.Drawing.Point(93, 18);
            this.btnDrawDrl.Name = "btnDrawDrl";
            this.btnDrawDrl.Size = new System.Drawing.Size(75, 23);
            this.btnDrawDrl.TabIndex = 4;
            this.btnDrawDrl.Text = "绘制孔图";
            this.btnDrawDrl.UseVisualStyleBackColor = true;
            this.btnDrawDrl.Click += new System.EventHandler(this.btnDrawDrl_Click);
            // 
            // btnFindMinMax
            // 
            this.btnFindMinMax.Location = new System.Drawing.Point(722, 24);
            this.btnFindMinMax.Name = "btnFindMinMax";
            this.btnFindMinMax.Size = new System.Drawing.Size(75, 23);
            this.btnFindMinMax.TabIndex = 5;
            this.btnFindMinMax.Text = "查找范围";
            this.btnFindMinMax.UseVisualStyleBackColor = true;
            this.btnFindMinMax.Click += new System.EventHandler(this.btnFindMinMax_Click);
            // 
            // btnFillDataGR1
            // 
            this.btnFillDataGR1.Location = new System.Drawing.Point(817, 24);
            this.btnFillDataGR1.Name = "btnFillDataGR1";
            this.btnFillDataGR1.Size = new System.Drawing.Size(75, 23);
            this.btnFillDataGR1.TabIndex = 6;
            this.btnFillDataGR1.Text = "填充表格";
            this.btnFillDataGR1.UseVisualStyleBackColor = true;
            this.btnFillDataGR1.Click += new System.EventHandler(this.btnFillDataGR1_Click);
            // 
            // dataGR1
            // 
            this.dataGR1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGR1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGR1.Location = new System.Drawing.Point(621, 265);
            this.dataGR1.Name = "dataGR1";
            this.dataGR1.RowTemplate.Height = 23;
            this.dataGR1.Size = new System.Drawing.Size(287, 216);
            this.dataGR1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "读取钻带";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbKindofTools
            // 
            this.lbKindofTools.AutoSize = true;
            this.lbKindofTools.Location = new System.Drawing.Point(186, 9);
            this.lbKindofTools.Name = "lbKindofTools";
            this.lbKindofTools.Size = new System.Drawing.Size(89, 12);
            this.lbKindofTools.TabIndex = 11;
            this.lbKindofTools.Text = "Kind of Tools:";
            // 
            // lbTotalNumofHole
            // 
            this.lbTotalNumofHole.AutoSize = true;
            this.lbTotalNumofHole.Location = new System.Drawing.Point(186, 33);
            this.lbTotalNumofHole.Name = "lbTotalNumofHole";
            this.lbTotalNumofHole.Size = new System.Drawing.Size(77, 12);
            this.lbTotalNumofHole.TabIndex = 12;
            this.lbTotalNumofHole.Text = "Total Holes:";
            // 
            // lbMinCoordXY
            // 
            this.lbMinCoordXY.AutoSize = true;
            this.lbMinCoordXY.Location = new System.Drawing.Point(324, 9);
            this.lbMinCoordXY.Name = "lbMinCoordXY";
            this.lbMinCoordXY.Size = new System.Drawing.Size(59, 12);
            this.lbMinCoordXY.TabIndex = 13;
            this.lbMinCoordXY.Text = "MinCoord:";
            // 
            // lbMaxCoordXY
            // 
            this.lbMaxCoordXY.AutoSize = true;
            this.lbMaxCoordXY.Location = new System.Drawing.Point(324, 35);
            this.lbMaxCoordXY.Name = "lbMaxCoordXY";
            this.lbMaxCoordXY.Size = new System.Drawing.Size(59, 12);
            this.lbMaxCoordXY.TabIndex = 14;
            this.lbMaxCoordXY.Text = "MaxCoord:";
            // 
            // numUDbox
            // 
            this.numUDbox.DecimalPlaces = 2;
            this.numUDbox.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numUDbox.Location = new System.Drawing.Point(544, 26);
            this.numUDbox.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numUDbox.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numUDbox.Name = "numUDbox";
            this.numUDbox.Size = new System.Drawing.Size(58, 21);
            this.numUDbox.TabIndex = 1;
            this.numUDbox.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.numUDbox.ValueChanged += new System.EventHandler(this.numUDbox_ValueChanged);
            // 
            // btnLoadAxisPara
            // 
            this.btnLoadAxisPara.Location = new System.Drawing.Point(620, 487);
            this.btnLoadAxisPara.Name = "btnLoadAxisPara";
            this.btnLoadAxisPara.Size = new System.Drawing.Size(94, 23);
            this.btnLoadAxisPara.TabIndex = 16;
            this.btnLoadAxisPara.Text = "LoadAxisPara";
            this.btnLoadAxisPara.UseVisualStyleBackColor = true;
            this.btnLoadAxisPara.Click += new System.EventHandler(this.btnLoadAxisPara_Click);
            // 
            // btnInitialization
            // 
            this.btnInitialization.Location = new System.Drawing.Point(723, 487);
            this.btnInitialization.Name = "btnInitialization";
            this.btnInitialization.Size = new System.Drawing.Size(93, 23);
            this.btnInitialization.TabIndex = 17;
            this.btnInitialization.Text = "Initialzation";
            this.btnInitialization.UseVisualStyleBackColor = true;
            this.btnInitialization.Click += new System.EventHandler(this.btnInitialization_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Label_POSITION
            // 
            this.Label_POSITION.Location = new System.Drawing.Point(12, 690);
            this.Label_POSITION.Name = "Label_POSITION";
            this.Label_POSITION.Size = new System.Drawing.Size(602, 111);
            this.Label_POSITION.TabIndex = 18;
            this.Label_POSITION.Text = "Position:";
            // 
            // lbAxisStatus
            // 
            this.lbAxisStatus.AutoSize = true;
            this.lbAxisStatus.Location = new System.Drawing.Point(620, 562);
            this.lbAxisStatus.Name = "lbAxisStatus";
            this.lbAxisStatus.Size = new System.Drawing.Size(77, 12);
            this.lbAxisStatus.TabIndex = 19;
            this.lbAxisStatus.Text = "Axis Stauts:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(822, 487);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 20;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(620, 516);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(94, 23);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 810);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lbAxisStatus);
            this.Controls.Add(this.Label_POSITION);
            this.Controls.Add(this.btnInitialization);
            this.Controls.Add(this.btnLoadAxisPara);
            this.Controls.Add(this.numUDbox);
            this.Controls.Add(this.lbMaxCoordXY);
            this.Controls.Add(this.lbMinCoordXY);
            this.Controls.Add(this.lbTotalNumofHole);
            this.Controls.Add(this.lbKindofTools);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGR1);
            this.Controls.Add(this.btnFillDataGR1);
            this.Controls.Add(this.btnFindMinMax);
            this.Controls.Add(this.btnDrawDrl);
            this.Controls.Add(this.picBox1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tb_MiscOP);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGR1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_MiscOP;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.Button btnDrawDrl;
        private System.Windows.Forms.Button btnFindMinMax;
        private System.Windows.Forms.Button btnFillDataGR1;
        private System.Windows.Forms.DataGridView dataGR1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbKindofTools;
        private System.Windows.Forms.Label lbTotalNumofHole;
        private System.Windows.Forms.Label lbMinCoordXY;
        private System.Windows.Forms.Label lbMaxCoordXY;
        private System.Windows.Forms.NumericUpDown numUDbox;
        private System.Windows.Forms.Button btnLoadAxisPara;
        private System.Windows.Forms.Button btnInitialization;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Label_POSITION;
        private System.Windows.Forms.Label lbAxisStatus;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
    }
}

