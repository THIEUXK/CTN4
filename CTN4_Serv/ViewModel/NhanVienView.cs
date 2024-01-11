using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class NhanVienView
    {
       public List<SelectListItem> selectListItemChucVus { get; set; }
       public NhanVien nhanViens { get; set; }
        public Guid Id { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(30, ErrorMessage = "Họ không được quá 30 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string Ho { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(30, ErrorMessage = "Tên không được quá 30 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string Ten { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(30, ErrorMessage = " không được quá 30 ký tự")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(30, ErrorMessage = " không được quá 30 ký tự")]
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = " Không được bỏ trống.")]
        [RegularExpression(@"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Số điện thoại phải có từ 10 đến 13 số")]
        [RegularExpression("^[0-9]{1,13}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "không được để trống")]
        [StringLength(100, ErrorMessage = " không được quá 100 ký tự")]
        public string DiaChi { get; set; }
        public bool Trangthai { get; set; }
        public string AnhDaiDien { get; set; }
        public Guid? IdChucVu { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
    }
}
