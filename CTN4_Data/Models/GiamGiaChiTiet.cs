namespace CTN4_Data.Models.DB_CTN4
{
    public class GiamGiaChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdGiamGia { get; set; }
        public Guid? IdHoaDon { get; set; }
        public GiamGia? GiamGia { get; set; }
        public HoaDon? HoaDon { get; set; }

    }
}
