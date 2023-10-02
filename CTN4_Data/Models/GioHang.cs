namespace CTN4_Data.Models.DB_CTN4
{
    public class GioHang
    {
        public Guid Id { get; set; }
        public bool TrangThai { get; set; }
        public Guid IdNguoiDung { get; set; }
        public NguoiDung? NguoiDung { get; set;}
        public List<GioHangChiTiet> GGioHangChiTiets { get; set; }
    }
}
