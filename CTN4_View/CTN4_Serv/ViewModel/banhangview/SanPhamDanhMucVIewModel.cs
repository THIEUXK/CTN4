using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel.banhangview
{
    public class SanPhamDanhMucVIewModel
    {
        public  Guid Id { get; set; }
        public Guid Idkm { get; set; }
        public string MaSp { get; set; }
        public string? TenKm { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public string TenDanhMuc { get; set; }
        public float GiaNhap { get; set; }
        public float GiaBan { get; set; }
        public float GiaNiemYet { get; set; }
    
    }
}
