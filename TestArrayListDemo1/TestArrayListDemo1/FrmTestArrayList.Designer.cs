namespace TestArrayListDemo1
{
    partial class FrmTestArryList
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
            this.btnTestArray = new System.Windows.Forms.Button();
            this.TestArrayList = new System.Windows.Forms.Button();
            this.txtArray = new System.Windows.Forms.TextBox();
            this.txtArrayList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTestArray
            // 
            this.btnTestArray.Location = new System.Drawing.Point(41, 29);
            this.btnTestArray.Name = "btnTestArray";
            this.btnTestArray.Size = new System.Drawing.Size(75, 23);
            this.btnTestArray.TabIndex = 0;
            this.btnTestArray.Text = "TestArray";
            this.btnTestArray.UseVisualStyleBackColor = true;
            this.btnTestArray.Click += new System.EventHandler(this.btnTestArray_Click);
            // 
            // TestArrayList
            // 
            this.TestArrayList.Location = new System.Drawing.Point(191, 28);
            this.TestArrayList.Name = "TestArrayList";
            this.TestArrayList.Size = new System.Drawing.Size(139, 23);
            this.TestArrayList.TabIndex = 1;
            this.TestArrayList.Text = "TestArrayList";
            this.TestArrayList.UseVisualStyleBackColor = true;
            this.TestArrayList.Click += new System.EventHandler(this.TestArrayList_Click);
            // 
            // txtArray
            // 
            this.txtArray.Location = new System.Drawing.Point(13, 82);
            this.txtArray.Multiline = true;
            this.txtArray.Name = "txtArray";
            this.txtArray.Size = new System.Drawing.Size(147, 194);
            this.txtArray.TabIndex = 2;
            // 
            // txtArrayList
            // 
            this.txtArrayList.Location = new System.Drawing.Point(191, 82);
            this.txtArrayList.Multiline = true;
            this.txtArrayList.Name = "txtArrayList";
            this.txtArrayList.Size = new System.Drawing.Size(147, 194);
            this.txtArrayList.TabIndex = 3;
            // 
            // FrmTestArryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 306);
            this.Controls.Add(this.txtArrayList);
            this.Controls.Add(this.txtArray);
            this.Controls.Add(this.TestArrayList);
            this.Controls.Add(this.btnTestArray);
            this.Name = "FrmTestArryList";
            this.Text = "测试ArrayList功能";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestArray;
        private System.Windows.Forms.Button TestArrayList;
        private System.Windows.Forms.TextBox txtArray;
        private System.Windows.Forms.TextBox txtArrayList;
    }
}

