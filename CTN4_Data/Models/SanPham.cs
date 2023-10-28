namespace CTN4_Data.Models.DB_CTN4
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string MaSP { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }

        public float GiaNhap { get; set; }
        public float GiaBan { get; set; }
        public float GiaNiemYet { get; set; }
        public string GhiChu { get; set; }
        public string MoTa { get; set; }
        public Guid? IdChatLieu { get; set; }
        public Guid? IdNSX { get; set; }
        public bool TrangThai { get; set; }
        public bool Is_detele { get; set; }
        public virtual List<SanPhamChiTiet>? SanPhamChiTiets { get; set; }
        public virtual List<PhanLoaiChiTiet>? PPhanLoaiChiTiets { get; set; }
        public virtual List<KhuyenMaiSanPham>? KhuyenMaiSanPhams { get; set; }
        public virtual List<Mau>? Maus { get; set; }
        public virtual NSX? Nsxs { get; set; }
        public virtual ChatLieu? CChatLieu { get; set; }
        public virtual List<DanhMucChiTiet>? DanhMucChiTiets { get; set; }


    }
}
