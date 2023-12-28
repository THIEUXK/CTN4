using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class Size
    {
        public Guid Id { get; set; }
         
          [Required(ErrorMessage = " không được để trống")]
        [StringLength(50, ErrorMessage = "Không được quá 30 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string TenSize { get; set; }

          [Required(ErrorMessage = " không được để trống")]
          [StringLength(30, ErrorMessage = "Không được quá 30 ký tự")]
          [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string CoSize { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
    }
}
