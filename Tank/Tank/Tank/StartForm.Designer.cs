namespace Tank
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btnState = new System.Windows.Forms.Button();
            this.btnBug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnState
            // 
            this.btnState.Enabled = false;
            this.btnState.Location = new System.Drawing.Point(54, 590);
            this.btnState.Name = "btnState";
            this.btnState.Size = new System.Drawing.Size(74, 28);
            this.btnState.TabIndex = 10;
            this.btnState.TabStop = false;
            this.btnState.Text = "游戏说明";
            this.btnState.UseVisualStyleBackColor = true;
            this.btnState.Visible = false;
            this.btnState.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBug
            // 
            this.btnBug.Enabled = false;
            this.btnBug.Location = new System.Drawing.Point(605, 590);
            this.btnBug.Name = "btnBug";
            this.btnBug.Size = new System.Drawing.Size(74, 28);
            this.btnBug.TabIndex = 10;
            this.btnBug.TabStop = false;
            this.btnBug.Text = "提交Bug";
            this.btnBug.UseVisualStyleBackColor = true;
            this.btnBug.Visible = false;
            this.btnBug.Click += new System.EventHandler(this.btnBug_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(764, 662);
            this.Controls.Add(this.btnBug);
            this.Controls.Add(this.btnState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(780, 700);
            this.MinimumSize = new System.Drawing.Size(780, 700);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StartForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StartForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnState;
        private System.Windows.Forms.Button btnBug;
    }
}