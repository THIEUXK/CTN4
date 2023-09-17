namespace CTN4.Models
{
    public class PhuongThucThanhToan
    {
        public Guid Id { get; set; }
        public string TenPhuongThuc { get; set; }
        public bool TrangThai { get; set; }
        public List<HoaDon> HoaDones { get; set; }
    }
}
