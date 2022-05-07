using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageStudents.Entities;
namespace ManageStudents.Models
{
    class NhanVien
    {
        NHANSUEntities db = new NHANSUEntities();
        public tb_NHANVIEN getItem(string id)
        {
            return db.tb_NHANVIEN.FirstOrDefault(x => x.ID == id);
        }
        public List<tb_NHANVIEN> getList()
        {
            return db.tb_NHANVIEN.ToList();
        }
        public List<tb_NHANVIEN> GetAll(string idpb) //lấy mã PhongBan trong DB của NhanVien
        {
            return db.tb_NHANVIEN.Where(x => x.IDPB == idpb).ToList();
        }
        public tb_NHANVIEN Add(tb_NHANVIEN nv)
        {
            try
            {
                db.tb_NHANVIEN.Add(nv);
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during data processing" +ex.Message);
            }
        }
        public tb_NHANVIEN UpDate(tb_NHANVIEN nv)
        {
            try
            {
                var _nv = db.tb_NHANVIEN.FirstOrDefault(x => x.ID == nv.ID);
                _nv.HOTEN = nv.HOTEN;
                _nv.NGAYSINH = nv.NGAYSINH;
                _nv.GIOITINH = nv.GIOITINH;
                _nv.HINHANH = nv.HINHANH;
                _nv.DIENTHOAI = nv.DIENTHOAI;
                _nv.DIACHI = nv.DIACHI;
                _nv.CCCD = nv.CCCD;
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during data processing" + ex.Message);
            }
        }
        public tb_NHANVIEN Delete(string id)
        {
            try
            {
                var _nv = db.tb_NHANVIEN.FirstOrDefault(x => x.ID == id);
                db.tb_NHANVIEN.Remove(_nv);
                db.SaveChanges();
                return _nv;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during data processing" + ex.Message);
            }
        }
    }
}