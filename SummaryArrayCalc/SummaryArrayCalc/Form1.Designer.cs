namespace SummaryArrayCalc
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
            this.tbNumofArray = new System.Windows.Forms.TextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnSummary1 = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数组生成规模";
            // 
            // tbNumofArray
            // 
            this.tbNumofArray.Location = new System.Drawing.Point(15, 57);
            this.tbNumofArray.Name = "tbNumofArray";
            this.tbNumofArray.Size = new System.Drawing.Size(157, 21);
            this.tbNumofArray.TabIndex = 1;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(188, 55);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 2;
            this.btnGen.Text = "生成数组";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnSummary1
            // 
            this.btnSummary1.Location = new System.Drawing.Point(188, 102);
            this.btnSummary1.Name = "btnSummary1";
            this.btnSummary1.Size = new System.Drawing.Size(75, 23);
            this.btnSummary1.TabIndex = 3;
            this.btnSummary1.Text = "求和1";
            this.btnSummary1.UseVisualStyleBackColor = true;
            this.btnSummary1.Click += new System.EventHandler(this.btnSummary1_Click);
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(18, 118);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(153, 331);
            this.tbResult.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnSummary1);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.tbNumofArray);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Summary of Array";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumofArray;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnSummary1;
        private System.Windows.Forms.TextBox tbResult;
    }
}

