using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IDanhMucChiTietService
    {
        public List<DanhMucChiTiet> GetAll();
        public DanhMucChiTiet GetById(Guid id);
        public bool Them(DanhMucChiTiet a);
        public bool Sua(DanhMucChiTiet a);
        public bool Xoa(Guid id);
    }
}
