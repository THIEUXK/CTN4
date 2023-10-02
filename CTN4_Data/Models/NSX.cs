namespace CTN4_Data.Models.DB_CTN4
{
    public class NSX
    {
        public Guid Id { get;set; }
        public string TenNSX{ get;set; }
        public bool TrangThai { get;set; }

        public List<SanPhamChiTiet> SnSanPhamChiTiets { get; set; }
    }
}
