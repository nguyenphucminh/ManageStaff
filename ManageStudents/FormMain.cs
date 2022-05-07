using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ManageStudents.Entities;
using ManageStudents.Models;
namespace ManageStudents
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        bool Them;
        PhongBan _phongban;
        NhanVien _nhanvien;
        private void FormMain_Load(object sender, EventArgs e)
        {
            _phongban = new PhongBan();
            _nhanvien = new NhanVien();
            Enable();
            Enable(false);


            cbbPB.DataSource = _phongban.getList();
            cbbPB.DisplayMember = "TENPB";
            cbbPB.ValueMember = "IDPB";

            LoadData();

            cbbPB.SelectedIndexChanged += cbbPB_SelectedIndexChanged;
            LoadNSByPB();
        }
        //============================================================================================
        void LoadNSByPB()
        {
            gcNhanVien.DataSource = _nhanvien.GetAll(cbbPB.SelectedValue.ToString()) ; 
            gvNhanVien.OptionsBehavior.Editable = false;
        }
        void Enable(bool t) //Làm mờ các textbox, khi chọn sẽ hiện sáng lên
        {
            txtName.Enabled = t;
            txtCCCD.Enabled = t;
            txtPhone.Enabled = t;
            txtID.Enabled = t;
            txtAddress.Enabled = t;
            checkEdit1.Enabled = t;
            cbbSex.Enabled = t;
            datetimeB.Enabled = t;
            btnBrowse.Enabled = t;
        }
        void Reset() // Reset các textbox để thêm mới KHACHHANG mới
        {
            txtID.Text = "";
            txtName.Text = "";
            txtCCCD.Text = "";
            txtPhone.Text = "";
            cbbPB.Text = "";
            txtAddress.Text = "";
            checkEdit1.Enabled = true;
            cbbSex.Enabled = true;
            picture.Image = Properties.Resources._123;
        }
        void LoadData()
        {
            gcNhanVien.DataSource = _nhanvien.getList();
            gvNhanVien.OptionsBehavior.Editable = false;
        }
        void Enable()     //
        {
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility= DevExpress.XtraBars.BarItemVisibility.Never;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }
        void Disable()
        {
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        bool STT(Int32 _width, GridView _view)
        {
            _view.IndicatorWidth = _view.IndicatorWidth < _width ? _width : _view.IndicatorWidth;
            return true;
            //gvPhongEmpty : CustomDrawRowIndicator
        }

        //============================================================================================
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Enable(true);
            Reset();
            Them = true;
            Disable();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Enable(true);
            Them = false;
            Disable();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete this item?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _nhanvien.Delete(gvNhanVien.GetFocusedRowCellValue("ID").ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during data processing" + ex.Message);
            }


            LoadData();
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Them == true)
            {
                tb_NHANVIEN nv = new tb_NHANVIEN();
                nv.ID = txtID.Text;
                nv.HOTEN = txtName.Text;
                nv.GIOITINH = cbbSex.Text;
                nv.NGAYSINH = datetimeB.Value;
                nv.CCCD = txtCCCD.Text;
                nv.DIENTHOAI = txtPhone.Text;
                nv.DIACHI = txtAddress.Text;
                nv.HINHANH = ImageToBase64(picture.Image, picture.Image.RawFormat);
                nv.IDPB = cbbPB.SelectedValue.ToString();
                _nhanvien.Add(nv);
            }    
            else //Them == false 
            {
                tb_NHANVIEN nv = _nhanvien.getItem(gvNhanVien.GetFocusedRowCellValue("ID").ToString() );
                nv.ID = txtID.Text;
                nv.HOTEN = txtName.Text;
                nv.GIOITINH = cbbSex.Text;
                nv.NGAYSINH = datetimeB.Value;
                nv.CCCD = txtCCCD.Text;
                nv.DIENTHOAI = txtPhone.Text;
                nv.DIACHI = txtAddress.Text;
                nv.HINHANH = ImageToBase64(picture.Image, picture.Image.RawFormat);
                nv.HINHANH = ImageToBase64(picture.Image, picture.Image.RawFormat);
                _nhanvien.UpDate(nv);
            }    
            Them = false;
            Enable(false);
            Enable();
            LoadData();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtID.Enabled = false;
            Enable(false);
            Enable();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png .jpg)| *.png; *.jpg";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                picture.Image = Image.FromFile(openFile.FileName);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }    
        }
        //Hàm chuyển đổi hình ảnh lưu vào Database
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {

            //Convert Image to byte[]
            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                return imageBytes;
            }
        }
        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void gvNhanVien_Click(object sender, EventArgs e)
        {
            if (gvNhanVien.GetFocusedRowCellValue("ID") != null)
            {
                var nv = _nhanvien.getItem(gvNhanVien.GetFocusedRowCellValue("ID").ToString());
                txtID.Text = nv.ID.ToString();
                txtName.Text = nv.HOTEN.ToString();
                txtPhone.Text = nv.DIENTHOAI.ToString();
                txtCCCD.Text = nv.CCCD.ToString();
                txtAddress.Text = nv.DIACHI.ToString();
                cbbSex.Text = nv.GIOITINH.ToString();
                if(nv.HINHANH != null)
                {
                    picture.Image = Base64ToImage(nv.HINHANH);
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                }   
            }
        }

        private void cbbPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNSByPB();
        }

        private void gvNhanVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvNhanVien.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu không phải là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //STT tăng dần
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { STT(_width, gvNhanVien); })); //tăng kích thước lên nếu vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * (-1))); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { STT(_width, gvNhanVien); })); //tăng kích thước lên nếu vượt quá
            }
        }

        private void picture_Click(object sender, EventArgs e)
        {
            var nv = _nhanvien.getItem(gvNhanVien.GetFocusedRowCellValue("ID").ToString());
            FullScreen FS = new FullScreen(Base64ToImage(nv.HINHANH),nv.HOTEN);
            FS.ShowDialog();
        }
    }
}
