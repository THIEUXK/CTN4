

namespace CTN4_Data.Models.DB_CTN4
{
    public class ChatLieu
    {
        public Guid Id { get; set; }
        public string TenChatLieu { get; set; }
        public bool TrangThai { get; set; }
        public string GhiChu { get; set; }

        public virtual bool Is_detele { get; set; }
        public virtual List<SanPham>? SanPhams { get; set; }
    }
}
