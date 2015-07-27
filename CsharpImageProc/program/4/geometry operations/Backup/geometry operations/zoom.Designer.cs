namespace geometry_operations
{
    partial class zoom
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
            this.startZoom = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bilinear = new System.Windows.Forms.RadioButton();
            this.nearestNeigh = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xZoom = new System.Windows.Forms.TextBox();
            this.yZoom = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startZoom
            // 
            this.startZoom.Location = new System.Drawing.Point(54, 205);
            this.startZoom.Name = "startZoom";
            this.startZoom.Size = new System.Drawing.Size(75, 23);
            this.startZoom.TabIndex = 0;
            this.startZoom.Text = "确定";
            this.startZoom.UseVisualStyleBackColor = true;
            this.startZoom.Click += new System.EventHandler(this.startZoom_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(247, 205);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "退出";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bilinear);
            this.groupBox1.Controls.Add(this.nearestNeigh);
            this.groupBox1.Location = new System.Drawing.Point(28, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 92);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "灰度插值";
            // 
            // bilinear
            // 
            this.bilinear.AutoSize = true;
            this.bilinear.Location = new System.Drawing.Point(190, 41);
            this.bilinear.Name = "bilinear";
            this.bilinear.Size = new System.Drawing.Size(83, 16);
            this.bilinear.TabIndex = 1;
            this.bilinear.Text = "双线性插值";
            this.bilinear.UseVisualStyleBackColor = true;
            // 
            // nearestNeigh
            // 
            this.nearestNeigh.AutoSize = true;
            this.nearestNeigh.Checked = true;
            this.nearestNeigh.Location = new System.Drawing.Point(26, 41);
            this.nearestNeigh.Name = "nearestNeigh";
            this.nearestNeigh.Size = new System.Drawing.Size(83, 16);
            this.nearestNeigh.TabIndex = 0;
            this.nearestNeigh.TabStop = true;
            this.nearestNeigh.Text = "最近邻插值";
            this.nearestNeigh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "横向缩放量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "纵向缩放量：";
            // 
            // xZoom
            // 
            this.xZoom.Location = new System.Drawing.Point(109, 146);
            this.xZoom.Name = "xZoom";
            this.xZoom.Size = new System.Drawing.Size(54, 21);
            this.xZoom.TabIndex = 5;
            this.xZoom.Text = "1";
            // 
            // yZoom
            // 
            this.yZoom.Location = new System.Drawing.Point(278, 146);
            this.yZoom.Name = "yZoom";
            this.yZoom.Size = new System.Drawing.Size(54, 21);
            this.yZoom.TabIndex = 6;
            this.yZoom.Text = "1";
            // 
            // zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 265);
            this.ControlBox = false;
            this.Controls.Add(this.yZoom);
            this.Controls.Add(this.xZoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.startZoom);
            this.Name = "zoom";
            this.Text = "图像缩放";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startZoom;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton bilinear;
        private System.Windows.Forms.RadioButton nearestNeigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xZoom;
        private System.Windows.Forms.TextBox yZoom;
    }
}