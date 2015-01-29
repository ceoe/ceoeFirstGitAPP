namespace TreeSearchDemo1
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
            this.tbOrgStr = new System.Windows.Forms.TextBox();
            this.btnFirstOrder = new System.Windows.Forms.Button();
            this.btnMidOrder = new System.Windows.Forms.Button();
            this.btnAfterOrder = new System.Windows.Forms.Button();
            this.tbStrDeepSort = new System.Windows.Forms.TextBox();
            this.tbStrWideOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWideSort = new System.Windows.Forms.Button();
            this.chkNotRecursion = new System.Windows.Forms.CheckBox();
            this.tbNotCursionResult = new System.Windows.Forms.TextBox();
            this.lbNormaltime = new System.Windows.Forms.Label();
            this.lbNotCursionTime = new System.Windows.Forms.Label();
            this.btnTestOddParity = new System.Windows.Forms.Button();
            this.tbCursionList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbOrgStr
            // 
            this.tbOrgStr.Location = new System.Drawing.Point(72, 24);
            this.tbOrgStr.Name = "tbOrgStr";
            this.tbOrgStr.Size = new System.Drawing.Size(578, 21);
            this.tbOrgStr.TabIndex = 0;
            // 
            // btnFirstOrder
            // 
            this.btnFirstOrder.Location = new System.Drawing.Point(101, 103);
            this.btnFirstOrder.Name = "btnFirstOrder";
            this.btnFirstOrder.Size = new System.Drawing.Size(75, 23);
            this.btnFirstOrder.TabIndex = 1;
            this.btnFirstOrder.Text = "先序遍历";
            this.btnFirstOrder.UseVisualStyleBackColor = true;
            this.btnFirstOrder.Click += new System.EventHandler(this.btnFirstOrder_Click);
            // 
            // btnMidOrder
            // 
            this.btnMidOrder.Location = new System.Drawing.Point(205, 103);
            this.btnMidOrder.Name = "btnMidOrder";
            this.btnMidOrder.Size = new System.Drawing.Size(75, 23);
            this.btnMidOrder.TabIndex = 2;
            this.btnMidOrder.Text = "中序遍历";
            this.btnMidOrder.UseVisualStyleBackColor = true;
            this.btnMidOrder.Click += new System.EventHandler(this.btnMidOrder_Click);
            // 
            // btnAfterOrder
            // 
            this.btnAfterOrder.Location = new System.Drawing.Point(318, 103);
            this.btnAfterOrder.Name = "btnAfterOrder";
            this.btnAfterOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAfterOrder.TabIndex = 3;
            this.btnAfterOrder.Text = "后序遍历";
            this.btnAfterOrder.UseVisualStyleBackColor = true;
            this.btnAfterOrder.Click += new System.EventHandler(this.btnAfterOrder_Click);
            // 
            // tbStrDeepSort
            // 
            this.tbStrDeepSort.Location = new System.Drawing.Point(125, 140);
            this.tbStrDeepSort.Name = "tbStrDeepSort";
            this.tbStrDeepSort.Size = new System.Drawing.Size(525, 21);
            this.tbStrDeepSort.TabIndex = 4;
            // 
            // tbStrWideOrder
            // 
            this.tbStrWideOrder.Location = new System.Drawing.Point(72, 205);
            this.tbStrWideOrder.Name = "tbStrWideOrder";
            this.tbStrWideOrder.Size = new System.Drawing.Size(578, 21);
            this.tbStrWideOrder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "字串";
            // 
            // btnWideSort
            // 
            this.btnWideSort.Location = new System.Drawing.Point(413, 103);
            this.btnWideSort.Name = "btnWideSort";
            this.btnWideSort.Size = new System.Drawing.Size(89, 23);
            this.btnWideSort.TabIndex = 7;
            this.btnWideSort.Text = "广度优先遍历";
            this.btnWideSort.UseVisualStyleBackColor = true;
            this.btnWideSort.Click += new System.EventHandler(this.btnWideSort_Click);
            // 
            // chkNotRecursion
            // 
            this.chkNotRecursion.AutoSize = true;
            this.chkNotRecursion.Checked = true;
            this.chkNotRecursion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotRecursion.Location = new System.Drawing.Point(2, 107);
            this.chkNotRecursion.Name = "chkNotRecursion";
            this.chkNotRecursion.Size = new System.Drawing.Size(84, 16);
            this.chkNotRecursion.TabIndex = 8;
            this.chkNotRecursion.Text = "非递归方法";
            this.chkNotRecursion.UseVisualStyleBackColor = true;
            // 
            // tbNotCursionResult
            // 
            this.tbNotCursionResult.Location = new System.Drawing.Point(125, 167);
            this.tbNotCursionResult.Name = "tbNotCursionResult";
            this.tbNotCursionResult.Size = new System.Drawing.Size(525, 21);
            this.tbNotCursionResult.TabIndex = 9;
            // 
            // lbNormaltime
            // 
            this.lbNormaltime.AutoSize = true;
            this.lbNormaltime.Location = new System.Drawing.Point(13, 140);
            this.lbNormaltime.Name = "lbNormaltime";
            this.lbNormaltime.Size = new System.Drawing.Size(0, 12);
            this.lbNormaltime.TabIndex = 10;
            // 
            // lbNotCursionTime
            // 
            this.lbNotCursionTime.AutoSize = true;
            this.lbNotCursionTime.Location = new System.Drawing.Point(13, 167);
            this.lbNotCursionTime.Name = "lbNotCursionTime";
            this.lbNotCursionTime.Size = new System.Drawing.Size(0, 12);
            this.lbNotCursionTime.TabIndex = 11;
            // 
            // btnTestOddParity
            // 
            this.btnTestOddParity.Location = new System.Drawing.Point(525, 103);
            this.btnTestOddParity.Name = "btnTestOddParity";
            this.btnTestOddParity.Size = new System.Drawing.Size(75, 23);
            this.btnTestOddParity.TabIndex = 12;
            this.btnTestOddParity.Text = "测试奇偶数";
            this.btnTestOddParity.UseVisualStyleBackColor = true;
            this.btnTestOddParity.Click += new System.EventHandler(this.btnTestOddParity_Click);
            // 
            // tbCursionList
            // 
            this.tbCursionList.Location = new System.Drawing.Point(72, 61);
            this.tbCursionList.Name = "tbCursionList";
            this.tbCursionList.Size = new System.Drawing.Size(578, 21);
            this.tbCursionList.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 323);
            this.Controls.Add(this.tbCursionList);
            this.Controls.Add(this.btnTestOddParity);
            this.Controls.Add(this.lbNotCursionTime);
            this.Controls.Add(this.lbNormaltime);
            this.Controls.Add(this.tbNotCursionResult);
            this.Controls.Add(this.chkNotRecursion);
            this.Controls.Add(this.btnWideSort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbStrWideOrder);
            this.Controls.Add(this.tbStrDeepSort);
            this.Controls.Add(this.btnAfterOrder);
            this.Controls.Add(this.btnMidOrder);
            this.Controls.Add(this.btnFirstOrder);
            this.Controls.Add(this.tbOrgStr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOrgStr;
        private System.Windows.Forms.Button btnFirstOrder;
        private System.Windows.Forms.Button btnMidOrder;
        private System.Windows.Forms.Button btnAfterOrder;
        private System.Windows.Forms.TextBox tbStrDeepSort;
        private System.Windows.Forms.TextBox tbStrWideOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWideSort;
        private System.Windows.Forms.CheckBox chkNotRecursion;
        private System.Windows.Forms.TextBox tbNotCursionResult;
        private System.Windows.Forms.Label lbNormaltime;
        private System.Windows.Forms.Label lbNotCursionTime;
        private System.Windows.Forms.Button btnTestOddParity;
        private System.Windows.Forms.TextBox tbCursionList;
    }
}

