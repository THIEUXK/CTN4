namespace CTN4_Data.Models.DB_CTN4
{
    public class GioHangChiTiet
    {
        public Guid Id { get; set; }
        public int SoLuong { get; set; }
        public Guid? IdGioHang { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }

        public virtual GioHang? GioHang { get; set; }
        public virtual SanPhamChiTiet? SanPhamChiTiet { get; set; }
    }
}
