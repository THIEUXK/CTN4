namespace CTN4.Models
{
    public class GioHangChiTiet
    {
        public Guid Id { get; set; }
        public int SoLuong { get; set; }
        public Guid? IdGioHang { get; set; }
        public Guid? IdSanPham { get; set; }

    }
}
