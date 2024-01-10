using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class Loginviewmodel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        [RegularExpression("^[a-zA-Z0-9]{8,30}$")]
        public string User { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [RegularExpression("^[a-zA-Z0-9]{8,30}$")]
        public string Password { get; set; } 
    }
}
