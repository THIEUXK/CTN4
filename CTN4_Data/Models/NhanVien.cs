namespace CTN4_Data.Models.DB_CTN4
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool Trangthai { get; set; }
        public string AnhDaiDien { get; set; }
        public Guid? IdChucVu { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
    }
}
