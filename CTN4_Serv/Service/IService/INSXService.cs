using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface INSXService
    {
        public List<NSX> GetAll();
        public NSX GetById(Guid id);
        public bool Them(NSX a);
        public bool Sua(NSX a);
        public bool Xoa(Guid id);
    }
}
