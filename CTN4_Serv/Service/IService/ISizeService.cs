using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ISizeService
    {
        public List<Size> GetAll();
        public Size GetById(Guid id);
        public bool Them(Size a);
        public bool Sua(Size a);
        public bool Xoa(Guid id);
    }
}
