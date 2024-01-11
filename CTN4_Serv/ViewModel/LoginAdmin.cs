using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class LoginAdmin
    {
        [Required(ErrorMessage = "Username is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        [RegularExpression("^[a-zA-Z0-9]{8,31}$", ErrorMessage = "Vui lòng nhập đúng đầu vào")]
        public string Password { get; set; }
    }
}
