using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageStudents.Entities;
namespace ManageStudents.Models
{
    class PhongBan
    {
        NHANSUEntities db = new NHANSUEntities();
        public tb_PHONGBAN getItem(string id)
        {
            return db.tb_PHONGBAN.FirstOrDefault(x => x.IDPB == id);
        }
        public List<tb_PHONGBAN> getList()
        {
            return db.tb_PHONGBAN.ToList();
        }
    }
}
