namespace CTN4_Data.Models.DB_CTN4
{
    public class DanhMucChiTiet
    {
        public Guid ID { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdDanhMuc { get; set; }
        public DanhMuc? DanhMuc { get; set;}
        public SanPhamChiTiet? SanPhamChiTiet { get; set; }
    }
}
