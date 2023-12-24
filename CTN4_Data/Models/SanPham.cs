using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CTN4_Data.Models.DB_CTN4
{
    public class SanPham
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        public Guid? IdChatLieu { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        public Guid? IdNSX { get; set; }
        [Required(ErrorMessage = " không được để trống")]

        [StringLength(30, ErrorMessage = "Không được quá 30 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]
        public string MaSp { get; set; }
        [Required(ErrorMessage = " không được để trống")]
        [StringLength(80, ErrorMessage = "Không được quá 80 ký tự")]
        [RegularExpression(@"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđĐ]+$", ErrorMessage = "Chỉ được nhập chữ")]

        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public bool TrangThai { get; set; }
        public string? MoTa { get; set; }
         [Required(ErrorMessage = "Giá nhập không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Số tiền giảm không được nhỏ hơn 0.")]
        public float GiaNhap { get; set; }
         [Required(ErrorMessage = "Giá bán không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Số tiền giảm không được nhỏ hơn 0.")]
        public float GiaBan { get; set; }
         [Required(ErrorMessage = "Số tiền giảm không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Số tiền giảm không được nhỏ hơn 0.")]
        public float GiaNiemYet { get; set; }
        public string? GhiChu { get; set; }
        public bool Is_detele { get; set; }
        [JsonIgnore]
        public List<ChiTietSanPhamYeuThich> CtietSanPhamYeuThiches
        { get; set; }
        public List<DanhGiaSanPham> DanhGiaSanPhams
        { get; set; }
        [JsonIgnore]
        public virtual NSX? NSX { get; set; }
        public virtual ChatLieu? ChatLieu { get; set; }
        [JsonIgnore]
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
        [JsonIgnore]
        public virtual List<DanhMucChiTiet>? DanhMucChiTiets { get; set; }
        [JsonIgnore]
        public virtual List<KhuyenMaiSanPham>? KhuyenMaiSanPhams { get; set; }
        [JsonIgnore]
        public virtual List<PhanLoaiChiTiet>? PhanLoaiChiTiets { get; set; }

    }
}
