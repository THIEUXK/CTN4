namespace CTN4_Data.Models.DB_CTN4
{
    public class DanhMucChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdDanhMuc { get; set; }
        public virtual DanhMuc? DanhMuc { get; set;}
        public virtual SanPhamChiTiet? SanPhamChiTiet { get; set; }
    }
}
