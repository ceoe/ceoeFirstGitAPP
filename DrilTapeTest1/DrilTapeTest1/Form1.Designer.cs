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
            this.tb_CoordinateXY = new System.Windows.Forms.TextBox();
            this.tb_MiscOP = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.btnDrawDrl = new System.Windows.Forms.Button();
            this.btnFindMinMax = new System.Windows.Forms.Button();
            this.btnFillDataGR1 = new System.Windows.Forms.Button();
            this.dataGR1 = new System.Windows.Forms.DataGridView();
            this.dataSet13 = new System.Data.DataSet();
            this.button2 = new System.Windows.Forms.Button();
            this.lbKindofTools = new System.Windows.Forms.Label();
            this.lbTotalNumofHole = new System.Windows.Forms.Label();
            this.lbMinCoordXY = new System.Windows.Forms.Label();
            this.lbMaxCoordXY = new System.Windows.Forms.Label();
            this.numUDbox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGR1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDbox)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_CoordinateXY
            // 
            this.tb_CoordinateXY.Location = new System.Drawing.Point(22, 42);
            this.tb_CoordinateXY.MaxLength = 600000000;
            this.tb_CoordinateXY.Multiline = true;
            this.tb_CoordinateXY.Name = "tb_CoordinateXY";
            this.tb_CoordinateXY.ReadOnly = true;
            this.tb_CoordinateXY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_CoordinateXY.Size = new System.Drawing.Size(296, 184);
            this.tb_CoordinateXY.TabIndex = 0;
            // 
            // tb_MiscOP
            // 
            this.tb_MiscOP.Location = new System.Drawing.Point(33, 243);
            this.tb_MiscOP.Multiline = true;
            this.tb_MiscOP.Name = "tb_MiscOP";
            this.tb_MiscOP.ReadOnly = true;
            this.tb_MiscOP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_MiscOP.Size = new System.Drawing.Size(285, 199);
            this.tb_MiscOP.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(22, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "开始测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // picBox1
            // 
            this.picBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picBox1.Location = new System.Drawing.Point(348, 41);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(808, 749);
            this.picBox1.TabIndex = 3;
            this.picBox1.TabStop = false;
            this.picBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picBox1_MouseDoubleClick);
            // 
            // btnDrawDrl
            // 
            this.btnDrawDrl.Location = new System.Drawing.Point(114, 12);
            this.btnDrawDrl.Name = "btnDrawDrl";
            this.btnDrawDrl.Size = new System.Drawing.Size(75, 23);
            this.btnDrawDrl.TabIndex = 4;
            this.btnDrawDrl.Text = "绘制图形";
            this.btnDrawDrl.UseVisualStyleBackColor = true;
            this.btnDrawDrl.Click += new System.EventHandler(this.btnDrawDrl_Click);
            // 
            // btnFindMinMax
            // 
            this.btnFindMinMax.Location = new System.Drawing.Point(196, 13);
            this.btnFindMinMax.Name = "btnFindMinMax";
            this.btnFindMinMax.Size = new System.Drawing.Size(75, 23);
            this.btnFindMinMax.TabIndex = 5;
            this.btnFindMinMax.Text = "查找范围";
            this.btnFindMinMax.UseVisualStyleBackColor = true;
            this.btnFindMinMax.Click += new System.EventHandler(this.btnFindMinMax_Click);
            // 
            // btnFillDataGR1
            // 
            this.btnFillDataGR1.Location = new System.Drawing.Point(277, 13);
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
            this.dataGR1.Location = new System.Drawing.Point(31, 457);
            this.dataGR1.Name = "dataGR1";
            this.dataGR1.RowTemplate.Height = 23;
            this.dataGR1.Size = new System.Drawing.Size(287, 216);
            this.dataGR1.TabIndex = 7;
            // 
            // dataSet13
            // 
            this.dataSet13.DataSetName = "NewDataSet";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "test2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbKindofTools
            // 
            this.lbKindofTools.AutoSize = true;
            this.lbKindofTools.Location = new System.Drawing.Point(563, 22);
            this.lbKindofTools.Name = "lbKindofTools";
            this.lbKindofTools.Size = new System.Drawing.Size(89, 12);
            this.lbKindofTools.TabIndex = 11;
            this.lbKindofTools.Text = "Kind of Tools:";
            // 
            // lbTotalNumofHole
            // 
            this.lbTotalNumofHole.AutoSize = true;
            this.lbTotalNumofHole.Location = new System.Drawing.Point(699, 22);
            this.lbTotalNumofHole.Name = "lbTotalNumofHole";
            this.lbTotalNumofHole.Size = new System.Drawing.Size(77, 12);
            this.lbTotalNumofHole.TabIndex = 12;
            this.lbTotalNumofHole.Text = "Total Holes:";
            // 
            // lbMinCoordXY
            // 
            this.lbMinCoordXY.AutoSize = true;
            this.lbMinCoordXY.Location = new System.Drawing.Point(867, 24);
            this.lbMinCoordXY.Name = "lbMinCoordXY";
            this.lbMinCoordXY.Size = new System.Drawing.Size(29, 12);
            this.lbMinCoordXY.TabIndex = 13;
            this.lbMinCoordXY.Text = "Min:";
            // 
            // lbMaxCoordXY
            // 
            this.lbMaxCoordXY.AutoSize = true;
            this.lbMaxCoordXY.Location = new System.Drawing.Point(992, 23);
            this.lbMaxCoordXY.Name = "lbMaxCoordXY";
            this.lbMaxCoordXY.Size = new System.Drawing.Size(29, 12);
            this.lbMaxCoordXY.TabIndex = 14;
            this.lbMaxCoordXY.Text = "Max:";
            // 
            // numUDbox
            // 
            this.numUDbox.DecimalPlaces = 2;
            this.numUDbox.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numUDbox.Location = new System.Drawing.Point(482, 12);
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
            this.numUDbox.TabIndex = 15;
            this.numUDbox.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.numUDbox.ValueChanged += new System.EventHandler(this.numUDbox_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 802);
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
            this.Controls.Add(this.tb_CoordinateXY);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGR1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_CoordinateXY;
        private System.Windows.Forms.TextBox tb_MiscOP;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.Button btnDrawDrl;
        private System.Windows.Forms.Button btnFindMinMax;
        private System.Windows.Forms.Button btnFillDataGR1;
        private System.Windows.Forms.DataGridView dataGR1;
        private System.Data.DataSet dataSet13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbKindofTools;
        private System.Windows.Forms.Label lbTotalNumofHole;
        private System.Windows.Forms.Label lbMinCoordXY;
        private System.Windows.Forms.Label lbMaxCoordXY;
        private System.Windows.Forms.NumericUpDown numUDbox;
    }
}

