using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface INhanVienService
    {
        public List<NhanVien> GetAll();
        public NhanVien GetById(Guid id);
        public bool Them(NhanVien a);
        public bool Sua(NhanVien a);
        public bool Xoa(NhanVien a);
    }
}
