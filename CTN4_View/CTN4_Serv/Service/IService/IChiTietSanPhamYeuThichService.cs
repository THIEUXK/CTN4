using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IChiTietSanPhamYeuThichService
    {
        public List<ChiTietSanPhamYeuThich> GetAll();
        public ChiTietSanPhamYeuThich GetById(Guid id);
        public bool Them(ChiTietSanPhamYeuThich a);
        public bool Sua(ChiTietSanPhamYeuThich a);
        public bool Xoa(Guid id);
    }
}
