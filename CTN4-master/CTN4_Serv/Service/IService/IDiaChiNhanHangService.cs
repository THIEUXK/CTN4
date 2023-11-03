using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IDiaChiNhanHangService
    {
        public List<DiaChiNhanHang> GetAll();
        public DiaChiNhanHang GetById(Guid id);
        public bool Them(DiaChiNhanHang a);
        public bool Sua(DiaChiNhanHang a);
        public bool Xoa(Guid id);

    }
}
