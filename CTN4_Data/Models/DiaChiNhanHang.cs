namespace CTN4_Data.Models.DB_CTN4
{
    public class DiaChiNhanHang
    {
        public Guid ID { get; set; }
        public string TenDiaChi { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThai { get; set; }
        public Guid? IdKhachHang { get; set; }
        public KhachHang? KhachHang { get; set;}
        public List<HoaDon> HoaDon { get; set; }
    }
}
