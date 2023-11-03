using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IPhanLoaiService
    {
        public List<PhanLoai> GetAll();
        public PhanLoai GetById(Guid id);
        public bool Them(PhanLoai a);
        public bool Sua(PhanLoai a);
        public bool Xoa(Guid id);
    }
}
