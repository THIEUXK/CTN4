namespace CTN4_Data.Models.DB_CTN4
{
    public class GioHang
    {
        public Guid Id { get; set; }
        public bool TrangThai { get; set; }
        public Guid? IdKhachHang { get; set; }
        public KhachHang? KhachHang { get; set;}
        public List<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
