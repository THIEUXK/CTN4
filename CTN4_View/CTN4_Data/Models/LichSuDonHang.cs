namespace CTN4_Data.Models.DB_CTN4
{
    public class LichSuDonHang
    {
        public Guid Id { get; set; }
        public string? ThaoTac { get; set; }
        public DateTime ThoiGianlam { get; set; }
        public string NguoiThucHien { get; set; }
        public string? GhiChu { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }

        public int IdHoaDonn { get; set; }
        public virtual HoaDon? HoaDon { get; set; }
    }
}
