using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IGioHangChiTietService
    {
        public List<GioHangChiTiet> GetAll();
        public GioHangChiTiet GetById(Guid id);
        public bool Them(GioHangChiTiet a);
        public bool Sua(GioHangChiTiet a);
        public bool Xoa(Guid id);
       
    }
}
