
namespace CTN4_Data.Models.DB_CTN4
{
    public class HoaDon
    {
        public int Id { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime? NgayTaoHoaDon { get; set; }
        public string TrangThai { get; set; }
        public float? TongTien { get; set; }
        public float? TienShip { get; set; }
        public float? TienGiam { get; set; }
        public float? TienHang { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string? TenKhachHang { get; set; }
        public string? Email { get; set; }
        public string? SDTNguoiNhan { get; set; }
        public string? DiaChi { get; set; }
        public string? GhiChu { get; set; }
        public bool Is_detele { get; set; }
        public bool TrangThaiThanhToan { get; set; }
        public Guid? IdKhachHang { get; set; }
        public Guid? IdPhuongThuc { get; set; }
        public Guid? IdDiaChiNhanHang { get; set; }
        public virtual List<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
        public virtual List<LichSuDonHang>? LichSuDonHangs { get; set; }
        public virtual List<GiamGiaChiTiet>? GiamGiaChiTiets { get; set; }
        public virtual PhuongThucThanhToan? PhuongThucThanhToan { get; set; }
        public virtual DiaChiNhanHang? DiaChiNhanHang { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
    }
}
