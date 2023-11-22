using Newtonsoft.Json;
using CTN4_Data.Models.DB_CTN4;
using CTN4_View.Controllers.Shop.ViewModelThieuxk;

namespace CTN4_View_Admin.Controllers.Shop
{
    public class SessionBan
    {
        public static void SetObjToJson(ISession session, string key, object value)
        {
            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
        public static List<ThongTinTam> ThongTinTamSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<ThongTinTam>>(data);
                return listObj;
            }
            else return new List<ThongTinTam>();
        }
          public static List<DanhMuc> DanhMucSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<DanhMuc>>(data);
                return listObj;
            }
            else return new List<DanhMuc>();
        }
          public static List<ChatLieu> ChatLieuSS(ISession session, string key)
          {
              var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
              if (data != null)
              {
                  var listObj = JsonConvert.DeserializeObject<List<ChatLieu>>(data);
                  return listObj;
              }
              else return new List<ChatLieu>();
          }
    }
    
}