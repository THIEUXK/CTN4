using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IPhuongThucThanhToanService
    {
        public List<PhuongThucThanhToan> GetAll();
        public PhuongThucThanhToan GetById(Guid id);
        public bool Them(PhuongThucThanhToan a);
        public bool Sua(PhuongThucThanhToan a);
        public bool Xoa(Guid id);
    }
}
