namespace CTN4_Data.Models.DB_CTN4
{
    public class Size
    {
        public Guid Id { get; set; }
        public string TenSize { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }
        public List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}
