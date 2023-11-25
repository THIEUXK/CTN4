using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Nhập chính xác địa chỉ email")]
        public string Email { get; set; }
    }
}
