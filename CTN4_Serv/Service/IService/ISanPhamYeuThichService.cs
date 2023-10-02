using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ISanPhamYeuThichService
    {
        public List<SanPhamYeuThich> GetAll();
        public SanPhamYeuThich GetById(Guid id);
        public bool Them(SanPhamYeuThich a);
        public bool Sua(SanPhamYeuThich a);
        public bool Xoa(SanPhamYeuThich a);
    }
}
