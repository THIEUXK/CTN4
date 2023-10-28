namespace CTN4_Data.Models.DB_CTN4
{
    public class Mau
    {
        public Guid Id { get; set; }
        public string TenMau { get; set; }
        public string AnhMau { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }

        public Guid? IdSanPham { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }

        public virtual SanPham? sanPham { get; set; }
        public virtual SanPhamChiTiet? SanPhamChiTiets { get; set; }
    }
}
