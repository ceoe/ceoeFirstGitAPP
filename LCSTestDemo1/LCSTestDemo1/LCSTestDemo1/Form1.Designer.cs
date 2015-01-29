namespace LCSTestDemo1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbString1 = new System.Windows.Forms.TextBox();
            this.tbString2 = new System.Windows.Forms.TextBox();
            this.tbSubString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Char String  1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Char String  2:";
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(24, 125);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(75, 48);
            this.btnStartSearch.TabIndex = 2;
            this.btnStartSearch.Text = "Search Maxim Substring";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "This Maxim Substring is :";
            // 
            // tbString1
            // 
            this.tbString1.Location = new System.Drawing.Point(123, 28);
            this.tbString1.Name = "tbString1";
            this.tbString1.Size = new System.Drawing.Size(492, 21);
            this.tbString1.TabIndex = 4;
            // 
            // tbString2
            // 
            this.tbString2.Location = new System.Drawing.Point(123, 73);
            this.tbString2.Name = "tbString2";
            this.tbString2.Size = new System.Drawing.Size(492, 21);
            this.tbString2.TabIndex = 5;
            // 
            // tbSubString
            // 
            this.tbSubString.Location = new System.Drawing.Point(123, 152);
            this.tbSubString.Name = "tbSubString";
            this.tbSubString.ReadOnly = true;
            this.tbSubString.ShortcutsEnabled = false;
            this.tbSubString.Size = new System.Drawing.Size(492, 21);
            this.tbSubString.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 211);
            this.Controls.Add(this.tbSubString);
            this.Controls.Add(this.tbString2);
            this.Controls.Add(this.tbString1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbString1;
        private System.Windows.Forms.TextBox tbString2;
        private System.Windows.Forms.TextBox tbSubString;
    }
}

