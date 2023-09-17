namespace CTN4.Models
{
    public class NSX
    {
        public Guid Id { get;set; }
        public string TenNSX{ get;set; }
        public bool TrangThai { get;set; }

        public List<SanPhamChiTiet> SnSanPhamChiTiets { get; set; }
    }
}
