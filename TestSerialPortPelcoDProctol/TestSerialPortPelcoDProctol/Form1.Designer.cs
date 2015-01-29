namespace TestSerialPortPelcoDProctol
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
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnOpenCOM = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.hScrBarSendOrder = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(32, 22);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(299, 270);
            this.txtMsg.TabIndex = 0;
            // 
            // btnOpenCOM
            // 
            this.btnOpenCOM.Location = new System.Drawing.Point(48, 313);
            this.btnOpenCOM.Name = "btnOpenCOM";
            this.btnOpenCOM.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCOM.TabIndex = 1;
            this.btnOpenCOM.Text = "连接串口";
            this.btnOpenCOM.UseVisualStyleBackColor = true;
            this.btnOpenCOM.Click += new System.EventHandler(this.btnOpenCOM_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Location = new System.Drawing.Point(48, 362);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(75, 24);
            this.btnSendOrder.TabIndex = 2;
            this.btnSendOrder.Text = "发送指令";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            // 
            // hScrBarSendOrder
            // 
            this.hScrBarSendOrder.Location = new System.Drawing.Point(163, 318);
            this.hScrBarSendOrder.Name = "hScrBarSendOrder";
            this.hScrBarSendOrder.Size = new System.Drawing.Size(152, 17);
            this.hScrBarSendOrder.TabIndex = 3;
            this.hScrBarSendOrder.ValueChanged += new System.EventHandler(this.hScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 411);
            this.Controls.Add(this.hScrBarSendOrder);
            this.Controls.Add(this.btnSendOrder);
            this.Controls.Add(this.btnOpenCOM);
            this.Controls.Add(this.txtMsg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnOpenCOM;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.HScrollBar hScrBarSendOrder;
    }
}

