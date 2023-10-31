namespace CTN4_Data.Models.DB_CTN4
{
    public class SanPhamChiTiet
    {
        public Guid Id { get; set; }
        public int SoLuong { get; set; }
        public bool Is_detele { get; set; }
        public bool TrangThai { get; set; }
        public Guid? IdMau { get; set; }
        public Guid? IdSize { get; set; }
        public Guid? IdSp { get; set; }
        public virtual List<Anh>? Anhs { get; set; }
        public virtual Mau? Mau { get; set; }
        public virtual Size? Size { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual List<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
        public virtual List<GioHangChiTiet>? GioHangChiTiets { get; set; }
    }
}
