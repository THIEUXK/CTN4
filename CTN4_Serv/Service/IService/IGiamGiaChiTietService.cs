using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IGiamGiaChiTietService
    {
        public List<GiamGiaChiTiet> GetAll();
        public GiamGiaChiTiet GetById(Guid id);
        public bool Them(GiamGiaChiTiet a);
        public bool Sua(GiamGiaChiTiet a);
        public bool Xoa(Guid id);
    }
}
