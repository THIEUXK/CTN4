using CTN4_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.Service.IService
{
    public interface ILichSuHoaDonService
    {
        public List<LichSuDonHang> GetAll();
        public LichSuDonHang GetById(Guid id);
        public int[] Thongkels();
        public bool Them(LichSuDonHang a);
        public bool Sua(LichSuDonHang a);
        public bool Xoa(Guid id);
    }
}
