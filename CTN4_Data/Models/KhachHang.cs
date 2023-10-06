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
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string AnhDaiDien { get; set; }
        public bool Trangthai { get; set; }
        public bool Is_detele { get; set; }

        public virtual List<HoaDon>? HoaDon { get; set; }
        public virtual List<GioHang>? GioHang { get; set; }
        public virtual List<SanPhamYeuThich>? SanPhamYeuThiches { get; set; }
        public virtual List<DiaChiNhanHang>? DiaChiNhanHangs { get; set; }
    }
}
