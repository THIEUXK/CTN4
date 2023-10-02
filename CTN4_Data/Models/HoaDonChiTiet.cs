namespace CTN4_Data.Models.DB_CTN4
{
    public class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public int SoLuong { get; set; }
        public float GiaTien { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }

        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdHoaDon { get; set; }
        public HoaDon? HoaDon { get; set; }
        public SanPhamChiTiet? SanPhamChiTiet { get; set; }
    }
}
