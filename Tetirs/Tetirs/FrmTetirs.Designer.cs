namespace Tetirs
{
    partial class FrmTetirs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.lblReady = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnCallCfg = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRotCW = new System.Windows.Forms.Button();
            this.btnRotCCW = new System.Windows.Forms.Button();
            this.btnCheckOver = new System.Windows.Forms.Button();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRunBlockList = new System.Windows.Forms.TextBox();
            this.txtRunReadyBlock = new System.Windows.Forms.TextBox();
            this.txtRunBlockStyle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.SystemColors.ControlText;
            this.pbRun.Location = new System.Drawing.Point(-1, 9);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(351, 375);
            this.pbRun.TabIndex = 0;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRun_Paint);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblReady.Location = new System.Drawing.Point(26, 9);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(125, 125);
            this.lblReady.TabIndex = 1;
            this.lblReady.Paint += new System.Windows.Forms.PaintEventHandler(this.lblReady_Paint);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(49, 149);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(49, 207);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnCallCfg
            // 
            this.btnCallCfg.Location = new System.Drawing.Point(49, 361);
            this.btnCallCfg.Name = "btnCallCfg";
            this.btnCallCfg.Size = new System.Drawing.Size(75, 23);
            this.btnCallCfg.TabIndex = 4;
            this.btnCallCfg.Text = "配置游戏";
            this.btnCallCfg.UseVisualStyleBackColor = true;
            this.btnCallCfg.Click += new System.EventHandler(this.btnCallCfg_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(3, 178);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 6;
            this.btnLeft.Text = "向左";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(85, 178);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = "向右";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRotCW
            // 
            this.btnRotCW.Location = new System.Drawing.Point(0, 266);
            this.btnRotCW.Name = "btnRotCW";
            this.btnRotCW.Size = new System.Drawing.Size(75, 23);
            this.btnRotCW.TabIndex = 8;
            this.btnRotCW.Text = "顺时针旋转";
            this.btnRotCW.UseVisualStyleBackColor = true;
            this.btnRotCW.Click += new System.EventHandler(this.btnRotCW_Click);
            // 
            // btnRotCCW
            // 
            this.btnRotCCW.Location = new System.Drawing.Point(94, 266);
            this.btnRotCCW.Name = "btnRotCCW";
            this.btnRotCCW.Size = new System.Drawing.Size(75, 23);
            this.btnRotCCW.TabIndex = 9;
            this.btnRotCCW.Text = "逆时针旋转";
            this.btnRotCCW.UseVisualStyleBackColor = true;
            this.btnRotCCW.Click += new System.EventHandler(this.btnRotCCW_Click);
            // 
            // btnCheckOver
            // 
            this.btnCheckOver.Location = new System.Drawing.Point(3, 316);
            this.btnCheckOver.Name = "btnCheckOver";
            this.btnCheckOver.Size = new System.Drawing.Size(85, 23);
            this.btnCheckOver.TabIndex = 10;
            this.btnCheckOver.Text = "检查砖块结束";
            this.btnCheckOver.UseVisualStyleBackColor = true;
            this.btnCheckOver.Click += new System.EventHandler(this.btnCheckOver_Click);
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(49, 237);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(75, 23);
            this.btnDrop.TabIndex = 11;
            this.btnDrop.Text = "Drop";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(94, 316);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnDrop);
            this.panel1.Controls.Add(this.btnCheckOver);
            this.panel1.Controls.Add(this.btnRotCCW);
            this.panel1.Controls.Add(this.btnRotCW);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.txtRunBlockList);
            this.panel1.Controls.Add(this.btnCallCfg);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(362, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 613);
            this.panel1.TabIndex = 2;
            // 
            // txtRunBlockList
            // 
            this.txtRunBlockList.Enabled = false;
            this.txtRunBlockList.Location = new System.Drawing.Point(16, 408);
            this.txtRunBlockList.Multiline = true;
            this.txtRunBlockList.Name = "txtRunBlockList";
            this.txtRunBlockList.Size = new System.Drawing.Size(144, 178);
            this.txtRunBlockList.TabIndex = 5;
            this.txtRunBlockList.Visible = false;
            // 
            // txtRunReadyBlock
            // 
            this.txtRunReadyBlock.Enabled = false;
            this.txtRunReadyBlock.Location = new System.Drawing.Point(12, 394);
            this.txtRunReadyBlock.Multiline = true;
            this.txtRunReadyBlock.Name = "txtRunReadyBlock";
            this.txtRunReadyBlock.Size = new System.Drawing.Size(318, 36);
            this.txtRunReadyBlock.TabIndex = 3;
            this.txtRunReadyBlock.Visible = false;
            // 
            // txtRunBlockStyle
            // 
            this.txtRunBlockStyle.Enabled = false;
            this.txtRunBlockStyle.Location = new System.Drawing.Point(13, 436);
            this.txtRunBlockStyle.Multiline = true;
            this.txtRunBlockStyle.Name = "txtRunBlockStyle";
            this.txtRunBlockStyle.Size = new System.Drawing.Size(318, 165);
            this.txtRunBlockStyle.TabIndex = 4;
            this.txtRunBlockStyle.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(0, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 90);
            this.label1.TabIndex = 13;
            this.label1.Text = "Code by         Bob Lee";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTetirs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 613);
            this.Controls.Add(this.txtRunBlockStyle);
            this.Controls.Add(this.txtRunReadyBlock);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.KeyPreview = true;
            this.Name = "FrmTetirs";
            this.Text = "俄罗斯方块 V1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTetirs_FormClosed);
            this.Load += new System.EventHandler(this.FrmTetirs_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTetirs_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnCallCfg;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnRotCW;
        private System.Windows.Forms.Button btnRotCCW;
        private System.Windows.Forms.Button btnCheckOver;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRunBlockList;
        private System.Windows.Forms.TextBox txtRunReadyBlock;
        private System.Windows.Forms.TextBox txtRunBlockStyle;
        private System.Windows.Forms.Label label1;
    }
}