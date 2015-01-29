namespace RabAndTorSpeedRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgListRab = new System.Windows.Forms.ImageList(this.components);
            this.imgListTor = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imgListRab
            // 
            this.imgListRab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListRab.ImageStream")));
            this.imgListRab.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListRab.Images.SetKeyName(0, "兔正1.gif");
            this.imgListRab.Images.SetKeyName(1, "兔正2.gif");
            this.imgListRab.Images.SetKeyName(2, "兔正3.gif");
            this.imgListRab.Images.SetKeyName(3, "兔正4.gif");
            this.imgListRab.Images.SetKeyName(4, "兔反1.gif");
            this.imgListRab.Images.SetKeyName(5, "兔反2.gif");
            this.imgListRab.Images.SetKeyName(6, "兔反3.gif");
            this.imgListRab.Images.SetKeyName(7, "兔反4.gif");
            // 
            // imgListTor
            // 
            this.imgListTor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTor.ImageStream")));
            this.imgListTor.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListTor.Images.SetKeyName(0, "龟正1.gif");
            this.imgListTor.Images.SetKeyName(1, "龟正2.gif");
            this.imgListTor.Images.SetKeyName(2, "龟正3.gif");
            this.imgListTor.Images.SetKeyName(3, "龟正4.gif");
            this.imgListTor.Images.SetKeyName(4, "龟反1.gif");
            this.imgListTor.Images.SetKeyName(5, "龟反2.gif");
            this.imgListTor.Images.SetKeyName(6, "龟反3.gif");
            this.imgListTor.Images.SetKeyName(7, "龟反4.gif");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 266);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 301);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListRab;
        private System.Windows.Forms.ImageList imgListTor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStart;
    }
}

