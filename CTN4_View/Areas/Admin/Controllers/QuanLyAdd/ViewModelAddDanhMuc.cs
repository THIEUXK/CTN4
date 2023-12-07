using CTN4_Data.Models.DB_CTN4;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyAdd
{
    public class ViewModelAddDanhMuc
    {
       public List<SanPham> sanPhams { get; set; }
       public List<DanhMuc> danhMucs { get; set; }
       public DanhMuc danhMuc { get; set; }
       public List<DanhMucChiTiet> danhMucChiTiets { get; set; }
    }
}
