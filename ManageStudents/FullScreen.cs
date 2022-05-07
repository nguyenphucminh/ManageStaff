using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageStudents
{
    public partial class FullScreen : DevExpress.XtraEditors.XtraForm
    {
        public FullScreen()
        {
            InitializeComponent();
        }

        public FullScreen(Image img, string hoten)
        {
            InitializeComponent();
            this._image = img;
            this._name = hoten;
        }
        Image _image;
        string _name;

        private void FullScreen_Load(object sender, EventArgs e)
        {
            pictureFS.Image = _image;
            pictureFS.SizeMode = PictureBoxSizeMode.StretchImage;
            groupNhanVien.Text = _name;
        }
    }
}