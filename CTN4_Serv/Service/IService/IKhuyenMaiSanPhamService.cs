using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IKhuyenMaiSanPhamService
    {
        public List<KhuyenMaiSanPham> GetAll();
        public KhuyenMaiSanPham GetById(Guid id);
        public bool Them(KhuyenMaiSanPham a);
        public bool Sua(KhuyenMaiSanPham a);
        public bool Xoa(Guid id);
    }
}
