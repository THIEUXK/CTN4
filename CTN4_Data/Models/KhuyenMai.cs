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
        public bool TrangThai { get; set; }

        public List<KhuyenMaiChiTiet> KKhuyenMaiChiTiets { get; set; }
    }
}
