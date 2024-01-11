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
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        [RegularExpression("^[a-zA-Z0-9]{8,30}$", ErrorMessage = "Vui lòng:")]
        public string User { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [RegularExpression("^[a-zA-Z0-9]{8,30}$", ErrorMessage = "Vui Lòng:")]
        public string Password { get; set; }

    }
}
