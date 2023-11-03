using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class NhanViewView
    {
        public List<SelectListItem> ChuVuItems { get; set; }
        public Guid Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool Trangthai { get; set; }
        public string AnhDaiDien { get; set; }
        public Guid? IdChucVu { get; set; }
    }
}
