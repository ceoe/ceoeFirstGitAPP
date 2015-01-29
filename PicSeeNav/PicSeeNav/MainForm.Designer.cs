namespace PicSeeNav
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnCreateFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBarLoadPic = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelPic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsViewPic = new System.Windows.Forms.ToolStrip();
            this.tsBtnReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNext = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPlay = new System.Windows.Forms.ToolStripButton();
            this.tscbInterval = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnNormal = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar3 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lstFolder = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbAerialView = new System.Windows.Forms.PictureBox();
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.lsvView = new System.Windows.Forms.ListView();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tsViewPic.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAerialView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCreateFolder,
            this.tsbtnDelFolder,
            this.toolStripSeparator1,
            this.tsBarLoadPic,
            this.tsbtnDelPic,
            this.toolStripSeparator2,
            this.tsbtnExit,
            this.toolStripButton1});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(774, 56);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnCreateFolder
            // 
            this.tsbtnCreateFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCreateFolder.Image")));
            this.tsbtnCreateFolder.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateFolder.Name = "tsbtnCreateFolder";
            this.tsbtnCreateFolder.Size = new System.Drawing.Size(60, 53);
            this.tsbtnCreateFolder.Text = "新增目录";
            this.tsbtnCreateFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCreateFolder.Click += new System.EventHandler(this.tsbtnCreateFolder_Click);
            // 
            // tsbtnDelFolder
            // 
            this.tsbtnDelFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelFolder.Image")));
            this.tsbtnDelFolder.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnDelFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelFolder.Name = "tsbtnDelFolder";
            this.tsbtnDelFolder.Size = new System.Drawing.Size(60, 53);
            this.tsbtnDelFolder.Text = "删除目录";
            this.tsbtnDelFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDelFolder.Click += new System.EventHandler(this.tsbtnDelFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // tsBarLoadPic
            // 
            this.tsBarLoadPic.Image = ((System.Drawing.Image)(resources.GetObject("tsBarLoadPic.Image")));
            this.tsBarLoadPic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsBarLoadPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBarLoadPic.Name = "tsBarLoadPic";
            this.tsBarLoadPic.Size = new System.Drawing.Size(60, 53);
            this.tsBarLoadPic.Text = "导入图片";
            this.tsBarLoadPic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBarLoadPic.Click += new System.EventHandler(this.tsBarLoadPic_Click);
            // 
            // tsbtnDelPic
            // 
            this.tsbtnDelPic.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelPic.Image")));
            this.tsbtnDelPic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnDelPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelPic.Name = "tsbtnDelPic";
            this.tsbtnDelPic.Size = new System.Drawing.Size(60, 53);
            this.tsbtnDelPic.Text = "删除图片";
            this.tsbtnDelPic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDelPic.Click += new System.EventHandler(this.tsbtnDelPic_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(60, 53);
            this.tsbtnExit.Text = "退出程序";
            this.tsbtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnExit.Click += new System.EventHandler(this.tsbtnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(400, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsViewPic
            // 
            this.tsViewPic.BackColor = System.Drawing.SystemColors.Highlight;
            this.tsViewPic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsViewPic.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsViewPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnReturn,
            this.toolStripSeparator3,
            this.tsBtnPrevious,
            this.tsBtnNext,
            this.tsBtnPlay,
            this.tscbInterval,
            this.toolStripSeparator4,
            this.tsBtnNormal,
            this.tsBtnMatch,
            this.toolStripSeparator5,
            this.toolStripProgressBar2,
            this.toolStripSeparator6,
            this.toolStripProgressBar3,
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.tsViewPic.Location = new System.Drawing.Point(0, 370);
            this.tsViewPic.Name = "tsViewPic";
            this.tsViewPic.Size = new System.Drawing.Size(774, 31);
            this.tsViewPic.TabIndex = 2;
            this.tsViewPic.Text = "toolStrip1";
            // 
            // tsBtnReturn
            // 
            this.tsBtnReturn.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnReturn.Image")));
            this.tsBtnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReturn.Name = "tsBtnReturn";
            this.tsBtnReturn.Size = new System.Drawing.Size(84, 28);
            this.tsBtnReturn.Text = "返回目录";
            this.tsBtnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnReturn.Click += new System.EventHandler(this.tsBtnReturn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsBtnPrevious
            // 
            this.tsBtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPrevious.Image")));
            this.tsBtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrevious.Name = "tsBtnPrevious";
            this.tsBtnPrevious.Size = new System.Drawing.Size(28, 28);
            this.tsBtnPrevious.ToolTipText = " 上一张图片";
            this.tsBtnPrevious.Click += new System.EventHandler(this.tsBtnPrevious_Click);
            // 
            // tsBtnNext
            // 
            this.tsBtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNext.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNext.Image")));
            this.tsBtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNext.Name = "tsBtnNext";
            this.tsBtnNext.Size = new System.Drawing.Size(28, 28);
            this.tsBtnNext.Text = "toolStripButton5";
            this.tsBtnNext.ToolTipText = "下一张图片";
            this.tsBtnNext.Click += new System.EventHandler(this.tsBtnNext_Click);
            // 
            // tsBtnPlay
            // 
            this.tsBtnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPlay.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPlay.Image")));
            this.tsBtnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPlay.Name = "tsBtnPlay";
            this.tsBtnPlay.Size = new System.Drawing.Size(28, 28);
            this.tsBtnPlay.ToolTipText = "自动播放";
            this.tsBtnPlay.Click += new System.EventHandler(this.tsBtnPlay_Click);
            // 
            // tscbInterval
            // 
            this.tscbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbInterval.Items.AddRange(new object[] {
            "1 s",
            "3 s",
            "5 s",
            "8 s"});
            this.tscbInterval.Name = "tscbInterval";
            this.tscbInterval.Size = new System.Drawing.Size(75, 31);
            this.tscbInterval.ToolTipText = "时间间隔";
            this.tscbInterval.SelectedIndexChanged += new System.EventHandler(this.tscbInterval_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // tsBtnNormal
            // 
            this.tsBtnNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNormal.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNormal.Image")));
            this.tsBtnNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNormal.Name = "tsBtnNormal";
            this.tsBtnNormal.Size = new System.Drawing.Size(28, 28);
            this.tsBtnNormal.ToolTipText = "实际大小";
            this.tsBtnNormal.Click += new System.EventHandler(this.tsBtnNormal_Click);
            // 
            // tsBtnMatch
            // 
            this.tsBtnMatch.Checked = true;
            this.tsBtnMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnMatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnMatch.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnMatch.Image")));
            this.tsBtnMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMatch.Name = "tsBtnMatch";
            this.tsBtnMatch.Size = new System.Drawing.Size(28, 28);
            this.tsBtnMatch.ToolTipText = "合适大小";
            this.tsBtnMatch.Click += new System.EventHandler(this.tsBtnMatch_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripProgressBar2
            // 
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 28);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripProgressBar3
            // 
            this.toolStripProgressBar3.Name = "toolStripProgressBar3";
            this.toolStripProgressBar3.Size = new System.Drawing.Size(100, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 28);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 28);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // lstFolder
            // 
            this.lstFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstFolder.FormattingEnabled = true;
            this.lstFolder.ItemHeight = 12;
            this.lstFolder.Location = new System.Drawing.Point(0, 56);
            this.lstFolder.Name = "lstFolder";
            this.lstFolder.Size = new System.Drawing.Size(120, 314);
            this.lstFolder.TabIndex = 3;
            this.lstFolder.SelectedIndexChanged += new System.EventHandler(this.lstFolder_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(120, 56);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 314);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbAerialView);
            this.panel1.Controls.Add(this.pbPic);
            this.panel1.Controls.Add(this.lsvView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(125, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 314);
            this.panel1.TabIndex = 5;
            // 
            // pbAerialView
            // 
            this.pbAerialView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAerialView.Location = new System.Drawing.Point(549, 214);
            this.pbAerialView.MaximumSize = new System.Drawing.Size(100, 100);
            this.pbAerialView.MinimumSize = new System.Drawing.Size(100, 100);
            this.pbAerialView.Name = "pbAerialView";
            this.pbAerialView.Size = new System.Drawing.Size(100, 100);
            this.pbAerialView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAerialView.TabIndex = 2;
            this.pbAerialView.TabStop = false;
            // 
            // pbPic
            // 
            this.pbPic.Location = new System.Drawing.Point(173, 91);
            this.pbPic.Name = "pbPic";
            this.pbPic.Size = new System.Drawing.Size(100, 50);
            this.pbPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPic.TabIndex = 1;
            this.pbPic.TabStop = false;
            this.pbPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPic_MouseDown);
            this.pbPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPic_MouseMove);
            this.pbPic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPic_MouseUp);
            // 
            // lsvView
            // 
            this.lsvView.LargeImageList = this.imgLst;
            this.lsvView.Location = new System.Drawing.Point(31, 91);
            this.lsvView.Name = "lsvView";
            this.lsvView.OwnerDraw = true;
            this.lsvView.Size = new System.Drawing.Size(121, 97);
            this.lsvView.TabIndex = 0;
            this.lsvView.UseCompatibleStateImageBehavior = false;
            this.lsvView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lsvView_DrawItem);
            this.lsvView.DoubleClick += new System.EventHandler(this.lsvView_DoubleClick);
            // 
            // imgLst
            // 
            this.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgLst.ImageSize = new System.Drawing.Size(80, 90);
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 53);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lstFolder);
            this.Controls.Add(this.tsViewPic);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMain);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(640, 460);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsViewPic.ResumeLayout(false);
            this.tsViewPic.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAerialView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnCreateFolder;
        private System.Windows.Forms.ToolStripButton tsbtnDelFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBarLoadPic;
        private System.Windows.Forms.ToolStripButton tsbtnDelPic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip tsViewPic;
        private System.Windows.Forms.ListBox lstFolder;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvView;
        private System.Windows.Forms.ImageList imgLst;
        private System.Windows.Forms.ToolStripButton tsBtnReturn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsBtnPrevious;
        private System.Windows.Forms.ToolStripButton tsBtnNext;
        private System.Windows.Forms.ToolStripButton tsBtnPlay;
        private System.Windows.Forms.ToolStripComboBox tscbInterval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsBtnNormal;
        private System.Windows.Forms.ToolStripButton tsBtnMatch;
        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.PictureBox pbAerialView;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

