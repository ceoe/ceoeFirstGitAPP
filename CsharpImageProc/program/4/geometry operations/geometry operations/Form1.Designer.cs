namespace geometry_operations
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
            this.open = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.translation = new System.Windows.Forms.Button();
            this.mirror = new System.Windows.Forms.Button();
            this.zoom = new System.Windows.Forms.Button();
            this.rotation = new System.Windows.Forms.Button();
            this.orgtrabar = new System.Windows.Forms.TrackBar();
            this.handletrabar = new System.Windows.Forms.TrackBar();
            this.tb_FillColor = new System.Windows.Forms.TextBox();
            this.tb_timer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoopX = new System.Windows.Forms.Button();
            this.Timeroffsetx = new System.Windows.Forms.Timer(this.components);
            this.traBrotate = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.orgtrabar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.handletrabar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traBrotate)).BeginInit();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(37, 46);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 0;
            this.open.Text = "打开图像";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(37, 92);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "关闭";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // translation
            // 
            this.translation.Location = new System.Drawing.Point(37, 150);
            this.translation.Name = "translation";
            this.translation.Size = new System.Drawing.Size(75, 23);
            this.translation.TabIndex = 2;
            this.translation.Text = "图像平移";
            this.translation.UseVisualStyleBackColor = true;
            this.translation.Click += new System.EventHandler(this.translation_Click);
            // 
            // mirror
            // 
            this.mirror.Location = new System.Drawing.Point(37, 196);
            this.mirror.Name = "mirror";
            this.mirror.Size = new System.Drawing.Size(75, 23);
            this.mirror.TabIndex = 3;
            this.mirror.Text = "图像镜像";
            this.mirror.UseVisualStyleBackColor = true;
            this.mirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // zoom
            // 
            this.zoom.Location = new System.Drawing.Point(37, 242);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(75, 23);
            this.zoom.TabIndex = 4;
            this.zoom.Text = "图像缩放";
            this.zoom.UseVisualStyleBackColor = true;
            this.zoom.Click += new System.EventHandler(this.zoom_Click);
            // 
            // rotation
            // 
            this.rotation.Location = new System.Drawing.Point(37, 288);
            this.rotation.Name = "rotation";
            this.rotation.Size = new System.Drawing.Size(75, 23);
            this.rotation.TabIndex = 5;
            this.rotation.Text = "图像旋转";
            this.rotation.UseVisualStyleBackColor = true;
            this.rotation.Click += new System.EventHandler(this.rotation_Click);
            // 
            // orgtrabar
            // 
            this.orgtrabar.Location = new System.Drawing.Point(159, 13);
            this.orgtrabar.Maximum = 16;
            this.orgtrabar.Minimum = 4;
            this.orgtrabar.Name = "orgtrabar";
            this.orgtrabar.Size = new System.Drawing.Size(104, 45);
            this.orgtrabar.TabIndex = 7;
            this.orgtrabar.Value = 8;
            this.orgtrabar.ValueChanged += new System.EventHandler(this.orgtrabar_ValueChanged);
            // 
            // handletrabar
            // 
            this.handletrabar.Location = new System.Drawing.Point(301, 12);
            this.handletrabar.Maximum = 9;
            this.handletrabar.Minimum = 1;
            this.handletrabar.Name = "handletrabar";
            this.handletrabar.Size = new System.Drawing.Size(104, 45);
            this.handletrabar.TabIndex = 8;
            this.handletrabar.Value = 4;
            this.handletrabar.ValueChanged += new System.EventHandler(this.orgtrabar_ValueChanged);
            // 
            // tb_FillColor
            // 
            this.tb_FillColor.Location = new System.Drawing.Point(37, 12);
            this.tb_FillColor.Name = "tb_FillColor";
            this.tb_FillColor.Size = new System.Drawing.Size(100, 21);
            this.tb_FillColor.TabIndex = 9;
            this.tb_FillColor.Text = "100";
            // 
            // tb_timer
            // 
            this.tb_timer.Location = new System.Drawing.Point(37, 357);
            this.tb_timer.Name = "tb_timer";
            this.tb_timer.Size = new System.Drawing.Size(100, 21);
            this.tb_timer.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "耗时";
            // 
            // btnLoopX
            // 
            this.btnLoopX.Location = new System.Drawing.Point(25, 121);
            this.btnLoopX.Name = "btnLoopX";
            this.btnLoopX.Size = new System.Drawing.Size(87, 23);
            this.btnLoopX.TabIndex = 13;
            this.btnLoopX.Text = "水平循环移动";
            this.btnLoopX.UseVisualStyleBackColor = true;
            this.btnLoopX.Click += new System.EventHandler(this.btnLoopX_Click);
            // 
            // Timeroffsetx
            // 
            this.Timeroffsetx.Interval = 10;
            this.Timeroffsetx.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // traBrotate
            // 
            this.traBrotate.Location = new System.Drawing.Point(443, 12);
            this.traBrotate.Maximum = 24;
            this.traBrotate.Name = "traBrotate";
            this.traBrotate.Size = new System.Drawing.Size(104, 45);
            this.traBrotate.TabIndex = 14;
            this.traBrotate.Value = 4;
            this.traBrotate.ValueChanged += new System.EventHandler(this.traBrotate_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 565);
            this.Controls.Add(this.traBrotate);
            this.Controls.Add(this.btnLoopX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_timer);
            this.Controls.Add(this.tb_FillColor);
            this.Controls.Add(this.handletrabar);
            this.Controls.Add(this.orgtrabar);
            this.Controls.Add(this.rotation);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.mirror);
            this.Controls.Add(this.translation);
            this.Controls.Add(this.close);
            this.Controls.Add(this.open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.orgtrabar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.handletrabar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traBrotate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button close;
        private string curFileName = null;
        private System.Drawing.Bitmap curBitmap = null;
        private System.Drawing.Bitmap handleBitmap = null;

        private System.Windows.Forms.Button translation;
        private System.Windows.Forms.Button mirror;
        private System.Windows.Forms.Button zoom;
        private System.Windows.Forms.Button rotation;
        private System.Windows.Forms.TrackBar orgtrabar;
        private System.Windows.Forms.TrackBar handletrabar;
        private System.Windows.Forms.TextBox tb_FillColor;
        private System.Windows.Forms.TextBox tb_timer;
        private System.Windows.Forms.Label label2;

        private HiPerfTimer timercount;
        int pixeldepth ;
        private int Timercountbtn;
        private System.Windows.Forms.Button btnLoopX;
        private System.Windows.Forms.Timer Timeroffsetx;
        private System.Windows.Forms.TrackBar traBrotate;
    }
}

