using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Data.Models
{
    public class LichSuHoaDon
    {
        public Guid Id { get; set; }
        public int? IdHoaDon { get; set; }
        public string TenHanhDong { get; set; }
        public DateTime ThoiGiaoThaoTac { get; set; }
        public string NguoiThucHien { get; set; }
        public bool Is_detele { get; set; }
        public bool TrangThai { get; set; }
        public HoaDon? HoaDon { get; set; }
    }
}
