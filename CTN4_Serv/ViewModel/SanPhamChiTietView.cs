using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CTN4_Serv.ViewModel
{
    public class SanPhamChiTietView
    {
        [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        public List<SelectListItem> MauItems { get; set; }
        public List<SelectListItem> SpItems { get; set; }
        [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        public List<SelectListItem> SizeItems { get; set; }
        public List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public SanPhamChiTiet SnaSanPhamChiTiet { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
        public SanPham sanPham { get; set; }
         public List<Anh> AhList { get; set; }
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        //[Range(1, float.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 1.")]
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }

       [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        public Guid? IdSize { get; set; }
        public Guid? IdSp { get; set; }
        [Required(ErrorMessage = "Số lượng không được bỏ trống.")]
        public Guid? IdMau { get; set; }
    }
}
