using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IHoaDonChiTietService
    {
        public List<HoaDonChiTiet> GetAll();
        public HoaDonChiTiet GetById(Guid id);
        public bool Them(HoaDonChiTiet a);
        public bool Sua(HoaDonChiTiet a);
        public bool Xoa(Guid id);
    }
}
