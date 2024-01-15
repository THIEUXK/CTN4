using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class ChatLieuService : IChatLieuService
    {
        public DB_CTN4_ok _db;

        public ChatLieuService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<ChatLieu> GetAll()
        {
            return _db.ChatLieus.ToList();
        }

        public ChatLieu GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(ChatLieu a)
        {
            try
            {
                _db.ChatLieus.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(ChatLieu a)
            {
            try
            {
                // Kiểm tra xem đối tượng có tồn tại hay không
                var existingChatLieu = _db.ChatLieus.FirstOrDefault(c => c.Id == a.Id);

                if (existingChatLieu != null)
                {
                    // Cập nhật thuộc tính của đối tượng hiện tại
                    existingChatLieu.TenChatLieu = a.TenChatLieu;
                    existingChatLieu.GhiChu = a.GhiChu;
                    existingChatLieu.TrangThai = a.TrangThai;
                    existingChatLieu.Is_detele = a.TrangThai; // Có thể là một lỗi chính tả, cần kiểm tra xem có phải là Is_delete không?

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _db.SaveChanges();

                    return true;
                }

                return false; // Không tìm thấy đối tượng để sửa
            }
            catch (Exception e)
            {
                // Xử lý exception hoặc ghi log nếu cần
                return false;
            }

        }

        public bool Xoa(Guid id)
        {
            try
            {
                var b = GetById(id);
                _db.ChatLieus.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
