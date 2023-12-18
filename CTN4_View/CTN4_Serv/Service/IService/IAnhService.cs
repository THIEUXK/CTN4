using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.Service.IService
{
    public interface IAnhService
    {
        public List<Anh> GetAll();
        public Anh GetById(Guid id);
        public bool Them(Anh a);
        public bool Sua(Anh a);
        public bool Xoa(Guid id);
        public bool XoaBySP(Guid id);
    }
}