using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IKhuyenMaiPhanLoaiService
    {
        public List<KhuyenMaiPhanLoai> GetAll();
        public KhuyenMaiPhanLoai GetById(Guid id);
        public bool Them(KhuyenMaiPhanLoai a);
        public bool Sua(KhuyenMaiPhanLoai a);
        public bool Xoa(Guid id);
    }
}
