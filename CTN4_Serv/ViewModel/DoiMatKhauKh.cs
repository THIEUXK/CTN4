using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class DoiMatKhauKh
    { 
            [Required(ErrorMessage = "Mật khẩu cũ là bắt buộc")]
            public string matKhauCu { get; set; }

            [Required(ErrorMessage = "Mật khẩu mới là bắt buộc")]
            [StringLength(30, MinimumLength = 8, ErrorMessage = "Mật khẩu mới phải từ 8 đến 30 ký tự")]
            public string MatKhauMoi { get; set; }

            [Compare("MatKhauMoi", ErrorMessage = "Xác nhận mật khẩu mới không khớp")]
            public string xacNhanMatKhauMoi { get; set; }
    }
}
