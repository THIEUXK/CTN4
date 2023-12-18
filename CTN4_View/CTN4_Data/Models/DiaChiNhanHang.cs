namespace CTN4_Data.Models.DB_CTN4
{
    public class DiaChiNhanHang
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string DiaChi { get; set; }
        public bool? TrangThai { get; set; }
        public bool? Is_detele { get; set; }
        public float? TienShip { get; set; }
        public Guid? IdKhachHang { get; set; }
        public string? code { get; set; }
        public string? division_type { get; set; }
        public string? phone_code { get; set; }
        public string? codename { get; set; }
        public virtual KhachHang? KhachHang { get; set;}

        public virtual List<HoaDon>? HoaDon { get; set; }
    }
}
