using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class PhuongThucThanhToanview
    {
         public List<PhuongThucThanhToan> tenphuongThucs{ get; set; }
          public Guid Id { get; set; }
        public string TenPhuongThuc { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }
        public virtual List<HoaDon>? HoaDon { get; set; }
    }
}
