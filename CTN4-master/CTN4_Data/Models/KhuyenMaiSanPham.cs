namespace CTN4_Data.Models.DB_CTN4
{
    public class KhuyenMaiSanPham
    {
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdkhuyenMai { get; set; }

        public virtual SanPham? SanPham { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
    }
}
