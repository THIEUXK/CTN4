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
    }
}