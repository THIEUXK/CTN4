using CTN4_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ILichSuHoaDonService
    {
        public List<LichSuHoaDon> GetAll();
        public LichSuHoaDon GetById(Guid id);
        public bool Them(LichSuHoaDon a);
        public bool Sua(LichSuHoaDon a);
        public bool Xoa(Guid id);
    }
}
