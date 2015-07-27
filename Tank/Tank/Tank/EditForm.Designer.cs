namespace Tank
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.btnFinish = new System.Windows.Forms.Button();
            this.radbtnGrass = new System.Windows.Forms.RadioButton();
            this.radbtnWall = new System.Windows.Forms.RadioButton();
            this.radbtnWater = new System.Windows.Forms.RadioButton();
            this.radbtnSteel = new System.Windows.Forms.RadioButton();
            this.panelMap = new Tank.GamePanel();
            this.btnClosed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(678, 561);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(73, 29);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // radbtnGrass
            // 
            this.radbtnGrass.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.radbtnGrass.Image = ((System.Drawing.Image)(resources.GetObject("radbtnGrass.Image")));
            this.radbtnGrass.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radbtnGrass.Location = new System.Drawing.Point(669, 97);
            this.radbtnGrass.Name = "radbtnGrass";
            this.radbtnGrass.Size = new System.Drawing.Size(90, 80);
            this.radbtnGrass.TabIndex = 4;
            this.radbtnGrass.Text = "10*10";
            this.radbtnGrass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnGrass.UseVisualStyleBackColor = true;
            // 
            // radbtnWall
            // 
            this.radbtnWall.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radbtnWall.Image = global::Tank.Properties.Resources.walls;
            this.radbtnWall.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radbtnWall.Location = new System.Drawing.Point(669, 12);
            this.radbtnWall.Name = "radbtnWall";
            this.radbtnWall.Size = new System.Drawing.Size(90, 80);
            this.radbtnWall.TabIndex = 3;
            this.radbtnWall.Text = "43*43";
            this.radbtnWall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnWall.UseVisualStyleBackColor = true;
            // 
            // radbtnWater
            // 
            this.radbtnWater.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.radbtnWater.Image = global::Tank.Properties.Resources.water;
            this.radbtnWater.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radbtnWater.Location = new System.Drawing.Point(669, 182);
            this.radbtnWater.Name = "radbtnWater";
            this.radbtnWater.Size = new System.Drawing.Size(90, 80);
            this.radbtnWater.TabIndex = 5;
            this.radbtnWater.Text = "10*10";
            this.radbtnWater.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnWater.UseVisualStyleBackColor = true;
            // 
            // radbtnSteel
            // 
            this.radbtnSteel.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold);
            this.radbtnSteel.Image = global::Tank.Properties.Resources.steels;
            this.radbtnSteel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radbtnSteel.Location = new System.Drawing.Point(669, 267);
            this.radbtnSteel.Name = "radbtnSteel";
            this.radbtnSteel.Size = new System.Drawing.Size(90, 80);
            this.radbtnSteel.TabIndex = 6;
            this.radbtnSteel.Text = "21*21";
            this.radbtnSteel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnSteel.UseVisualStyleBackColor = true;
            // 
            // panelMap
            // 
            this.panelMap.BackColor = System.Drawing.Color.Black;
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMap.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelMap.Location = new System.Drawing.Point(2, 1);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(660, 660);
            this.panelMap.TabIndex = 0;
            this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMap_Paint);
            this.panelMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseClick);
            this.panelMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseMove);
            // 
            // btnClosed
            // 
            this.btnClosed.Location = new System.Drawing.Point(679, 612);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(73, 29);
            this.btnClosed.TabIndex = 2;
            this.btnClosed.Text = "关闭";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 662);
            this.Controls.Add(this.radbtnSteel);
            this.Controls.Add(this.radbtnWater);
            this.Controls.Add(this.radbtnGrass);
            this.Controls.Add(this.radbtnWall);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.panelMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(780, 700);
            this.MinimumSize = new System.Drawing.Size(780, 700);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditMap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private GamePanel panelMap;
        private System.Windows.Forms.RadioButton radbtnWall;
        private System.Windows.Forms.RadioButton radbtnGrass;
        private System.Windows.Forms.RadioButton radbtnWater;
        private System.Windows.Forms.RadioButton radbtnSteel;
        private System.Windows.Forms.Button btnClosed;
    }
}