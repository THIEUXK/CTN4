namespace CTN4_Data.Models.DB_CTN4
{
    public class PhanLoai
    {
        public Guid Id { get; set; }
        public string TenPhanLoai { get; set; }
        public string GhiChu { get; set; }
        public bool TrạngThai { get; set; }
        public bool Is_Delete { get; set; }

        public virtual List<PhanLoaiChiTiet>? PhanLoaiChiTiets { get; set; }
        public virtual List<KhuyenMaiPhanLoai>? KKhuyenMaiPhanLoais { get; set; }

    }
}
