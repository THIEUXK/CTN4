using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.Service
{
    public class SessionServices
    {
        // Đưa dữ liệu vào Session dưới dạng Json data
        public static void SetObjToJson(ISession session, string key, object value)
        {
            // Obj value là dữ liệu bạn muốn thêm vào Session
            // Chuyển đổi dữ liệu đó sang dạng JsonString
            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
        // Lấy và đưa dữ liệu từ session về dạng List<obj>
        public static List<SanPhamChiTiet> GetObjFromSession(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(data);
                return listObj;
            }
            else return new List<SanPhamChiTiet>();
        }
        public static List<KhachHang> KhachHangSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<KhachHang>>(data);
                return listObj;
            }
            else return new List<KhachHang>();
        }
        public static List<NhanVien> NhanVienSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<NhanVien>>(data);
                return listObj;
            }
            else return new List<NhanVien>();
        }
        public static List<GioHangChiTiet> GioHangSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(data);
                return listObj;
            }
            else return new List<GioHangChiTiet>();
        }

        public static bool CheckProductInCart(Guid id, List<SanPhamChiTiet> cartProducts)
        {
            return cartProducts.Any(p => p.Id == id); // Kiểm tra xem có tồn tại sp đó trong GH chưa
        }
        public static List<Mau> LuuMauSS(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<Mau>>(data);
                return listObj;
            }
            else return new List<Mau>();
        }
    }
}