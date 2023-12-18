using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IGioHangService
    {
        public List<GioHang> GetAll();
        public int slsanpham();
        public GioHang GetById(Guid id);
        public bool Them(GioHang a);
        public bool Sua(GioHang a);
        public bool Xoa(Guid id);
        public bool Clean(Guid idKH);
    }
}
