using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IHoaDonService
    {
        public List<HoaDon> GetAll();
        public HoaDon GetById(int id);
        public bool Them(HoaDon a);
        public bool Sua(HoaDon a);
        public bool Xoa(int id);
    }
}
