namespace RadioButtomTestDemo1
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
            this.gbAppearance = new System.Windows.Forms.GroupBox();
            this.gbChooseValue = new System.Windows.Forms.GroupBox();
            this.lbIndex = new System.Windows.Forms.Label();
            this.lbTextValue = new System.Windows.Forms.Label();
            this.rdoFlat = new System.Windows.Forms.RadioButton();
            this.rdoPopup = new System.Windows.Forms.RadioButton();
            this.rdoStandard = new System.Windows.Forms.RadioButton();
            this.rdoSystem = new System.Windows.Forms.RadioButton();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbAppearance.SuspendLayout();
            this.gbChooseValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAppearance
            // 
            this.gbAppearance.Controls.Add(this.rdoSystem);
            this.gbAppearance.Controls.Add(this.rdoStandard);
            this.gbAppearance.Controls.Add(this.rdoPopup);
            this.gbAppearance.Controls.Add(this.rdoFlat);
            this.gbAppearance.Location = new System.Drawing.Point(13, 12);
            this.gbAppearance.Name = "gbAppearance";
            this.gbAppearance.Size = new System.Drawing.Size(200, 100);
            this.gbAppearance.TabIndex = 0;
            this.gbAppearance.TabStop = false;
            this.gbAppearance.Text = "样式控制";
            // 
            // gbChooseValue
            // 
            this.gbChooseValue.Controls.Add(this.rdoC);
            this.gbChooseValue.Controls.Add(this.rdoB);
            this.gbChooseValue.Controls.Add(this.rdoA);
            this.gbChooseValue.Controls.Add(this.lbTextValue);
            this.gbChooseValue.Controls.Add(this.lbIndex);
            this.gbChooseValue.Location = new System.Drawing.Point(13, 128);
            this.gbChooseValue.Name = "gbChooseValue";
            this.gbChooseValue.Size = new System.Drawing.Size(200, 121);
            this.gbChooseValue.TabIndex = 1;
            this.gbChooseValue.TabStop = false;
            this.gbChooseValue.Text = "选项组的值";
            // 
            // lbIndex
            // 
            this.lbIndex.AutoSize = true;
            this.lbIndex.Location = new System.Drawing.Point(7, 68);
            this.lbIndex.Name = "lbIndex";
            this.lbIndex.Size = new System.Drawing.Size(95, 12);
            this.lbIndex.TabIndex = 0;
            this.lbIndex.Text = "你选中了第  项.";
            // 
            // lbTextValue
            // 
            this.lbTextValue.AutoSize = true;
            this.lbTextValue.Location = new System.Drawing.Point(7, 97);
            this.lbTextValue.Name = "lbTextValue";
            this.lbTextValue.Size = new System.Drawing.Size(47, 12);
            this.lbTextValue.TabIndex = 1;
            this.lbTextValue.Text = "名称是:";
            // 
            // rdoFlat
            // 
            this.rdoFlat.AutoSize = true;
            this.rdoFlat.Location = new System.Drawing.Point(7, 22);
            this.rdoFlat.Name = "rdoFlat";
            this.rdoFlat.Size = new System.Drawing.Size(53, 16);
            this.rdoFlat.TabIndex = 0;
            this.rdoFlat.TabStop = true;
            this.rdoFlat.Text = "Float";
            this.rdoFlat.UseVisualStyleBackColor = true;
            this.rdoFlat.Click += new System.EventHandler(this.rdoFlat_Click);
            // 
            // rdoPopup
            // 
            this.rdoPopup.AutoSize = true;
            this.rdoPopup.Location = new System.Drawing.Point(99, 22);
            this.rdoPopup.Name = "rdoPopup";
            this.rdoPopup.Size = new System.Drawing.Size(53, 16);
            this.rdoPopup.TabIndex = 1;
            this.rdoPopup.TabStop = true;
            this.rdoPopup.Text = "Popup";
            this.rdoPopup.UseVisualStyleBackColor = true;
            this.rdoPopup.Click += new System.EventHandler(this.rdoPopup_Click);
            // 
            // rdoStandard
            // 
            this.rdoStandard.AutoSize = true;
            this.rdoStandard.Checked = true;
            this.rdoStandard.Location = new System.Drawing.Point(6, 57);
            this.rdoStandard.Name = "rdoStandard";
            this.rdoStandard.Size = new System.Drawing.Size(77, 16);
            this.rdoStandard.TabIndex = 2;
            this.rdoStandard.TabStop = true;
            this.rdoStandard.Text = "Strandard";
            this.rdoStandard.UseVisualStyleBackColor = true;
            this.rdoStandard.Click += new System.EventHandler(this.rdoStandard_Click);
            // 
            // rdoSystem
            // 
            this.rdoSystem.AutoSize = true;
            this.rdoSystem.Location = new System.Drawing.Point(99, 57);
            this.rdoSystem.Name = "rdoSystem";
            this.rdoSystem.Size = new System.Drawing.Size(59, 16);
            this.rdoSystem.TabIndex = 3;
            this.rdoSystem.TabStop = true;
            this.rdoSystem.Text = "System";
            this.rdoSystem.UseVisualStyleBackColor = true;
            this.rdoSystem.Click += new System.EventHandler(this.rdoStandard_Click);
            // 
            // rdoA
            // 
            this.rdoA.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoA.AutoSize = true;
            this.rdoA.Location = new System.Drawing.Point(62, 30);
            this.rdoA.Name = "rdoA";
            this.rdoA.Size = new System.Drawing.Size(21, 22);
            this.rdoA.TabIndex = 2;
            this.rdoA.TabStop = true;
            this.rdoA.Tag = "1";
            this.rdoA.Text = "A";
            this.rdoA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoA.UseVisualStyleBackColor = true;
            this.rdoA.Click += new System.EventHandler(this.rdoB_Click);
            // 
            // rdoB
            // 
            this.rdoB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoB.AutoSize = true;
            this.rdoB.Location = new System.Drawing.Point(89, 30);
            this.rdoB.Name = "rdoB";
            this.rdoB.Size = new System.Drawing.Size(21, 22);
            this.rdoB.TabIndex = 3;
            this.rdoB.TabStop = true;
            this.rdoB.Tag = "2";
            this.rdoB.Text = "B";
            this.rdoB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoB.UseVisualStyleBackColor = true;
            this.rdoB.Click += new System.EventHandler(this.rdoB_Click);
            // 
            // rdoC
            // 
            this.rdoC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoC.AutoSize = true;
            this.rdoC.Location = new System.Drawing.Point(116, 30);
            this.rdoC.Name = "rdoC";
            this.rdoC.Size = new System.Drawing.Size(21, 22);
            this.rdoC.TabIndex = 4;
            this.rdoC.TabStop = true;
            this.rdoC.Tag = "3";
            this.rdoC.Text = "C";
            this.rdoC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoC.UseVisualStyleBackColor = true;
            this.rdoC.Click += new System.EventHandler(this.rdoB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(206, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 273);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbChooseValue);
            this.Controls.Add(this.gbAppearance);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbAppearance.ResumeLayout(false);
            this.gbAppearance.PerformLayout();
            this.gbChooseValue.ResumeLayout(false);
            this.gbChooseValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAppearance;
        private System.Windows.Forms.GroupBox gbChooseValue;
        private System.Windows.Forms.RadioButton rdoSystem;
        private System.Windows.Forms.RadioButton rdoStandard;
        private System.Windows.Forms.RadioButton rdoPopup;
        private System.Windows.Forms.RadioButton rdoFlat;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.Label lbTextValue;
        private System.Windows.Forms.Label lbIndex;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

