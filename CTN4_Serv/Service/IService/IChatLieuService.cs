using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
   public interface IChatLieuService
    {
        
            public List<ChatLieu> GetAll();
            public ChatLieu GetById(Guid id);
            public bool Them(ChatLieu a);
            public bool Sua(ChatLieu a);
          
            public bool Xoa(Guid id);
        
    }
}
