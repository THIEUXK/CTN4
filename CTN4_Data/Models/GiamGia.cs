namespace CTN4_Data.Models.DB_CTN4
{
    public class GiamGia
    {
        public Guid Id { get; set; }
        public string MaGiam { get; set; }
        public float SoTienGiam { get; set; }
        public int PhanTramGiam { get; set; }
        public bool TrangThai { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public float SoTienGiamToiDa { get; set; }
        public float DieuKienGiam { get; set; }
        public virtual List<GiamGiaChiTiet>? GiamGiaChiTiets { get; set; }
    }
}
