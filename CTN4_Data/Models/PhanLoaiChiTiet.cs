namespace CTN4_Data.Models.DB_CTN4
{
    public class PhanLoaiChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdPhanLoai { get; set; }

        public PhanLoai? PhanLoai { get; set; }
        public SanPhamChiTiet? SanPhamChiTiet { get; set; }
    }
}
