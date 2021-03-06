﻿namespace gray
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
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.pixel = new System.Windows.Forms.Button();
            this.memory = new System.Windows.Forms.Button();
            this.pointer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.curFacTrBar = new System.Windows.Forms.TrackBar();
            this.handleBmpTrbar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.curFacTrBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.handleBmpTrbar)).BeginInit();
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
            // save
            // 
            this.save.Location = new System.Drawing.Point(37, 92);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "保存图像";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(37, 138);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "关闭";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // pixel
            // 
            this.pixel.Location = new System.Drawing.Point(37, 200);
            this.pixel.Name = "pixel";
            this.pixel.Size = new System.Drawing.Size(75, 23);
            this.pixel.TabIndex = 3;
            this.pixel.Text = "提取像素法";
            this.pixel.UseVisualStyleBackColor = true;
            this.pixel.Click += new System.EventHandler(this.pixel_Click);
            // 
            // memory
            // 
            this.memory.Location = new System.Drawing.Point(37, 246);
            this.memory.Name = "memory";
            this.memory.Size = new System.Drawing.Size(75, 23);
            this.memory.TabIndex = 4;
            this.memory.Text = "内存法";
            this.memory.UseVisualStyleBackColor = true;
            this.memory.Click += new System.EventHandler(this.memory_Click);
            // 
            // pointer
            // 
            this.pointer.Location = new System.Drawing.Point(37, 292);
            this.pointer.Name = "pointer";
            this.pointer.Size = new System.Drawing.Size(75, 23);
            this.pointer.TabIndex = 5;
            this.pointer.Text = "指针法";
            this.pointer.UseVisualStyleBackColor = true;
            this.pointer.Click += new System.EventHandler(this.pointer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "运行时间：";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(37, 375);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(75, 21);
            this.timeBox.TabIndex = 7;
            this.timeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // curFacTrBar
            // 
            this.curFacTrBar.Location = new System.Drawing.Point(184, 12);
            this.curFacTrBar.Minimum = 1;
            this.curFacTrBar.Name = "curFacTrBar";
            this.curFacTrBar.Size = new System.Drawing.Size(101, 45);
            this.curFacTrBar.TabIndex = 8;
            this.curFacTrBar.Value = 1;
            this.curFacTrBar.ValueChanged += new System.EventHandler(this.curFacTrBar_ValueChanged);
            // 
            // handleBmpTrbar
            // 
            this.handleBmpTrbar.Location = new System.Drawing.Point(334, 12);
            this.handleBmpTrbar.Minimum = 1;
            this.handleBmpTrbar.Name = "handleBmpTrbar";
            this.handleBmpTrbar.Size = new System.Drawing.Size(101, 45);
            this.handleBmpTrbar.TabIndex = 9;
            this.handleBmpTrbar.Value = 1;
            this.handleBmpTrbar.ValueChanged += new System.EventHandler(this.curFacTrBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 565);
            this.Controls.Add(this.handleBmpTrbar);
            this.Controls.Add(this.curFacTrBar);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pointer);
            this.Controls.Add(this.memory);
            this.Controls.Add(this.pixel);
            this.Controls.Add(this.close);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.curFacTrBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.handleBmpTrbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button close;

        private string curFileName;
        private System.Drawing.Bitmap curBitmap;
        private System.Drawing.Bitmap BitmapByHandle;
        private System.Windows.Forms.Button pixel;
        private System.Windows.Forms.Button memory;
        private System.Windows.Forms.Button pointer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeBox;

        private HiPerfTimer myTimer;
        private System.Windows.Forms.TrackBar curFacTrBar;
        private System.Windows.Forms.TrackBar handleBmpTrbar;
    }
}

