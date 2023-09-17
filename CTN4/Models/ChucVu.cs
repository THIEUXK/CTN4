namespace CTN4.Models
{
    public class ChucVu
    {
        public Guid Id { get; set; }
        public string TenChucVu { get; set; }
        public bool TrangThai { get; set; }
        public List<NguoiDung> NguoiDungs { get; set; }

    }
}
