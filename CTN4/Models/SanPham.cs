﻿namespace CTN4.Models
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDiem { get; set; }
        public bool TrangThai { get; set; }
        public List<SanPhamChiTiet> SnSanPhamChiTiets { get; set; }

    }
}