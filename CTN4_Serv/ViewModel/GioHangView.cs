using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.ViewModel
{
    public class GioHangView
    {
        public List<GioHangChiTiet> GioHangChiTiets { get; set; }
        public float TongTien { get; set; }

        public Guid idGH { get; set; }
        public float TongTienGioHang { get; set; }
    }
}
