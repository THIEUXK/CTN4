using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IphanLoaiChiTietService
    {
        public List<PhanLoaiChiTiet> GetAll();
        public PhanLoaiChiTiet GetById(Guid id);
        public bool Them(PhanLoaiChiTiet a);
        public bool Sua(PhanLoaiChiTiet a);
        public bool Xoa(Guid id);
    }
}
