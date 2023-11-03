using System.ComponentModel.DataAnnotations;

namespace CTN4_Data.Models.DB_CTN4
{
    public class GiamGia
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Mã giảm không được bỏ trống.")]
        public string MaGiam { get; set; }


        [Required(ErrorMessage = "Số tiền giảm không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Số tiền giảm phải lớn hơn hoặc bằng 0.")]
        public float SoTienGiam { get; set; }

        [Required(ErrorMessage = "Phần trăm giảm không được bỏ trống.")]
        [Range(0,100 , ErrorMessage = "Phần trăm giảm phải lớn hơn hoặc bằng 0 và nhỏ hơn 100.")]

        public int PhanTramGiam { get; set; }
       
        public bool TrangThai { get; set; }

        [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
        public int SoLuong { get; set; }
       
        public DateTime NgayBatDau { get; set; }

        [EndDateMustBeGreaterThanStartDate(ErrorMessage = "Ngày kết thúc phải lớn hơn ngày bắt đầu.")]
        public DateTime NgayKetThuc { get; set; }

        [Required(ErrorMessage = "Số tiền giảm tối đa không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Số tiền giảm tối đa phải lớn hơn hoặc bằng 0.")]
        public float SoTienGiamToiDa { get; set; }

        [Required(ErrorMessage = "Điều kiện giảm không được bỏ trống.")]
        [Range(0, float.MaxValue, ErrorMessage = "Điều kiện giảm phải lớn hơn hoặc bằng 0.")]
        public float DieuKienGiam { get; set; }
        public bool LoaiGiamGia {get; set; }
        public virtual List<GiamGiaChiTiet>? GiamGiaChiTiets { get; set; }

    }
    // Custom validation attributes
    public class EndDateMustBeGreaterThanStartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var voucher = (GiamGia)validationContext.ObjectInstance;

            if (voucher.NgayKetThuc <= voucher.NgayBatDau)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}
