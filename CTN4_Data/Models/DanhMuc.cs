namespace CTN4_Data.Models.DB_CTN4
{
    public class DanhMuc
    {
        public Guid Id { get; set; }
        public string TenDanhMuc { get; set; }
        public bool Is_detele { get; set; }
        public List<DanhMucChiTiet> DanhMucChiTiets { get; set; }
    }
}
