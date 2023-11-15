using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IGiamGiaService
    {
        public List<GiamGia> GetAll();
        public GiamGia GetById(Guid id);
        public bool Them(GiamGia a);
        public bool Sua(GiamGia a);
        public bool Xoa(Guid id); 
        public int Laygiamgia();

    }
}
