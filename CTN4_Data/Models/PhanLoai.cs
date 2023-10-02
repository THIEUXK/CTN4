namespace CTN4_Data.Models.DB_CTN4
{
    public class PhanLoai
    {
        public Guid Id { get; set; }
        public string TenPhanLoai { get; set; }
        public string GhiChu { get; set; }
        public bool TrạngThai { get; set; }
        public bool Is_Delete { get; set; }
        
        public List<PhanLoaiChiTiet> PhanLoaiChiTiets { get; set; }
        public List<KhuyenMaiPhanLoai> KKhuyenMaiPhanLoais { get; set; }

    }
}
