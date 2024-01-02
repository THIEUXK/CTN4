using Newtonsoft.Json;
using CTN4_Data.Models.DB_CTN4;
using CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk.viewMode;
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
        public static List<Guid> IdGio(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<Guid>>(data);
                return listObj;
            }
            else return new List<Guid>();
        }
        public static List<DanhMuc>? DanhMucSS(ISession session, string key)
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
        public static List<Mau> MauSacSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<Mau>>(data);
                return listObj;
            }
            else return new List<Mau>();
        }
        public static float? Sobatdau(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<float>(data);
                return listObj;
            }
            else return new float();
        }
        public static float? Soketthuc(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<float>(data);
                return listObj;
            }
            else return new float();
        }
        public static List<GiamGia> GiamGiaSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<GiamGia>>(data);
                return listObj;
            }
            else return new List<GiamGia>();
        }
        public static List<SanPhamChiTiet> SanPhamChiTietSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(data);
                return listObj;
            }
            else return new List<SanPhamChiTiet>();
        }
        public static int SanPhamMoRong(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<int>(data);
                return listObj;
            }
            else return new int();
        }
        public static int SanPhamMoRongPage(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<int>(data);
                return listObj;
            }
            else return new int();
        }public static int DanhGia(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<int>(data);
                return listObj;
            }
            else return new int();
        }
        public static List<SanPham> SapXepTheoGianb(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<SanPham>>(data);
                return listObj;
            }
            else return new List<SanPham>();
        }
        public static List<SanPhamTam> SanPhamTamSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<SanPhamTam>>(data);
                return listObj;
            }
            else return new List<SanPhamTam>();
        }
    }

}