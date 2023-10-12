using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
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
                _db.ChatLieus.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
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
