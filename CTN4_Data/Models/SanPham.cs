namespace CTN4_Data.Models.DB_CTN4
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDiem { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }

    }
}
