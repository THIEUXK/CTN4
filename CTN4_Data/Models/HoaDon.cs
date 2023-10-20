namespace CTN4_Data.Models.DB_CTN4
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime NgayTaoHoaDon { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
        public float TongTien { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public DateTime? NgayNhan { get; set; }
        public Guid? IdKhachHang { get; set; }
        public Guid? IdPhuongThuc { get;set; }
        public Guid? IdDiaChiNhanHang { get; set; }

        public virtual List<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
        public virtual List<GiamGiaChiTiet>? GiamGiaChiTiets { get; set; }
        public virtual PhuongThucThanhToan? PhuongThucThanhToan { get; set; }
        public virtual DiaChiNhanHang? DiaChiNhanHang { get; set;}
        public virtual KhachHang? KhachHang { get; set;}
    }
}
