using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Họ không được để trống")]
        [StringLength(100, ErrorMessage = "Họ không được quá 30 ký tự")]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không được quá 30 ký tự")]
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters")]
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không được quá 30 ký tự")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không được quá 30 ký tự")]
        public string DiaChi { get; set; }
        public string AnhDaiDien { get; set; }
        public bool Trangthai { get; set; }
        public bool Is_detele { get; set; }

        public virtual List<HoaDon>? HoaDon { get; set; }
        public virtual List<GioHang>? GioHang { get; set; }
        public virtual List<ChiTietSanPhamYeuThich>? ChiTietSanPhamYeuThiches { get; set; }
        public virtual List<DiaChiNhanHang>? DiaChiNhanHangs { get; set; }
    }
}
