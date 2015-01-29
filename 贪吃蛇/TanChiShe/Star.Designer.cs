namespace TanChiShe
{
    partial class Star
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
            this.mainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem1,
            this.MenuItem4,
            this.MenuItem11});
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(463, 24);
            this.mainMenu1.TabIndex = 0;
            this.mainMenu1.Text = "menuStrip1";
            // 
            // MenuItem1
            // 
            this.MenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem,
            this.MenuItem2,
            this.退出ToolStripMenuItem,
            this.MenuItem3});
            this.MenuItem1.Name = "MenuItem1";
            this.MenuItem1.Size = new System.Drawing.Size(41, 20);
            this.MenuItem1.Text = "操作";
            // 
            // MenuItem
            // 
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MenuItem.Size = new System.Drawing.Size(152, 22);
            this.MenuItem.Text = "开始";
            this.MenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Enabled = false;
            this.MenuItem2.Name = "MenuItem2";
            this.MenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItem2.Size = new System.Drawing.Size(152, 22);
            this.MenuItem2.Text = "暂停";
            this.MenuItem2.Click += new System.EventHandler(this.MenuItem2_Click);
            // 
            // MenuItem3
            // 
            this.MenuItem3.Name = "MenuItem3";
            this.MenuItem3.Size = new System.Drawing.Size(152, 22);
            this.MenuItem3.Text = "退出";
            this.MenuItem3.Click += new System.EventHandler(this.MenuItem3_Click);
            // 
            // MenuItem4
            // 
            this.MenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem5,
            this.MenuItem6,
            this.MenuItem7,
            this.MenuItem8,
            this.MenuItem9,
            this.toolStripSeparator1,
            this.MenuItem10});
            this.MenuItem4.Name = "MenuItem4";
            this.MenuItem4.Size = new System.Drawing.Size(41, 20);
            this.MenuItem4.Text = "级别";
            // 
            // MenuItem5
            // 
            this.MenuItem5.Name = "MenuItem5";
            this.MenuItem5.Size = new System.Drawing.Size(106, 22);
            this.MenuItem5.Text = "第一关";
            this.MenuItem5.Click += new System.EventHandler(this.MenuItem5_Click);
            // 
            // MenuItem6
            // 
            this.MenuItem6.Name = "MenuItem6";
            this.MenuItem6.Size = new System.Drawing.Size(106, 22);
            this.MenuItem6.Text = "第二关";
            this.MenuItem6.Click += new System.EventHandler(this.MenuItem6_Click);
            // 
            // MenuItem7
            // 
            this.MenuItem7.Name = "MenuItem7";
            this.MenuItem7.Size = new System.Drawing.Size(106, 22);
            this.MenuItem7.Text = "第三关";
            this.MenuItem7.Click += new System.EventHandler(this.MenuItem7_Click);
            // 
            // MenuItem8
            // 
            this.MenuItem8.Name = "MenuItem8";
            this.MenuItem8.Size = new System.Drawing.Size(106, 22);
            this.MenuItem8.Text = "第四关";
            this.MenuItem8.Click += new System.EventHandler(this.MenuItem8_Click);
            // 
            // MenuItem9
            // 
            this.MenuItem9.Name = "MenuItem9";
            this.MenuItem9.Size = new System.Drawing.Size(106, 22);
            this.MenuItem9.Text = "第五关";
            this.MenuItem9.Click += new System.EventHandler(this.MenuItem9_Click);
            // 
            // MenuItem10
            // 
            this.MenuItem10.Name = "MenuItem10";
            this.MenuItem10.Size = new System.Drawing.Size(106, 22);
            this.MenuItem10.Text = "自定义";
            this.MenuItem10.Click += new System.EventHandler(this.MenuItem10_Click);
            // 
            // MenuItem11
            // 
            this.MenuItem11.Name = "MenuItem11";
            this.MenuItem11.Size = new System.Drawing.Size(41, 20);
            this.MenuItem11.Text = "帮助";
            this.MenuItem11.Click += new System.EventHandler(this.MenuItem11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "等级";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "得分";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(463, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "欢迎使用‘贪吃蛇’";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabel1.Text = "　欢迎使用＜贪吃蛇＞";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // Star
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(463, 337);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainMenu1);
            this.Name = "Star";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Star_KeyDown);
            this.mainMenu1.ResumeLayout(false);
            this.mainMenu1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuItem5;
        private System.Windows.Forms.ToolStripMenuItem MenuItem6;
        private System.Windows.Forms.ToolStripMenuItem MenuItem7;
        private System.Windows.Forms.ToolStripMenuItem MenuItem8;
        private System.Windows.Forms.ToolStripMenuItem MenuItem9;
        private System.Windows.Forms.ToolStripMenuItem MenuItem10;
        private System.Windows.Forms.ToolStripMenuItem MenuItem11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSeparator 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

