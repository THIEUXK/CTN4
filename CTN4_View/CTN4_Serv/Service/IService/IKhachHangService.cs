using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IKhachHangService
    {
        public List<KhachHang> GetAll();
        public KhachHang GetById(Guid id);
        public bool Them(KhachHang a);
        public bool Sua(KhachHang a);
        public bool Xoa(Guid id);
    }
}
