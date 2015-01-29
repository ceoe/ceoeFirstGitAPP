namespace PicSeeNav
{
    partial class FrmLoadPic
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbFolder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelPic = new System.Windows.Forms.Button();
            this.chklsPics = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPicName = new System.Windows.Forms.TextBox();
            this.btnUpdateName = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialogSelPic = new System.Windows.Forms.OpenFileDialog();
            this.btnClearchklst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "导入到目录";
            // 
            // cbFolder
            // 
            this.cbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFolder.FormattingEnabled = true;
            this.cbFolder.Location = new System.Drawing.Point(84, 10);
            this.cbFolder.Name = "cbFolder";
            this.cbFolder.Size = new System.Drawing.Size(168, 20);
            this.cbFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "添加图片:";
            // 
            // btnSelPic
            // 
            this.btnSelPic.Location = new System.Drawing.Point(345, 7);
            this.btnSelPic.Name = "btnSelPic";
            this.btnSelPic.Size = new System.Drawing.Size(75, 23);
            this.btnSelPic.TabIndex = 3;
            this.btnSelPic.Text = "浏览";
            this.btnSelPic.UseVisualStyleBackColor = true;
            this.btnSelPic.Click += new System.EventHandler(this.btnSelPic_Click);
            // 
            // chklsPics
            // 
            this.chklsPics.FormattingEnabled = true;
            this.chklsPics.HorizontalScrollbar = true;
            this.chklsPics.Location = new System.Drawing.Point(13, 40);
            this.chklsPics.Name = "chklsPics";
            this.chklsPics.Size = new System.Drawing.Size(407, 164);
            this.chklsPics.TabIndex = 4;
            this.chklsPics.SelectedIndexChanged += new System.EventHandler(this.chklsPics_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "图片名称(可在此修改):";
            // 
            // txtPicName
            // 
            this.txtPicName.Location = new System.Drawing.Point(147, 224);
            this.txtPicName.Name = "txtPicName";
            this.txtPicName.Size = new System.Drawing.Size(116, 21);
            this.txtPicName.TabIndex = 6;
            // 
            // btnUpdateName
            // 
            this.btnUpdateName.Location = new System.Drawing.Point(298, 222);
            this.btnUpdateName.Name = "btnUpdateName";
            this.btnUpdateName.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateName.TabIndex = 7;
            this.btnUpdateName.Text = "修改";
            this.btnUpdateName.UseVisualStyleBackColor = true;
            this.btnUpdateName.Click += new System.EventHandler(this.btnUpdateName_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "如果图像重名,将会被自动更名!!";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(198, 251);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(298, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialogSelPic
            // 
            this.openFileDialogSelPic.Multiselect = true;
            // 
            // btnClearchklst
            // 
            this.btnClearchklst.Location = new System.Drawing.Point(380, 224);
            this.btnClearchklst.Name = "btnClearchklst";
            this.btnClearchklst.Size = new System.Drawing.Size(40, 50);
            this.btnClearchklst.TabIndex = 11;
            this.btnClearchklst.Text = "清除列表";
            this.btnClearchklst.UseVisualStyleBackColor = true;
            this.btnClearchklst.Click += new System.EventHandler(this.btnClearchklst_Click);
            // 
            // FrmLoadPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 297);
            this.Controls.Add(this.btnClearchklst);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdateName);
            this.Controls.Add(this.txtPicName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chklsPics);
            this.Controls.Add(this.btnSelPic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmLoadPic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入图片";
            this.Load += new System.EventHandler(this.FrmLoadPic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelPic;
        private System.Windows.Forms.CheckedListBox chklsPics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPicName;
        private System.Windows.Forms.Button btnUpdateName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelPic;
        private System.Windows.Forms.Button btnClearchklst;
    }
}