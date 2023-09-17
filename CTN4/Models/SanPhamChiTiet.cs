namespace CTN4.Models
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
        
        public Guid? IdChatLieu { get; set; }
        public Guid? IdMau { get; set; }
        public Guid? IdNSX { get; set; }
        public Guid? IdSize { get; set; }
        public Guid? IsSp { get; set; }

        public List<Anh> Anhs { get; set; }

        public ChatLieu? ChatLieu { get; set; }
        public Mau? Mau { get; set; }
        public Size? Size { get; set; }
        public NSX? NSX { get; set; }
        public SanPham? SanPham { get; set; }

        public List<KhuyenMaiChiTiet> KKhuyenMaiChiTiets { get; set; }
        public List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public List<GioHangChiTiet> GioHangChiTiets { get; set; }



    }
}
