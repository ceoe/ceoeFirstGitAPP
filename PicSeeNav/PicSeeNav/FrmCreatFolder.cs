using System;
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
    public partial class FrmCreatFolder : Form
    {
        private ListBox lstFolder;
        public FrmCreatFolder()
        {
            InitializeComponent();
        }

        public FrmCreatFolder(ListBox  lst)
        {
          
            InitializeComponent();
            lstFolder = lst;
            
      
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtFolderName.Text=="")
            {
                MessageBox.Show(" 请输入要新建的目录名称!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string path = Application.StartupPath + "\\图片目录\\" + txtFolderName.Text;

                if (Directory.Exists(path))
                {
                    MessageBox.Show("该目录已经存在,请输入其他目录名称!", "错误对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Directory.CreateDirectory(path);
                Folder folder = new Folder(Application.StartupPath, txtFolderName.Text);
                lstFolder.Items.Add(folder);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误对话框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
            
        }
    }
}
