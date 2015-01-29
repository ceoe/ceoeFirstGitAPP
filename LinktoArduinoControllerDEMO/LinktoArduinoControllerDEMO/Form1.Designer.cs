namespace LinktoArduinoControllerDEMO
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
            this.trb1 = new System.Windows.Forms.TrackBar();
            this.txtb1 = new System.Windows.Forms.TextBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.serPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btSend1 = new System.Windows.Forms.Button();
            this.txtb2 = new System.Windows.Forms.TextBox();
            this.btntest1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trb1)).BeginInit();
            this.SuspendLayout();
            // 
            // trb1
            // 
            this.trb1.Location = new System.Drawing.Point(12, 81);
            this.trb1.Name = "trb1";
            this.trb1.Size = new System.Drawing.Size(257, 42);
            this.trb1.TabIndex = 0;
            this.trb1.Scroll += new System.EventHandler(this.trb1_Scroll);
            // 
            // txtb1
            // 
            this.txtb1.Location = new System.Drawing.Point(150, 129);
            this.txtb1.Name = "txtb1";
            this.txtb1.Size = new System.Drawing.Size(100, 21);
            this.txtb1.TabIndex = 1;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(92, 132);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(41, 12);
            this.lb1.TabIndex = 2;
            this.lb1.Text = "设定值";
            // 
            // serPort1
            // 
            this.serPort1.BaudRate = 115200;
            this.serPort1.PortName = "COM18";
            // 
            // btSend1
            // 
            this.btSend1.Location = new System.Drawing.Point(150, 35);
            this.btSend1.Name = "btSend1";
            this.btSend1.Size = new System.Drawing.Size(100, 23);
            this.btSend1.TabIndex = 3;
            this.btSend1.Text = "button1";
            this.btSend1.UseVisualStyleBackColor = true;
            this.btSend1.Click += new System.EventHandler(this.btSend1_Click);
            // 
            // txtb2
            // 
            this.txtb2.AllowDrop = true;
            this.txtb2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtb2.Location = new System.Drawing.Point(27, 189);
            this.txtb2.Multiline = true;
            this.txtb2.Name = "txtb2";
            this.txtb2.Size = new System.Drawing.Size(223, 72);
            this.txtb2.TabIndex = 4;
            // 
            // btntest1
            // 
            this.btntest1.Location = new System.Drawing.Point(27, 35);
            this.btntest1.Name = "btntest1";
            this.btntest1.Size = new System.Drawing.Size(95, 23);
            this.btntest1.TabIndex = 5;
            this.btntest1.Text = "测试一下！";
            this.btntest1.UseVisualStyleBackColor = true;
            this.btntest1.Click += new System.EventHandler(this.btntest1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btntest1);
            this.Controls.Add(this.txtb2);
            this.Controls.Add(this.btSend1);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.txtb1);
            this.Controls.Add(this.trb1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trb1;
        private System.Windows.Forms.TextBox txtb1;
        private System.Windows.Forms.Label lb1;
        private System.IO.Ports.SerialPort serPort1;
        private System.Windows.Forms.Button btSend1;
        private System.Windows.Forms.TextBox txtb2;
        private System.Windows.Forms.Button btntest1;
    }
}

