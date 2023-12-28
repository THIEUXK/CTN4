using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Viewmodel
{
    public class EditGiamGiaViewModel
    {
        public GiamGia GiamGia { get; set; }
        public bool IsReadOnly { get; set; }
    }

    // Trong Controller

}
