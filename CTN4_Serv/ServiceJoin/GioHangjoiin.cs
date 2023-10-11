using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.ServiceJoin
{
    public class GioHangjoiin
    {
        public DB_CTN4_ok _db;

        public GioHangjoiin()
        {
            _db = new DB_CTN4_ok();
        }

        public List<GioHangChiTiet> GetAll()
        {
            return _db.GioHangChiTiets.ToList();
        }
        public GioHangChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }
    }
}
