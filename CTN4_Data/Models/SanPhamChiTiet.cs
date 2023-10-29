namespace CTN4_Data.Models.DB_CTN4
{
    public class SanPhamChiTiet 
    {
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

        public virtual List<Anh>? Anhs { get; set; }

        public virtual ChatLieu? ChatLieu { get; set; }
        public virtual Mau? Mau { get; set; }
        public virtual Size? Size { get; set; }
        public virtual NSX? NSX { get; set; }
        public virtual SanPham? SanPham { get; set; }

        public virtual List<KhuyenMaiSanPham>? KKhuyenMaiSanPhams { get; set; }
        public virtual List<PhanLoaiChiTiet>? PhanLoaiChiTiets { get; set; }
        public virtual List<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
        public virtual List<GioHangChiTiet>? GioHangChiTiets { get; set; }
        public virtual List<DanhMucChiTiet>? DanhMucChiTiets { get; set; }
        public virtual List<ChiTietSanPhamYeuThich>? CTietSanPhamYeuThiches { get; set; }



    }
}
