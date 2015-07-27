namespace point_operation
{
    partial class shapingForm
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
            this.open = new System.Windows.Forms.Button();
            this.startShaping = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(24, 270);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 0;
            this.open.Text = "打开文件";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // startShaping
            // 
            this.startShaping.Location = new System.Drawing.Point(149, 270);
            this.startShaping.Name = "startShaping";
            this.startShaping.Size = new System.Drawing.Size(75, 23);
            this.startShaping.TabIndex = 1;
            this.startShaping.Text = "确定";
            this.startShaping.UseVisualStyleBackColor = true;
            this.startShaping.Click += new System.EventHandler(this.startShaping_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(270, 270);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "退出";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // shapingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 315);
            this.ControlBox = false;
            this.Controls.Add(this.close);
            this.Controls.Add(this.startShaping);
            this.Controls.Add(this.open);
            this.Name = "shapingForm";
            this.Text = "直方图匹配";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.shapingForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button startShaping;
        private System.Windows.Forms.Button close;

        private string shapingFileName;
        private System.Drawing.Bitmap shapingBitmap;
        private int[] shapingPixel;
        private double[] cumHist;
        private int shapingSize;
        private int maxPixel;
    }
}