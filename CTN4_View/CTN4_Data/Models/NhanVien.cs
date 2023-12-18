using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Tên là trường bắt buộc.")]
        public string Ho { get; set; }
        [Required(ErrorMessage = " Bắt buộc nhập.")]
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = " Bắt buộc nhập.")]
        [RegularExpression(@"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }
        [Required(ErrorMessage = " Bắt buộc nhập.")]
        public string SDT { get; set; }
        [Required(ErrorMessage = " Bắt buộc nhập.")]
        public string DiaChi { get; set; }
        public bool Trangthai { get; set; }
        public string AnhDaiDien { get; set; }
        public Guid? IdChucVu { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
    }
}
