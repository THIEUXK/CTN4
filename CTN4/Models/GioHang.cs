namespace CTN4.Models
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
