using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IMauService
    {
        public List<Mau> GetAll();
        public Mau GetById(Guid id);
        public bool Them(Mau a);
        public bool Sua(Mau a);
        public bool Xoa(Guid id);
    }
}
