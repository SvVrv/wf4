using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string baseDir = "ImgBase";
            DirectoryInfo Dir = new DirectoryInfo(baseDir);
            if (!Dir.Exists)
                Dir.Create();
            foreach (ListViewItem item in lvImages.Items)
            {
                Bitmap newImage = ImageWorker.CreateImage(item.Text, 100, 100);
                newImage.Save(Dir.FullName+@"\" + Guid.NewGuid().ToString()+".jpg", ImageFormat.Jpeg);
            }


            DialogResult = DialogResult.OK;
        }


        ImageList imglist = new ImageList();
        private void btnAddImg_Click(object sender, EventArgs e)
        {
            string img = string.Empty;
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                img = dlg.FileName;
            ListViewItem lvi = new ListViewItem();
            lvi.Text = img;
            imglist.ImageSize = new Size(120, 120);
            imglist.Images.Add(Image.FromFile(img));
            lvi.ImageIndex = imglist.Images.Count - 1;
            lvImages.LargeImageList = imglist;
            lvImages.Items.Add(lvi);
        }

        private void btnDelImg_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvImages.SelectedItems)
                lvImages.Items.Remove(item);
        }

        private void AddProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Are you sure?");
            DialogResult = DialogResult.OK;
        }
    }
}
