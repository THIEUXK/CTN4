using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_View.Areas.Admin.Viewmodel
{
    public class SaleViewModel
    {
        public List<SelectListItem> SpctItems { get; set; }
        public List<SelectListItem> SpItems { get; set; }
        public List<SelectListItem> KMItems { get; set; }
        public List<KhuyenMaiSanPham> khuyenMaiSanPhams { get; set; }
        public KhuyenMaiSanPham KhuyenMaiSanPham { get; set; }
        public KhuyenMaiSanPham khuyenMaiSanPham { get; set; }
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdkhuyenMai { get; set; }
    }
}
