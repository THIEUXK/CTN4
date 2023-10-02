using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ISanPhamService
    {
        public List<SanPham> GetAll();
        public SanPham GetById(Guid id);
        public bool Them(SanPham a);
        public bool Sua(SanPham a);
        public bool Xoa(SanPham a);
    }
}
