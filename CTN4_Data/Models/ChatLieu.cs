

using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class ChatLieu
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(50, ErrorMessage = "Không được quá 30 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string TenChatLieu { get; set; }
        public bool TrangThai { get; set; }
        public string? GhiChu { get; set; }

        public virtual bool Is_detele { get; set; }
        public virtual List<SanPham>? SanPhams { get; set; }
    }
}
