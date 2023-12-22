using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class NSX
    {
        public Guid Id { get;set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(30, ErrorMessage = "Không được quá 30 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string TenNSX{ get;set; }
        public bool TrangThai { get;set; }
        public string? GhiChu { get;set; }
        public bool Is_detele { get; set; }

        public virtual List<SanPham>? SanPhams { get; set; }
    }
}
