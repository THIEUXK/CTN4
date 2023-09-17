namespace CTN4.Models
{
    public class ChatLieu
    {
        public Guid Id { get; set; }
        public string TenChatLieu { get; set; }
        public bool TrangThai { get; set; }
        public List<SanPhamChiTiet> SnSanPhamChiTiets { get; set; }
    }
}
