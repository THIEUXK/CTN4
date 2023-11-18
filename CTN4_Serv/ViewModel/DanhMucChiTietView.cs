using CTN4_Data.Models.DB_CTN4;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_Serv.ViewModel
{
    public class DanhMucChiTietView
    {
        public List<SelectListItem> danhMucItems { get; set; }
        public List<SelectListItem> sanPhamItems { get; set; }
        public List<DanhMucChiTiet> danhMucChiTiets { get; set; }
        public DanhMucChiTiet DanhMucChiTiet { get; set; }
        public DanhMucChiTiet danhMucChiTiet { get; set; }
        public Guid Id { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdDanhMuc { get; set; }

    }
}
