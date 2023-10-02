using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IChucVuService
    {
        public List<ChucVu> GetAll();
        public ChucVu GetById(Guid id);
        public bool Them(ChucVu a);
        public bool Sua(ChucVu a);
        public bool Xoa(Guid id);
    }
}
