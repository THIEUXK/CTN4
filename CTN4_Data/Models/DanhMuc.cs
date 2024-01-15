using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class DanhMuc
    {
        public Guid Id { get; set; }
         [Required(ErrorMessage = " không được để trống")]
         [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ-][a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ.")]

        public string? TenDanhMuc { get; set; }
        public bool Is_detele { get; set; }
        public virtual List<DanhMucChiTiet>? DanhMucChiTiets { get; set; }
    }
}
