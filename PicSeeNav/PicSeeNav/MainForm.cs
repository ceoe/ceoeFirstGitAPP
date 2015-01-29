using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSeeNav
{
    public partial class MainForm : Form
    {
        private FrmCreatFolder frmCreateFolder;


        public MainForm()
        {
            InitializeComponent();
        }

        private string PhtoAlbumPath = Application.StartupPath + "\\图片目录";
       private Pen boundPen=new Pen(Color.Gainsboro);
        private Pen selPen=new Pen(Color.Blue,3);
        private  SolidBrush textBrush=new SolidBrush(Color.Black);
        private SolidBrush bgBrush;
        private  StringFormat format=new StringFormat();
        private Bitmap bmpInpb;
        private Bitmap bmpAerialInpb;
        private  Point mouseOnPressPoint=new Point();
        private Point pbOnMousePressPoint = new Point();
        private bool canDrag;
        private bool isDraging;
        private bool IsPicOverPanel;
        private int bmpIndex;




        private void MainForm_Load(object sender, EventArgs e)
        {
            lsvView.Dock=DockStyle.Fill;
            tscbInterval.SelectedIndex = 1;
            EnterShowThumbnailListMode();

            bgBrush = new SolidBrush(lsvView.BackColor);
            statusStrip1.Items[0].Visible = false;
            format.Alignment=StringAlignment.Center;

            try
            {
                if (!Directory.Exists(PhtoAlbumPath))
                {
                    Directory.CreateDirectory(PhtoAlbumPath);
                }
               }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DirectoryInfo PhotoAlbumSubList = new DirectoryInfo(PhtoAlbumPath);
            foreach (DirectoryInfo SubDir in PhotoAlbumSubList.GetDirectories())
            {
                
                
                Folder   folder=new Folder(Application.StartupPath,SubDir.Name);
                //所有遍历出来的文件夹均已经存放到lstFolder.Item中了.
                //只要遍历lstFolder.Items 这个集合,就可以存取这整个子目录了.
                lstFolder.Items.Add(folder);
            }
        }


        private void tsbtnCreateFolder_Click(object sender, EventArgs e)
        {
            if (frmCreateFolder==null)
            {
                frmCreateFolder = new FrmCreatFolder(this.lstFolder);
            }

            frmCreateFolder.ShowDialog(this);


            //try
            //{
            //    frmCreateFolder.ShowDialog(this);
            //}
            //finally
            //{
            //frmCreateFolder.Dispose();
            //}
        }

        private void tsBtnTest_Click(object sender, EventArgs e)
        {

        }

         
        private void tsBarLoadPic_Click(object sender, EventArgs e)
        {
           FrmLoadPic frmLoadPic  = new FrmLoadPic(this.lstFolder,this.statusStrip1);

            foreach (Control c in frmLoadPic.Controls)
            {
                if (c  is CheckedListBox)
                {
                   ((CheckedListBox)c).Items.Clear();
                }
            }
            if (frmLoadPic.ShowDialog(this)==DialogResult.OK)
            {
                LoadToListView();
            }
          frmLoadPic.Dispose();
  
           
        }

        private void lsvView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (lsvView.Items.Count==0)
            {
                return;
               
            }
            Graphics g = e.Graphics;
            Folder folder = (Folder) lstFolder.SelectedItem;
            Bitmap bmp = folder.GetThumbnail(e.Item.Text);
            Rectangle bmpRect = Folder.GetRectFromBounds(bmp,e.Bounds);
            bmpRect.Offset(0,1);
            Rectangle boundRect = Folder.GetRectFromBounds(101, 101, e.Bounds);
            Rectangle textRect=new Rectangle(e.Bounds.X+4,e.Bounds.Y+109,e.Bounds.Width-8,16);
            g.DrawRectangle(boundPen,boundRect);

            if ((e.State & ListViewItemStates.Selected)!=0) 
            {
                g.DrawImage(bmp,bmpRect);
                boundRect.Inflate(4,4);
                e.Graphics.DrawRectangle(selPen,boundRect);
            }
            else
            {
                g.DrawImage(bmp, bmpRect);
            }
            g.FillRectangle(bgBrush,textRect);
            g.DrawString(e.Item.Text,lsvView.Font,textBrush,textRect,format);
        }

        private void lstFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFolder.SelectedItems.Count==0)
            {
                return;
            }
            LoadToListView();
            
        }

        public void LoadToListView()
        {
            Folder folder = (Folder) lstFolder.SelectedItem;
            string lstdir = PhtoAlbumPath +"\\"+ lstFolder.SelectedItem.ToString();
            lsvView.BeginUpdate();
            lsvView.Clear();
            if (!folder.IsLoad)
            {
                folder.ReadDirPicFileAndCreatThumbAddToBmps(lstdir);
            }
            foreach (DictionaryEntry de in folder.bmps)
            {
                lsvView.Items.Add((string) de.Key);
            }
            lsvView.EndUpdate();
        }

        private void EnterShowThumbnailListMode()
        {
            tsMain.Visible = true;
            lstFolder.Visible = true;
            splitter1.Visible = true;
            lsvView.Visible = true;
            pbPic.Visible = false;
            tsViewPic.Visible = false;
            pbAerialView.Visible = false;
        }

        private void EnterShowPictureMode()
        {
            tsMain.Visible = false;
            lstFolder.Visible = false;
            splitter1.Visible = false;
            lsvView.Visible = false;
            pbPic.Visible = true;
            tsViewPic.Visible = true;
            pbAerialView.Visible = false;
        }

        private void lsvView_DoubleClick(object sender, EventArgs e)
        {
            Point p = Control.MousePosition;
            p = lsvView.PointToClient(p);
            ListViewHitTestInfo info = lsvView.HitTest(p);
            EnterShowPictureMode();

            PaintImageInpb(info.Item.Text);
            bmpIndex = info.Item.Index;
        }

        private void PaintImageInpb(string text)
        {
            Folder folder = (Folder) lstFolder.SelectedItem;
            if (bmpInpb != null)
            {
                bmpInpb.Dispose();
            }
            bmpInpb = folder.GetImageFromDir(text);
            statusStrip1.Items[1].Text = "名称:  " + text + "        尺寸:  " + bmpInpb.Width.ToString() + "×" +
                                         bmpInpb.Height.ToString();
            pbPic.Image = bmpInpb;
            bmpAerialInpb = folder.GetThumbnail(text);
            IsPicOverPanel = pbPic.Width > panel1.Width || pbPic.Height > panel1.Height ? true : false;
            MatchImage();

          

        }


        private void MatchImage()
        {
             
            //Dock, SizeMode模式一旦改变,其 Top , Left 属性就会改变, 必然要重新计算赋值给Top,Left
            if (tsBtnNormal.Checked)
            {
                 ShowPicInNormalMode(IsPicOverPanel);
            }
            else
            {

                ShowPicInMatchMode(IsPicOverPanel);
              
            }
            #region MyRegion
            //if (!tsBtnNormal.Checked)
            //{
            //    //无缩放居中显示
            //    pbPic.Dock = DockStyle.None;
            //    pbPic.SizeMode = PictureBoxSizeMode.AutoSize;
            //    pbPic.Top = (panel1.Height - pbPic.Height) / 2;
            //    pbPic.Left = (panel1.Width - pbPic.Width) / 2;

            //    if (pbPic.Width>panel1.Width||pbPic.Height>panel1.Height)
            //    {
            //        pbPic.Cursor = Cursors.Hand;
            //        canDrag = true;
            //    }
            //    else
            //    {
            //        pbPic.Cursor = Cursors.Default;
            //        canDrag = false;
            //    }

            //}
            //else
            //{
            //    canDrag = false;
            //    pbPic.Cursor = Cursors.Default;
            //    if (pbPic.Width > panel1.Width || pbPic.Height > panel1.Height)
            //    {
            //        pbPic.Dock = DockStyle.Fill;
            //        pbPic.SizeMode = PictureBoxSizeMode.Zoom;

            //    }
            //    else
            //    {
            //        pbPic.Dock = DockStyle.None;
            //        pbPic.SizeMode = PictureBoxSizeMode.AutoSize;
            //        pbPic.Top = (panel1.Height - pbPic.Height) / 2;
            //        pbPic.Left = (panel1.Width - pbPic.Width) / 2;
            //    }

            //}


            #endregion
                    }

        private void ShowPicInMatchMode(bool isPicOverPanel)
        {
            
            pbPic.Dock = DockStyle.Fill;
            pbPic.SizeMode = PictureBoxSizeMode.Zoom;

            if (isPicOverPanel)
            {
                pbPic.Cursor = Cursors.Default;
                canDrag = false;
                pbAerialView.Visible = false;
            }
            else
            {
                pbPic.Top = (panel1.Height - pbPic.Height) / 2;
                pbPic.Left = (panel1.Width - pbPic.Width) / 2;
                pbPic.Cursor = Cursors.Default;
                canDrag = false;
                pbAerialView.Visible = false;
            }
        }

        private void ShowPicInNormalMode(bool isPicOverPanel)
        {
           
                pbPic.Dock = DockStyle.None;
                pbPic.SizeMode = PictureBoxSizeMode.AutoSize;
                pbPic.Top = (panel1.Height - pbPic.Height) / 2;
                pbPic.Left = (panel1.Width - pbPic.Width) / 2;
                if (isPicOverPanel)
                {
                    pbPic.Cursor = Cursors.Hand;
                    canDrag = true;
                    
                    pbAerialView.Visible = true;
                    pbAerialView.Image = bmpAerialInpb;
                }
                else
                {
                    pbPic.Cursor = Cursors.Default;
                    canDrag = false;
                    pbAerialView.Visible = false;
                }
        }

        private void tsBtnNormal_Click(object sender, EventArgs e)
        {
           IsPicOverPanel = bmpInpb.Width > panel1.Width || bmpInpb.Height > panel1.Height ? true : false;
            ShowPicInNormalMode(IsPicOverPanel);
        }

        private void tsBtnMatch_Click(object sender, EventArgs e)
        {
            IsPicOverPanel = bmpInpb.Width > panel1.Width || bmpInpb.Height > panel1.Height ? true : false;
            ShowPicInMatchMode(IsPicOverPanel);
        }

        private void pbPic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button!=MouseButtons.Left)
            {
                return;
            }
            isDraging = true;
            mouseOnPressPoint.X = e.X;
            mouseOnPressPoint.Y = e.Y;
            pbOnMousePressPoint.X = pbPic.Left;
            pbOnMousePressPoint.Y = pbPic.Top;

        }

        private void pbPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDraging||!canDrag)
            {
                return;
            }
            // 左右移动
            int tempx = pbPic.Left;
            if (pbPic.Width>panel1.Width)
            {
                tempx = tempx + (e.X - mouseOnPressPoint.X);
                if (tempx>0)
                {
                    tempx = 0;
                }
                else
                {
                    if (tempx+pbPic.Width<panel1.Width)
                    {
                        tempx = panel1.Width - pbPic.Width;
                    }
                }

                int tempy= pbPic.Top;
                if (pbPic.Height > panel1.Height)
                {
                    tempy = tempy + (e.Y - mouseOnPressPoint.Y);
                    if (tempy > 0)
                    {
                        tempy = 0;
                    }
                    else
                    {
                        if (tempy + pbPic.Height < panel1.Height)
                        {
                            tempy = panel1.Height - pbPic.Height;
                        }
                    }
                }
                pbPic.Left = tempx;
                pbPic.Top = tempy;
            }

         


        }

        private void pbPic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button!=MouseButtons.Left)
            {
               return;;
            }
            isDraging = false;
        }

        private void tsBtnReturn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pbPic.Image=null;
            if (bmpInpb!=null)
            {
                bmpInpb.Dispose();
                
            }
            EnterShowThumbnailListMode();
        }

        private void tsBtnPrevious_Click(object sender, EventArgs e)
        {
           
            if (bmpIndex==0)
            {
                bmpIndex = lsvView.Items.Count - 1;
            }
            else
            {
                bmpIndex--;
            }
            ListViewItem item = lsvView.Items[bmpIndex];
            PaintImageInpb(item.Text);
        }

        private void tsBtnNext_Click(object sender, EventArgs e)
        {
            if (bmpIndex == lsvView.Items.Count-1)
            {
                bmpIndex = 0;
            }
            else
            {
                bmpIndex++;
            }
            ListViewItem item = lsvView.Items[bmpIndex];
            PaintImageInpb(item.Text);
        }

        private void tsBtnPlay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            tsBtnPlay.Checked = timer1.Enabled;
        }

        private void tscbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string timeinterval = tscbInterval.SelectedItem.ToString();
            switch (timeinterval)
            {

                case "8 s":
                    timer1.Interval = 8000;
                    break;
                case "5 s":
                    timer1.Interval = 5000;
                    break;
                
                case "1 s":
                    timer1.Interval = 1000;
                    break;
                
                default:
                    timer1.Interval = 3000;
                    break;
                    
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsBtnNext_Click(null,null);
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbtnDelFolder_Click(object sender, EventArgs e)
        {
            if (lstFolder.SelectedItems.Count==0)
            {
                MessageBox.Show("请先选择一个目录后再执行删除操作!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dr = MessageBox.Show("删除目录将导致该目录下所有图片将被删除,且不可恢复!是否继续吗?", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string delFolderName = "";
            if (dr==DialogResult.Yes)
            {
                lsvView.Clear();
                delFolderName = lstFolder.Text;
                ((Folder)lstFolder.SelectedItem).RemoveDIR();
                lstFolder.Items.Remove(lstFolder.SelectedItem);
                statusStrip1.Items[1].Text = "目录 “ " + delFolderName + "”已经成功删除！";
            }
            else
            {
                statusStrip1.Items[1].Text = "已放弃删除目录 ！";
            }


        }

        private void tsbtnDelPic_Click(object sender, EventArgs e)
        {
            if (lsvView.SelectedItems.Count==0||lstFolder.SelectedItems.Count==0||lsvView.Visible==false)
            {
                return;
            }

            Folder folder = (Folder) lstFolder.SelectedItem;
            try
            {
                lsvView.BeginUpdate();
                while (lsvView.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvView.SelectedItems[0];
                    lsvView.Items.Remove(item);
                    folder.Remove(item.Text);
                    statusStrip1.Items[1].Text = "图片 “ " + item.Text + "”已经成功删除！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              
            }
            finally
            {
                lsvView.EndUpdate();
            }
        }


        private FrmLoadPic frmLoadPic1;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmLoadPic1==null)
            {
                frmLoadPic1 = new FrmLoadPic(this.lstFolder, this.statusStrip1);
            }

                foreach (Control c in frmLoadPic1.Controls)
                {
                    if (c is CheckedListBox)
                    {
                        ((CheckedListBox)c).Items.Clear();
                    }
                }
                if (frmLoadPic1.ShowDialog(this) == DialogResult.OK)
                {
                    LoadToListView();
                }
          

        }







    }
}
