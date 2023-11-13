namespace CTN4_Data.Models.DB_CTN4
{
    public class KhuyenMai
    {
        public Guid Id { get; set; }
        public string MaKhuyenMai { get; set; }
        public int PhanTramGiamGia { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public float SoTienGiam { get; set; }
        public float DongGia { get; set; }
        public bool TrangThai { get; set; }
        public string? Ghichu { get; set; }
        public bool Is_Detele { get; set; }

        public virtual List<KhuyenMaiSanPham>? KKhuyenMaiSanPhams { get; set; }
        public virtual List<KhuyenMaiPhanLoai>? KKhuyenMaiPhanLoais { get; set; }
    }
}
