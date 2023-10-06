namespace CTN4_Data.Models.DB_CTN4
{
    public class DiaChiNhanHang
    {
        public Guid Id { get; set; }
        public string TenDiaChi { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThai { get; set; }
        public Guid? IdKhachHang { get; set; }
        public virtual KhachHang? KhachHang { get; set;}
        public virtual List<HoaDon>? HoaDon { get; set; }
    }
}
