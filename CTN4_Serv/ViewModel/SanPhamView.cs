using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class SanPhamView
    {
        public List<SelectListItem> ChalieuItems { get; set; }

        public List<SelectListItem> NsxItems { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public SanPham sanPham { get; set; }
        public Guid Id { get; set; }
        public Guid? IdChatLieu { get; set; }
        public Guid? IdNSX { get; set; }
        public string MaSp { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public bool TrangThai { get; set; }
        public string MoTa { get; set; }
        public float GiaNhap { get; set; }
        public float GiaBan { get; set; }
        public float GiaNiemYet { get; set; }
        public string GhiChu { get; set; }
        public bool Is_detele { get; set; }
    }
}
