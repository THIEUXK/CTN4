using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IDanhMucService
    {
        public List<DanhMuc> GetAll();
        public DanhMuc GetById(Guid id);
        public bool Them(DanhMuc a);
        public bool Sua(DanhMuc a);
        public bool Xoa(Guid id);
    }
}
