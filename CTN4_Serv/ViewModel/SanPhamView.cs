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
    public class SanPhamView
    {
        [Required(ErrorMessage = " không được để trống")]
        public List<SelectListItem> ChalieuItems { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        public List<SelectListItem> NsxItems { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public SanPham sanPham { get; set; }
        public Guid Id { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        public Guid? IdChatLieu { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        public Guid? IdNSX { get; set; }
        [Required(ErrorMessage = " không được để trống")]


        [StringLength(30, ErrorMessage = " Mã sản phẩm không được quá 30 ký tự")]
        public string MaSp { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        [MaxLength(50, ErrorMessage = "Tên sản phẩm không được quá 50 ký tự")]
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public bool TrangThai { get; set; }

        public string? MoTa { get; set; }
        [Required(ErrorMessage = "Giá nhập vào không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá nhập vào phải lớn hơn hoặc bằng 0.")]
        public float GiaNhap { get; set; }
        [Required(ErrorMessage = "Giá bán ra không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá bán ra phải lớn hơn hoặc bằng 0.")]
        public float GiaBan { get; set; }
        [Required(ErrorMessage = "Giá niêm yết không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá niêm yết phải lớn hơn hoặc bằng 0.")]
        public float GiaNiemYet { get; set; }
        public string? GhiChu { get; set; }
        public bool Is_detele { get; set; }
       
    }
}
