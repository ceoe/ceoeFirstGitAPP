using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PicSeeNav
{
    public partial class FrmLoadPic : Form
    {
        
        
        public FrmLoadPic()
        {
            InitializeComponent();
        }

        private ListBox lstFolder;
        private StatusStrip staMsg;
        private void FrmLoadPic_Load(object sender, EventArgs e)
        {
            foreach (object o in lstFolder.Items)
            {
                if (!cbFolder.Items.Contains(o))
                {
                    cbFolder.Items.Add(o);
                }
                
            }
            if (lstFolder.SelectedItems.Count != 0)
            {
                cbFolder.SelectedIndex = lstFolder.SelectedIndex;
            }
            else
            {
                cbFolder.SelectedIndex = 0;
            }
        }

        public FrmLoadPic(ListBox lst, StatusStrip sta)
        {
            InitializeComponent();
        
            
            lstFolder = lst;
            staMsg = sta;
            openFileDialogSelPic.Filter = "图片文件(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            //|*.BMP;*.JPG;*.GIF;*.JPEG;*.ICO

        }


        

        private void btnSelPic_Click(object sender, EventArgs e)
        {
            if (openFileDialogSelPic.ShowDialog()==DialogResult.OK)
            {
                foreach (string  ss in openFileDialogSelPic.FileNames)
                {
                    if (!chklsPics.Items.Contains(ss)&&PicInfo.IsImage(ss))
                    {
                        PicInfo picInfo=new PicInfo(ss);
                        chklsPics.Items.Add(picInfo, true);

                    }
                }
            }
        }

        private void chklsPics_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPicName.Text = ((PicInfo)chklsPics.SelectedItem).NameNoExtesion;
        }

        private void btnUpdateName_Click(object sender, EventArgs e)
        {
            if (chklsPics.SelectedItems.Count!=0)
            {
                ((PicInfo)chklsPics.SelectedItem).NameNoExtesion = txtPicName.Text;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chklsPics.Items.Count==0)
            {
                return; ;
            }
            ArrayList  names=new ArrayList();
            Folder folder = (Folder) (cbFolder.SelectedItem);
            if (!folder.IsLoad)
            {
                folder.ReadDirPicFileAndCreatThumbAddToBmps(folder.SourcePicDir);
            }
            string path = folder.SourcePicDir;
            names.AddRange(Directory.GetFiles(path));

            for (int i = 0; i < names.Count; i++)
            {
                names[i] = Path.GetFileNameWithoutExtension((string) names[i]).ToUpper();
            }
            names.Sort();

            ToolStripProgressBar bar = staMsg.Items[0] as ToolStripProgressBar;
            

            bar.Visible = true;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                int i = 1;
                int count = chklsPics.Items.Count;
                foreach (PicInfo pic in chklsPics.Items)
                {
                    staMsg.Items[1].Text = "";
                    string name = CheckDuplicatFileAndPlaceToList(pic.NameNoExtesion, names);
                    string copyToDstPathName = folder.SourcePicDir + "\\" + name + pic.GetExtesion();
                    staMsg.Items[1].Text = "Copy file To:   "+ copyToDstPathName;
                    File.Copy(pic.FullName, copyToDstPathName);
                    folder.GeneratThumbToSaveAndLoadtoBmpsFromaName(copyToDstPathName);
                    bar.Value = 100*i/count;
                    i++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bar.Visible = true;
                this.Cursor = Cursors.Default;

            }

            int index = lstFolder.SelectedIndex;
            if (cbFolder.SelectedIndex!=index)
            {
                cbFolder.SelectedIndex = index;
            }
            this.DialogResult = DialogResult.OK;
            ;
        }

        private string CheckDuplicatFileAndPlaceToList(string aName, ArrayList  list)
        {
            int nameExtesion = 0;
            string tempName = aName;
            int listCount = list.Count;
            for (int i = 0; i < listCount; i++)
            {
                string existName = list[i] as string;
                if (tempName.ToUpper().CompareTo(existName)==0)
                {
                    nameExtesion++;
                    tempName = Path.GetFileNameWithoutExtension(tempName) + "-" + nameExtesion.ToString();
                }
                if (tempName.ToUpper().CompareTo(existName)==-1)
                {
                    list.Insert(i,tempName);
                    break;
                }
                if (i==listCount-1)
                {
                    list.Add(tempName);
                    break;
                }
            }
            return tempName;
        }

        private void btnClearchklst_Click(object sender, EventArgs e)
        {
            chklsPics.ClearSelected();
            chklsPics.Items.Clear();
        }


    }
}
