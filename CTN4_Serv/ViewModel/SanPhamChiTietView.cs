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
        public List<SelectListItem> ChalieuItems { get; set; }
        public List<SelectListItem> MauItems { get; set; }
        public List<SelectListItem> NsxItems { get; set; }
        public List<SelectListItem> SpItems { get; set; }
        public List<SelectListItem> SizeItems { get; set; }
        public List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public SanPham SapPham { get; set; }

        public Guid Id { get; set; }

        public string MaSp { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }
        public float GiaNhap { get; set; }
        public float GiaBan { get; set; }
        public float GiaNiemYet { get; set; }
        public string GhiChu { get; set; }
        public bool Is_detele { get; set; }

        public Guid? IdChatLieu { get; set; }
        public Guid? IdMau { get; set; }
        public Guid? IdNSX { get; set; }
        public Guid? IdSize { get; set; }
        public Guid? IdSp { get; set; }
    }
}
