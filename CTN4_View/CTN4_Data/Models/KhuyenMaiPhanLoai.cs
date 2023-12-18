namespace CTN4_Data.Models.DB_CTN4
{
    public class KhuyenMaiPhanLoai
    {
        public Guid Id { get; set; }
        public Guid? idKhuyenMai { get; set; }
        public Guid? IdPhanLoai { get; set; }

        public virtual PhanLoai? PhanLoai { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
    }
}
