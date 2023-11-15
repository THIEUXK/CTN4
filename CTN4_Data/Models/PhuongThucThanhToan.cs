namespace CTN4_Data.Models.DB_CTN4
{
    public class PhuongThucThanhToan
    {
        public Guid Id { get; set; }
        public string TenPhuongThuc { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }
        public virtual List<HoaDon>? HoaDon { get; set; }
    }
}
