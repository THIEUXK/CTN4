namespace CTN4.Models
{
    public class Anh
    {
        public Guid Id { get; set; }
        public string TenAnh { get; set; }
        public string DuongDanAnh { get; set; }
        public bool TrangThai { get; set; }

        public Guid? IdSpct { get; set; }

    }
}
