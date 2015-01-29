namespace BitwiseDemo1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkBlod = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkUnderLine = new System.Windows.Forms.CheckBox();
            this.chkStrikeOut = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(13, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 200);
            this.textBox1.TabIndex = 0;
            // 
            // chkBlod
            // 
            this.chkBlod.AutoSize = true;
            this.chkBlod.Location = new System.Drawing.Point(13, 246);
            this.chkBlod.Name = "chkBlod";
            this.chkBlod.Size = new System.Drawing.Size(48, 16);
            this.chkBlod.TabIndex = 1;
            this.chkBlod.Text = "Blod";
            this.chkBlod.UseVisualStyleBackColor = true;
            this.chkBlod.Click += new System.EventHandler(this.chk_Click);
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Location = new System.Drawing.Point(131, 246);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(60, 16);
            this.chkItalic.TabIndex = 2;
            this.chkItalic.Text = "Italic";
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.Click += new System.EventHandler(this.chk_Click);
            // 
            // chkUnderLine
            // 
            this.chkUnderLine.AutoSize = true;
            this.chkUnderLine.Location = new System.Drawing.Point(13, 271);
            this.chkUnderLine.Name = "chkUnderLine";
            this.chkUnderLine.Size = new System.Drawing.Size(78, 16);
            this.chkUnderLine.TabIndex = 3;
            this.chkUnderLine.Text = "UnderLine";
            this.chkUnderLine.UseVisualStyleBackColor = true;
            this.chkUnderLine.Click += new System.EventHandler(this.chk_Click);
            // 
            // chkStrikeOut
            // 
            this.chkStrikeOut.AutoSize = true;
            this.chkStrikeOut.Location = new System.Drawing.Point(131, 271);
            this.chkStrikeOut.Name = "chkStrikeOut";
            this.chkStrikeOut.Size = new System.Drawing.Size(78, 16);
            this.chkStrikeOut.TabIndex = 4;
            this.chkStrikeOut.Text = "StrikeOut";
            this.chkStrikeOut.UseVisualStyleBackColor = true;
            this.chkStrikeOut.Click += new System.EventHandler(this.chk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 299);
            this.Controls.Add(this.chkStrikeOut);
            this.Controls.Add(this.chkUnderLine);
            this.Controls.Add(this.chkItalic);
            this.Controls.Add(this.chkBlod);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkBlod;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkUnderLine;
        private System.Windows.Forms.CheckBox chkStrikeOut;
    }
}

