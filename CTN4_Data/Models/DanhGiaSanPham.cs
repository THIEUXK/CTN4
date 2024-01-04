using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Data.Models
{
    public class DanhGiaSanPham
    {
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdKhachHang { get; set; }
        public string BinhLuan { get; set; }
        public int SoSao { get; set; }
        public bool TrangThaiDuyet { get; set; }
        public bool TrangThaiAnHien { get; set; }
        public bool Is_delete { get; set; }
        public DateTime ThoiGian { get; set; }
        public int SoSua { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
