using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models;

namespace CTN4_Serv.Service.IService
{
    public interface IDanhGiaSanPhamService
    {
        public List<DanhGiaSanPham> GetAll();
        public DanhGiaSanPham GetById(Guid id);
        public DanhGiaSanPham  GetDanhGiaByIdSanPhamAndIdKhachHang(Guid idSanPham, Guid idKhachHang);
        public bool Them(DanhGiaSanPham a);
        public bool Sua(DanhGiaSanPham a);
        public bool Xoa(Guid id);
    }
}
