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
        [Required(ErrorMessage = "Username is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression("^[a-zA-Z0-9]{8,16}$", ErrorMessage = "Username must be 8 to 16 alphanumeric characters.")]
        public string Password { get; set; } 
    }
}
