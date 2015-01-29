namespace RockForfexClothFightExp1
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRivalScore = new System.Windows.Forms.Label();
            this.lblMyScore = new System.Windows.Forms.Label();
            this.btnRock = new System.Windows.Forms.Button();
            this.btnForfex = new System.Windows.Forms.Button();
            this.btnCloth = new System.Windows.Forms.Button();
            this.lblRival = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblMy = new System.Windows.Forms.Label();
            this.imgLstButtom = new System.Windows.Forms.ImageList(this.components);
            this.imgLstRival = new System.Windows.Forms.ImageList(this.components);
            this.imgLstMy = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMy);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.lblRival);
            this.panel1.Location = new System.Drawing.Point(2, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 268);
            this.panel1.TabIndex = 0;
            // 
            // lblRivalScore
            // 
            this.lblRivalScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRivalScore.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRivalScore.Location = new System.Drawing.Point(133, 13);
            this.lblRivalScore.Name = "lblRivalScore";
            this.lblRivalScore.Size = new System.Drawing.Size(99, 66);
            this.lblRivalScore.TabIndex = 1;
            this.lblRivalScore.Text = "0";
            this.lblRivalScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMyScore
            // 
            this.lblMyScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMyScore.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMyScore.Location = new System.Drawing.Point(133, 212);
            this.lblMyScore.Name = "lblMyScore";
            this.lblMyScore.Size = new System.Drawing.Size(99, 69);
            this.lblMyScore.TabIndex = 2;
            this.lblMyScore.Text = "0";
            this.lblMyScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRock
            // 
            this.btnRock.BackColor = System.Drawing.SystemColors.Control;
            this.btnRock.ImageIndex = 0;
            this.btnRock.ImageList = this.imgLstButtom;
            this.btnRock.Location = new System.Drawing.Point(3, 287);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(40, 40);
            this.btnRock.TabIndex = 3;
            this.btnRock.Text = "石头";
            this.btnRock.UseVisualStyleBackColor = false;
            this.btnRock.Click += new System.EventHandler(this.btnRock_Click);
            // 
            // btnForfex
            // 
            this.btnForfex.ImageIndex = 1;
            this.btnForfex.ImageList = this.imgLstButtom;
            this.btnForfex.Location = new System.Drawing.Point(45, 287);
            this.btnForfex.Name = "btnForfex";
            this.btnForfex.Size = new System.Drawing.Size(40, 40);
            this.btnForfex.TabIndex = 4;
            this.btnForfex.Text = "剪刀";
            this.btnForfex.UseVisualStyleBackColor = true;
            this.btnForfex.Click += new System.EventHandler(this.btnRock_Click);
            // 
            // btnCloth
            // 
            this.btnCloth.ImageIndex = 2;
            this.btnCloth.ImageList = this.imgLstButtom;
            this.btnCloth.Location = new System.Drawing.Point(87, 287);
            this.btnCloth.Name = "btnCloth";
            this.btnCloth.Size = new System.Drawing.Size(40, 40);
            this.btnCloth.TabIndex = 5;
            this.btnCloth.Text = "布";
            this.btnCloth.UseVisualStyleBackColor = true;
            this.btnCloth.Click += new System.EventHandler(this.btnRock_Click);
            // 
            // lblRival
            // 
            this.lblRival.ImageList = this.imgLstRival;
            this.lblRival.Location = new System.Drawing.Point(21, 9);
            this.lblRival.Name = "lblRival";
            this.lblRival.Size = new System.Drawing.Size(80, 80);
            this.lblRival.TabIndex = 0;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(20, 97);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(88, 71);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "赢";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMy
            // 
            this.lblMy.ImageList = this.imgLstMy;
            this.lblMy.Location = new System.Drawing.Point(23, 178);
            this.lblMy.Name = "lblMy";
            this.lblMy.Size = new System.Drawing.Size(80, 80);
            this.lblMy.TabIndex = 2;
            // 
            // imgLstButtom
            // 
            this.imgLstButtom.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstButtom.ImageStream")));
            this.imgLstButtom.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstButtom.Images.SetKeyName(0, "按钮石头.bmp");
            this.imgLstButtom.Images.SetKeyName(1, "按钮剪子.bmp");
            this.imgLstButtom.Images.SetKeyName(2, "按钮布.bmp");
            // 
            // imgLstRival
            // 
            this.imgLstRival.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstRival.ImageStream")));
            this.imgLstRival.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstRival.Images.SetKeyName(0, "对方石头.bmp");
            this.imgLstRival.Images.SetKeyName(1, "对方剪子.bmp");
            this.imgLstRival.Images.SetKeyName(2, "对方布.bmp");
            // 
            // imgLstMy
            // 
            this.imgLstMy.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMy.ImageStream")));
            this.imgLstMy.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMy.Images.SetKeyName(0, "本方石头.bmp");
            this.imgLstMy.Images.SetKeyName(1, "本方剪子.bmp");
            this.imgLstMy.Images.SetKeyName(2, "本方布.bmp");
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 333);
            this.Controls.Add(this.btnCloth);
            this.Controls.Add(this.btnForfex);
            this.Controls.Add(this.btnRock);
            this.Controls.Add(this.lblMyScore);
            this.Controls.Add(this.lblRivalScore);
            this.Controls.Add(this.panel1);
            this.Name = "Main_Form";
            this.Text = "石头剪子布游戏";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRival;
        private System.Windows.Forms.Label lblRivalScore;
        private System.Windows.Forms.Label lblMyScore;
        private System.Windows.Forms.Button btnRock;
        private System.Windows.Forms.Button btnForfex;
        private System.Windows.Forms.Button btnCloth;
        private System.Windows.Forms.ImageList imgLstMy;
        private System.Windows.Forms.ImageList imgLstRival;
        private System.Windows.Forms.ImageList imgLstButtom;
    }
}

