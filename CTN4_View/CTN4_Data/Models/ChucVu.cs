using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class ChucVu
    {
        public Guid Id { get; set; }
        //[RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        [Required(ErrorMessage = " không được để trống")]
         [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string TenChucVu { get; set; }
        public bool TrangThai { get; set; }
        public virtual List<NhanVien>? NhanViens { get; set; }

    }
}
