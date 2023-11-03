using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace CTN4_Data.Models.DB_CTN4
{
    public class DanhMucChiTiet
    {
        
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdDanhMuc { get; set; }
        public virtual DanhMuc? DanhMuc { get; set;}
        public virtual SanPham? SanPham { get; set; }
    }
}
