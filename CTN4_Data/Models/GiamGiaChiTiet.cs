namespace CTN4_Data.Models.DB_CTN4
{
    public class GiamGiaChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdGiamGia { get; set; }
        public int? IdHoaDon { get; set; }
        public virtual GiamGia? GiamGia { get; set; }
        public virtual HoaDon? HoaDon { get; set; }

    }
}
