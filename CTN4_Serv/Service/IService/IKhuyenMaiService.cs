using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IKhuyenMaiService
    {
        public List<KhuyenMai> GetAll();
        public KhuyenMai GetById(Guid id);
        public bool Them(KhuyenMai a);
        public bool Sua(KhuyenMai a);
        public bool Xoa(Guid id);
        public bool CapNhat(Guid id);
    }
}
