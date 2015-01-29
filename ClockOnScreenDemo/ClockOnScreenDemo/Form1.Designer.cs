namespace ClockOnScreenDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemHide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemShow,
            this.menuStripItemHide,
            this.menuStripItemClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // menuStripItemShow
            // 
            this.menuStripItemShow.Name = "menuStripItemShow";
            this.menuStripItemShow.Size = new System.Drawing.Size(100, 22);
            this.menuStripItemShow.Text = "显示";
            this.menuStripItemShow.Click += new System.EventHandler(this.menuStripItemShow_Click);
            // 
            // menuStripItemHide
            // 
            this.menuStripItemHide.Name = "menuStripItemHide";
            this.menuStripItemHide.Size = new System.Drawing.Size(100, 22);
            this.menuStripItemHide.Text = "隐藏";
            this.menuStripItemHide.Click += new System.EventHandler(this.menuStripItemHide_Click);
            // 
            // menuStripItemClose
            // 
            this.menuStripItemClose.Name = "menuStripItemClose";
            this.menuStripItemClose.Size = new System.Drawing.Size(100, 22);
            this.menuStripItemClose.Text = "关闭";
            this.menuStripItemClose.Click += new System.EventHandler(this.menuStripItemClose_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "时钟小程序";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "时钟小程序";
            this.TransparencyKey = System.Drawing.SystemColors.ControlDark;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemShow;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemHide;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemClose;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

