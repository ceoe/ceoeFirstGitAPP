namespace Tetirs
{
    partial class FrmConfig
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gpEnviromentSet = new System.Windows.Forms.GroupBox();
            this.lbBackColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRectPix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbKeySet = new System.Windows.Forms.GroupBox();
            this.txtKeyRotCCW = new System.Windows.Forms.TextBox();
            this.lbKeyRotCCW = new System.Windows.Forms.Label();
            this.txtKeyRotCW = new System.Windows.Forms.TextBox();
            this.lbKeyRotCW = new System.Windows.Forms.Label();
            this.txtKeyDropDn = new System.Windows.Forms.TextBox();
            this.lbKeyDropDn = new System.Windows.Forms.Label();
            this.txtKeyDn = new System.Windows.Forms.TextBox();
            this.lbKeyDn = new System.Windows.Forms.Label();
            this.txtkeyRight = new System.Windows.Forms.TextBox();
            this.lbKeyRight = new System.Windows.Forms.Label();
            this.txtKeyLeft = new System.Windows.Forms.TextBox();
            this.lbKeyLeft = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.lsvBlockSet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblColor = new System.Windows.Forms.Label();
            this.lblModelconfig = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCFGFormClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpEnviromentSet.SuspendLayout();
            this.gbKeySet.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 332);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.gpEnviromentSet);
            this.tabPage1.Controls.Add(this.gbKeySet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数配置";
            // 
            // gpEnviromentSet
            // 
            this.gpEnviromentSet.Controls.Add(this.lbBackColor);
            this.gpEnviromentSet.Controls.Add(this.label7);
            this.gpEnviromentSet.Controls.Add(this.txtRectPix);
            this.gpEnviromentSet.Controls.Add(this.label8);
            this.gpEnviromentSet.Controls.Add(this.txtHeight);
            this.gpEnviromentSet.Controls.Add(this.label9);
            this.gpEnviromentSet.Controls.Add(this.txtWidth);
            this.gpEnviromentSet.Controls.Add(this.label10);
            this.gpEnviromentSet.Location = new System.Drawing.Point(319, 6);
            this.gpEnviromentSet.Name = "gpEnviromentSet";
            this.gpEnviromentSet.Size = new System.Drawing.Size(249, 287);
            this.gpEnviromentSet.TabIndex = 1;
            this.gpEnviromentSet.TabStop = false;
            this.gpEnviromentSet.Text = "游戏界面设置";
            // 
            // lbBackColor
            // 
            this.lbBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbBackColor.Location = new System.Drawing.Point(98, 161);
            this.lbBackColor.Name = "lbBackColor";
            this.lbBackColor.Size = new System.Drawing.Size(102, 18);
            this.lbBackColor.TabIndex = 15;
            this.lbBackColor.Click += new System.EventHandler(this.lbBackColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "背景色";
            // 
            // txtRectPix
            // 
            this.txtRectPix.Location = new System.Drawing.Point(98, 118);
            this.txtRectPix.Name = "txtRectPix";
            this.txtRectPix.Size = new System.Drawing.Size(100, 21);
            this.txtRectPix.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "格子像素大小";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(98, 75);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 21);
            this.txtHeight.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "垂直格子数";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(98, 32);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 21);
            this.txtWidth.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "水平格子数";
            // 
            // gbKeySet
            // 
            this.gbKeySet.Controls.Add(this.txtKeyRotCCW);
            this.gbKeySet.Controls.Add(this.lbKeyRotCCW);
            this.gbKeySet.Controls.Add(this.txtKeyRotCW);
            this.gbKeySet.Controls.Add(this.lbKeyRotCW);
            this.gbKeySet.Controls.Add(this.txtKeyDropDn);
            this.gbKeySet.Controls.Add(this.lbKeyDropDn);
            this.gbKeySet.Controls.Add(this.txtKeyDn);
            this.gbKeySet.Controls.Add(this.lbKeyDn);
            this.gbKeySet.Controls.Add(this.txtkeyRight);
            this.gbKeySet.Controls.Add(this.lbKeyRight);
            this.gbKeySet.Controls.Add(this.txtKeyLeft);
            this.gbKeySet.Controls.Add(this.lbKeyLeft);
            this.gbKeySet.Location = new System.Drawing.Point(27, 6);
            this.gbKeySet.Name = "gbKeySet";
            this.gbKeySet.Size = new System.Drawing.Size(249, 293);
            this.gbKeySet.TabIndex = 0;
            this.gbKeySet.TabStop = false;
            this.gbKeySet.Text = "键盘设置";
            // 
            // txtKeyRotCCW
            // 
            this.txtKeyRotCCW.Location = new System.Drawing.Point(97, 242);
            this.txtKeyRotCCW.Name = "txtKeyRotCCW";
            this.txtKeyRotCCW.ReadOnly = true;
            this.txtKeyRotCCW.Size = new System.Drawing.Size(100, 21);
            this.txtKeyRotCCW.TabIndex = 11;
            this.txtKeyRotCCW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyRotCCW_KeyDown);
            // 
            // lbKeyRotCCW
            // 
            this.lbKeyRotCCW.AutoSize = true;
            this.lbKeyRotCCW.Location = new System.Drawing.Point(6, 245);
            this.lbKeyRotCCW.Name = "lbKeyRotCCW";
            this.lbKeyRotCCW.Size = new System.Drawing.Size(89, 12);
            this.lbKeyRotCCW.TabIndex = 10;
            this.lbKeyRotCCW.Text = "逆时钟旋转90度";
            // 
            // txtKeyRotCW
            // 
            this.txtKeyRotCW.Location = new System.Drawing.Point(97, 200);
            this.txtKeyRotCW.Name = "txtKeyRotCW";
            this.txtKeyRotCW.ReadOnly = true;
            this.txtKeyRotCW.Size = new System.Drawing.Size(100, 21);
            this.txtKeyRotCW.TabIndex = 9;
            this.txtKeyRotCW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyRotCCW_KeyDown);
            // 
            // lbKeyRotCW
            // 
            this.lbKeyRotCW.AutoSize = true;
            this.lbKeyRotCW.Location = new System.Drawing.Point(6, 203);
            this.lbKeyRotCW.Name = "lbKeyRotCW";
            this.lbKeyRotCW.Size = new System.Drawing.Size(89, 12);
            this.lbKeyRotCW.TabIndex = 8;
            this.lbKeyRotCW.Text = "顺时钟旋转90度";
            // 
            // txtKeyDropDn
            // 
            this.txtKeyDropDn.Location = new System.Drawing.Point(97, 158);
            this.txtKeyDropDn.Name = "txtKeyDropDn";
            this.txtKeyDropDn.ReadOnly = true;
            this.txtKeyDropDn.Size = new System.Drawing.Size(100, 21);
            this.txtKeyDropDn.TabIndex = 7;
            this.txtKeyDropDn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyRotCCW_KeyDown);
            // 
            // lbKeyDropDn
            // 
            this.lbKeyDropDn.AutoSize = true;
            this.lbKeyDropDn.Location = new System.Drawing.Point(66, 161);
            this.lbKeyDropDn.Name = "lbKeyDropDn";
            this.lbKeyDropDn.Size = new System.Drawing.Size(29, 12);
            this.lbKeyDropDn.TabIndex = 6;
            this.lbKeyDropDn.Text = "直下";
            // 
            // txtKeyDn
            // 
            this.txtKeyDn.Location = new System.Drawing.Point(97, 116);
            this.txtKeyDn.Name = "txtKeyDn";
            this.txtKeyDn.ReadOnly = true;
            this.txtKeyDn.Size = new System.Drawing.Size(100, 21);
            this.txtKeyDn.TabIndex = 5;
            this.txtKeyDn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyRotCCW_KeyDown);
            // 
            // lbKeyDn
            // 
            this.lbKeyDn.AutoSize = true;
            this.lbKeyDn.Location = new System.Drawing.Point(66, 118);
            this.lbKeyDn.Name = "lbKeyDn";
            this.lbKeyDn.Size = new System.Drawing.Size(29, 12);
            this.lbKeyDn.TabIndex = 4;
            this.lbKeyDn.Text = "向下";
            // 
            // txtkeyRight
            // 
            this.txtkeyRight.Location = new System.Drawing.Point(97, 74);
            this.txtkeyRight.Name = "txtkeyRight";
            this.txtkeyRight.ReadOnly = true;
            this.txtkeyRight.Size = new System.Drawing.Size(100, 21);
            this.txtkeyRight.TabIndex = 3;
            this.txtkeyRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyRotCCW_KeyDown);
            // 
            // lbKeyRight
            // 
            this.lbKeyRight.AutoSize = true;
            this.lbKeyRight.Location = new System.Drawing.Point(66, 75);
            this.lbKeyRight.Name = "lbKeyRight";
            this.lbKeyRight.Size = new System.Drawing.Size(29, 12);
            this.lbKeyRight.TabIndex = 2;
            this.lbKeyRight.Text = "向右";
            // 
            // txtKeyLeft
            // 
            this.txtKeyLeft.Location = new System.Drawing.Point(97, 32);
            this.txtKeyLeft.Name = "txtKeyLeft";
            this.txtKeyLeft.ReadOnly = true;
            this.txtKeyLeft.Size = new System.Drawing.Size(100, 21);
            this.txtKeyLeft.TabIndex = 1;
            this.txtKeyLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyRotCCW_KeyDown);
            // 
            // lbKeyLeft
            // 
            this.lbKeyLeft.AutoSize = true;
            this.lbKeyLeft.Location = new System.Drawing.Point(66, 32);
            this.lbKeyLeft.Name = "lbKeyLeft";
            this.lbKeyLeft.Size = new System.Drawing.Size(29, 12);
            this.lbKeyLeft.TabIndex = 0;
            this.lbKeyLeft.Text = "向左";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.btnUpdate);
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.btnAddModel);
            this.tabPage2.Controls.Add(this.lsvBlockSet);
            this.tabPage2.Controls.Add(this.lblColor);
            this.tabPage2.Controls.Add(this.lblModelconfig);
            this.tabPage2.ForeColor = System.Drawing.Color.Red;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "砖块样式配置";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(8, 248);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "修改并更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(8, 277);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(86, 23);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "删除单个模型";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(8, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(48, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddModel
            // 
            this.btnAddModel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddModel.Location = new System.Drawing.Point(8, 219);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(86, 23);
            this.btnAddModel.TabIndex = 3;
            this.btnAddModel.Text = "添加方块模型";
            this.btnAddModel.UseVisualStyleBackColor = false;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // lsvBlockSet
            // 
            this.lsvBlockSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvBlockSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvBlockSet.FullRowSelect = true;
            this.lsvBlockSet.GridLines = true;
            this.lsvBlockSet.Location = new System.Drawing.Point(162, 0);
            this.lsvBlockSet.MultiSelect = false;
            this.lsvBlockSet.Name = "lsvBlockSet";
            this.lsvBlockSet.Size = new System.Drawing.Size(433, 306);
            this.lsvBlockSet.TabIndex = 2;
            this.lsvBlockSet.UseCompatibleStateImageBehavior = false;
            this.lsvBlockSet.View = System.Windows.Forms.View.Details;
            this.lsvBlockSet.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvBlockSet_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width = 290;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "颜色";
            this.columnHeader2.Width = 125;
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.Gold;
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblColor.Location = new System.Drawing.Point(8, 193);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(148, 23);
            this.lblColor.TabIndex = 1;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // lblModelconfig
            // 
            this.lblModelconfig.BackColor = System.Drawing.Color.Black;
            this.lblModelconfig.Location = new System.Drawing.Point(3, 29);
            this.lblModelconfig.Margin = new System.Windows.Forms.Padding(0);
            this.lblModelconfig.Name = "lblModelconfig";
            this.lblModelconfig.Size = new System.Drawing.Size(155, 155);
            this.lblModelconfig.TabIndex = 0;
            this.lblModelconfig.Paint += new System.Windows.Forms.PaintEventHandler(this.lblModelconfig_Paint);
            this.lblModelconfig.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblModelconfig_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存到文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCFGFormClose
            // 
            this.btnCFGFormClose.Location = new System.Drawing.Point(99, 341);
            this.btnCFGFormClose.Name = "btnCFGFormClose";
            this.btnCFGFormClose.Size = new System.Drawing.Size(75, 23);
            this.btnCFGFormClose.TabIndex = 2;
            this.btnCFGFormClose.Text = "关闭配置";
            this.btnCFGFormClose.UseVisualStyleBackColor = true;
            this.btnCFGFormClose.Click += new System.EventHandler(this.btnCFGFormClose_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 376);
            this.Controls.Add(this.btnCFGFormClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmConfig";
            this.Text = "配置窗体";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gpEnviromentSet.ResumeLayout(false);
            this.gpEnviromentSet.PerformLayout();
            this.gbKeySet.ResumeLayout(false);
            this.gbKeySet.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblModelconfig;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.ListView lsvBlockSet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gpEnviromentSet;
        private System.Windows.Forms.GroupBox gbKeySet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRectPix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKeyRotCCW;
        private System.Windows.Forms.Label lbKeyRotCCW;
        private System.Windows.Forms.TextBox txtKeyRotCW;
        private System.Windows.Forms.Label lbKeyRotCW;
        private System.Windows.Forms.TextBox txtKeyDropDn;
        private System.Windows.Forms.Label lbKeyDropDn;
        private System.Windows.Forms.TextBox txtKeyDn;
        private System.Windows.Forms.Label lbKeyDn;
        private System.Windows.Forms.TextBox txtkeyRight;
        private System.Windows.Forms.Label lbKeyRight;
        private System.Windows.Forms.TextBox txtKeyLeft;
        private System.Windows.Forms.Label lbKeyLeft;
        private System.Windows.Forms.Label lbBackColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCFGFormClose;
    }
}

