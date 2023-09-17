namespace CTN4.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime NgayTaoHoaDon { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
        public float TongTien { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime NgayNhan { get; set; }
        public Guid? IdGiamGia { get; set; }
        public Guid? IdPhuongThuc { get;set; }

        public List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public GiamGia? GiamGia { get; set; }
        public PhuongThucThanhToan? PhuongThucThanhToan { get; set; }
        public NguoiDung? NguoiDung { get; set;}
    }
}
