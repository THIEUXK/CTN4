using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Serv.ServiceJoin
{
    internal class ChiTietSanPhamJoin
    {
        public DB_CTN4_ok _db;
        public ChiTietSanPhamJoin()
        {
            _db = new DB_CTN4_ok();
        }

        public SanPhamChiTiet SanPhamChiTiet(Guid id)
        {
            return _db.SanPhamChiTiets.FirstOrDefault(c => c.Id == id);
        }

        public List<Anh> GetAllanh(Guid id)
        {
            return _db.Anhs.Where(c => c.IdSanPhamChiTiet == id).ToList();
        }
    }
}
