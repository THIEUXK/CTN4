namespace CTN4.Models
{
    public class GiamGia
    {
        public Guid Id { get; set; }
        public string MaGiam { get; set; }
        public float SoTienGiam { get; set; }
        public int PhanTramGiam { get; set; }
        public bool TrangThai { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public List<HoaDon> HoaDon { get; set; }
    }
}
