namespace CTN4_Data.Models.DB_CTN4
{
    public class PhanLoaiChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdPhanLoai { get; set; }

        public virtual PhanLoai? PhanLoai { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
