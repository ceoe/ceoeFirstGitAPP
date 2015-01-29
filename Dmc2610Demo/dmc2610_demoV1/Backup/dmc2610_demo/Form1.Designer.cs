namespace Demo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Text_Dist = new System.Windows.Forms.TextBox();
            this.Text_Tacc = new System.Windows.Forms.TextBox();
            this.Text_RUNSPD = new System.Windows.Forms.TextBox();
            this.Text_STRSPD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OptionMoveAxis4 = new System.Windows.Forms.RadioButton();
            this.OptionMoveAxis3 = new System.Windows.Forms.RadioButton();
            this.OptionMoveAxis2 = new System.Windows.Forms.RadioButton();
            this.OptionMoveAxis1 = new System.Windows.Forms.RadioButton();
            this.BUTTON_MOVE = new System.Windows.Forms.Button();
            this.Button_DelStop = new System.Windows.Forms.Button();
            this.Button_EmgStop = new System.Windows.Forms.Button();
            this.Button_CLEAN = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Label_POSITION = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始速度";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Text_Dist);
            this.groupBox1.Controls.Add(this.Text_Tacc);
            this.groupBox1.Controls.Add(this.Text_RUNSPD);
            this.groupBox1.Controls.Add(this.Text_STRSPD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 143);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运动参数";
            // 
            // Text_Dist
            // 
            this.Text_Dist.Location = new System.Drawing.Point(65, 112);
            this.Text_Dist.Name = "Text_Dist";
            this.Text_Dist.Size = new System.Drawing.Size(66, 21);
            this.Text_Dist.TabIndex = 5;
            this.Text_Dist.Text = "500";
            // 
            // Text_Tacc
            // 
            this.Text_Tacc.Location = new System.Drawing.Point(65, 84);
            this.Text_Tacc.Name = "Text_Tacc";
            this.Text_Tacc.Size = new System.Drawing.Size(66, 21);
            this.Text_Tacc.TabIndex = 5;
            this.Text_Tacc.Text = "60000";
            // 
            // Text_RUNSPD
            // 
            this.Text_RUNSPD.Location = new System.Drawing.Point(65, 55);
            this.Text_RUNSPD.Name = "Text_RUNSPD";
            this.Text_RUNSPD.Size = new System.Drawing.Size(66, 21);
            this.Text_RUNSPD.TabIndex = 5;
            this.Text_RUNSPD.Text = "1000";
            // 
            // Text_STRSPD
            // 
            this.Text_STRSPD.Location = new System.Drawing.Point(65, 25);
            this.Text_STRSPD.Name = "Text_STRSPD";
            this.Text_STRSPD.Size = new System.Drawing.Size(66, 21);
            this.Text_STRSPD.TabIndex = 4;
            this.Text_STRSPD.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "运行距离";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "加速度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "运行速度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OptionMoveAxis4);
            this.groupBox2.Controls.Add(this.OptionMoveAxis3);
            this.groupBox2.Controls.Add(this.OptionMoveAxis2);
            this.groupBox2.Controls.Add(this.OptionMoveAxis1);
            this.groupBox2.Location = new System.Drawing.Point(210, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动轴";
            // 
            // OptionMoveAxis4
            // 
            this.OptionMoveAxis4.AutoSize = true;
            this.OptionMoveAxis4.Location = new System.Drawing.Point(66, 56);
            this.OptionMoveAxis4.Name = "OptionMoveAxis4";
            this.OptionMoveAxis4.Size = new System.Drawing.Size(41, 16);
            this.OptionMoveAxis4.TabIndex = 4;
            this.OptionMoveAxis4.TabStop = true;
            this.OptionMoveAxis4.Text = "U轴";
            this.OptionMoveAxis4.UseVisualStyleBackColor = true;
            this.OptionMoveAxis4.CheckedChanged += new System.EventHandler(this.OptionMoveAxis4_CheckedChanged);
            // 
            // OptionMoveAxis3
            // 
            this.OptionMoveAxis3.AutoSize = true;
            this.OptionMoveAxis3.Location = new System.Drawing.Point(6, 56);
            this.OptionMoveAxis3.Name = "OptionMoveAxis3";
            this.OptionMoveAxis3.Size = new System.Drawing.Size(41, 16);
            this.OptionMoveAxis3.TabIndex = 3;
            this.OptionMoveAxis3.TabStop = true;
            this.OptionMoveAxis3.Text = "Z轴";
            this.OptionMoveAxis3.UseVisualStyleBackColor = true;
            this.OptionMoveAxis3.CheckedChanged += new System.EventHandler(this.OptionMoveAxis3_CheckedChanged);
            // 
            // OptionMoveAxis2
            // 
            this.OptionMoveAxis2.AutoSize = true;
            this.OptionMoveAxis2.Location = new System.Drawing.Point(66, 25);
            this.OptionMoveAxis2.Name = "OptionMoveAxis2";
            this.OptionMoveAxis2.Size = new System.Drawing.Size(41, 16);
            this.OptionMoveAxis2.TabIndex = 2;
            this.OptionMoveAxis2.TabStop = true;
            this.OptionMoveAxis2.Text = "Y轴";
            this.OptionMoveAxis2.UseVisualStyleBackColor = true;
            this.OptionMoveAxis2.CheckedChanged += new System.EventHandler(this.OptionMoveAxis2_CheckedChanged);
            // 
            // OptionMoveAxis1
            // 
            this.OptionMoveAxis1.AutoSize = true;
            this.OptionMoveAxis1.Checked = true;
            this.OptionMoveAxis1.Location = new System.Drawing.Point(6, 25);
            this.OptionMoveAxis1.Name = "OptionMoveAxis1";
            this.OptionMoveAxis1.Size = new System.Drawing.Size(41, 16);
            this.OptionMoveAxis1.TabIndex = 1;
            this.OptionMoveAxis1.TabStop = true;
            this.OptionMoveAxis1.Text = "X轴";
            this.OptionMoveAxis1.UseVisualStyleBackColor = true;
            this.OptionMoveAxis1.CheckedChanged += new System.EventHandler(this.OptionMoveAxis1_CheckedChanged);
            // 
            // BUTTON_MOVE
            // 
            this.BUTTON_MOVE.Location = new System.Drawing.Point(20, 214);
            this.BUTTON_MOVE.Name = "BUTTON_MOVE";
            this.BUTTON_MOVE.Size = new System.Drawing.Size(75, 23);
            this.BUTTON_MOVE.TabIndex = 3;
            this.BUTTON_MOVE.Text = "启动";
            this.BUTTON_MOVE.UseVisualStyleBackColor = true;
            this.BUTTON_MOVE.Click += new System.EventHandler(this.BUTTON_MOVE_Click);
            // 
            // Button_DelStop
            // 
            this.Button_DelStop.Location = new System.Drawing.Point(131, 214);
            this.Button_DelStop.Name = "Button_DelStop";
            this.Button_DelStop.Size = new System.Drawing.Size(75, 23);
            this.Button_DelStop.TabIndex = 4;
            this.Button_DelStop.Text = "减速停";
            this.Button_DelStop.UseVisualStyleBackColor = true;
            this.Button_DelStop.Click += new System.EventHandler(this.Button_DelStop_Click);
            // 
            // Button_EmgStop
            // 
            this.Button_EmgStop.Location = new System.Drawing.Point(245, 214);
            this.Button_EmgStop.Name = "Button_EmgStop";
            this.Button_EmgStop.Size = new System.Drawing.Size(75, 23);
            this.Button_EmgStop.TabIndex = 5;
            this.Button_EmgStop.Text = "急停";
            this.Button_EmgStop.UseVisualStyleBackColor = true;
            this.Button_EmgStop.Click += new System.EventHandler(this.Button_EmgStop_Click);
            // 
            // Button_CLEAN
            // 
            this.Button_CLEAN.Location = new System.Drawing.Point(20, 258);
            this.Button_CLEAN.Name = "Button_CLEAN";
            this.Button_CLEAN.Size = new System.Drawing.Size(75, 23);
            this.Button_CLEAN.TabIndex = 6;
            this.Button_CLEAN.Text = "位置清零";
            this.Button_CLEAN.UseVisualStyleBackColor = true;
            this.Button_CLEAN.Click += new System.EventHandler(this.Button_CLEAN_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(131, 258);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 23);
            this.Button_Close.TabIndex = 7;
            this.Button_Close.Text = "退出";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Label_POSITION
            // 
            this.Label_POSITION.AutoSize = true;
            this.Label_POSITION.Location = new System.Drawing.Point(18, 310);
            this.Label_POSITION.Name = "Label_POSITION";
            this.Label_POSITION.Size = new System.Drawing.Size(41, 12);
            this.Label_POSITION.TabIndex = 8;
            this.Label_POSITION.Text = "label5";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 340);
            this.Controls.Add(this.Label_POSITION);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_CLEAN);
            this.Controls.Add(this.Button_EmgStop);
            this.Controls.Add(this.Button_DelStop);
            this.Controls.Add(this.BUTTON_MOVE);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "控制卡功能演示";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Text_Dist;
        private System.Windows.Forms.TextBox Text_Tacc;
        private System.Windows.Forms.TextBox Text_RUNSPD;
        private System.Windows.Forms.TextBox Text_STRSPD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton OptionMoveAxis4;
        private System.Windows.Forms.RadioButton OptionMoveAxis3;
        private System.Windows.Forms.RadioButton OptionMoveAxis2;
        private System.Windows.Forms.RadioButton OptionMoveAxis1;
        private System.Windows.Forms.Button BUTTON_MOVE;
        private System.Windows.Forms.Button Button_DelStop;
        private System.Windows.Forms.Button Button_EmgStop;
        private System.Windows.Forms.Button Button_CLEAN;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Label Label_POSITION;
        private System.Windows.Forms.Timer timer1;
    }
}

