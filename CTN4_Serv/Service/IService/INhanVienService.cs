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
        public List<NhanVien> GetAlls();
        public NhanVien GetById(Guid id);
		public NhanVien GetByIdChucVu(Guid id);
		public bool Them(NhanVien a);
        public bool Sua(NhanVien a);
        public bool Xoa(Guid id);
    }
}
