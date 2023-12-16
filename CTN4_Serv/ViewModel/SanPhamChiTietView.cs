using System;
using System.Collections.Generic;
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
        public List<SelectListItem> MauItems { get; set; }
        public List<SelectListItem> SpItems { get; set; }
        public List<SelectListItem> SizeItems { get; set; }
        public List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public SanPhamChiTiet SnaSanPhamChiTiet { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
        public SanPhamChiTiet sanPhamChiTiet { get; set; }
        public SanPham sanPham { get; set; }
         public List<Anh> AhList { get; set; }
        public Guid Id { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }

       
        public Guid? IdSize { get; set; }
        public Guid? IdSp { get; set; }
        public Guid? IdMau { get; set; }
    }
}
