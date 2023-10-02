namespace CTN4_Data.Models.DB_CTN4
{
    public class Mau
    {
        public Guid Id { get; set; }
        public string TenMau { get; set; }
        public bool TrangThai { get; set; }
        public List<SanPhamChiTiet> SnSanPhamChiTiets { get; set; }
    }
}
