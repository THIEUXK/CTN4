namespace CTN4_Data.Models.DB_CTN4
{
    public class ChucVu
    {
        public Guid Id { get; set; }
        public string TenChucVu { get; set; }
        public bool TrangThai { get; set; }
        public List<NhanVien> NhanViens { get; set; }

    }
}
