using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ISanPhamChiTietService
    {
        public List<SanPhamChiTiet> GetAll();
        public List<SanPhamChiTiet> GetSanPhamChiTiets(Guid id);
        public SanPhamChiTiet GetById(Guid? id);
        public bool Them(SanPhamChiTiet a);
        public bool Sua(SanPhamChiTiet a);
        public bool Xoa(Guid ida);
    }
}
