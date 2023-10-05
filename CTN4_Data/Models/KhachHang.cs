﻿using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại chỉ chấp nhận số")]
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string AnhDaiDien { get; set; }
        public bool Trangthai { get; set; }
        public bool Is_detele { get; set; }

        public List<HoaDon> HoaDon { get; set; }
        public List<GioHang> GioHang { get; set; }
        public List<SanPhamYeuThich> SanPhamYeuThiches { get; set; }
        public List<DiaChiNhanHang> DiaChiNhanHangs { get; set; }
    }
}
