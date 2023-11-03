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
    public class KhuyenMaiPhanLoaiView
    {
        public List<SelectListItem> khuyenMaiItems { get; set; }
        public List<SelectListItem> phanLoaiItems { get; set; }
        public List<KhuyenMaiPhanLoai> khuyenMaiPhanLoais { get; set; }
        public KhuyenMaiPhanLoai KhuyenMaiPhanLoai { get; set; }
        public KhuyenMaiPhanLoai khuyenMaiPhanLoai { get; set; }
        public Guid Id { get; set; }
        public Guid? idKhuyenMai { get; set; }
        public Guid? IdPhanLoai { get; set; }

    }
}
