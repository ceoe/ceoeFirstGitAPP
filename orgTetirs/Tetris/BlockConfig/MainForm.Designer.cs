namespace BlockConfig
{
    partial class MainForm
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
            this.lblMatrix = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMatrix
            // 
            this.lblMatrix.BackColor = System.Drawing.Color.Black;
            this.lblMatrix.Location = new System.Drawing.Point(12, 9);
            this.lblMatrix.Name = "lblMatrix";
            this.lblMatrix.Size = new System.Drawing.Size(85, 85);
            this.lblMatrix.TabIndex = 0;
            this.lblMatrix.Paint += new System.Windows.Forms.PaintEventHandler(this.lblMatrix_Paint);
            this.lblMatrix.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMatrix_MouseClick);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMode.Location = new System.Drawing.Point(14, 118);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(16, 16);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 142);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblMatrix);
            this.Name = "MainForm";
            this.Text = "砖块配置";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMatrix;
        private System.Windows.Forms.Label lblMode;
    }
}

