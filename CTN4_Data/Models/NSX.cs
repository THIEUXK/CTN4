namespace CTN4_Data.Models.DB_CTN4
{
    public class NSX
    {
        public Guid Id { get;set; }
        public string TenNSX{ get;set; }
        public bool TrangThai { get;set; }
        public string GhiChu { get;set; }
        public bool Is_detele { get; set; }

        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
