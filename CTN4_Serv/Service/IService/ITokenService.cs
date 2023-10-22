using CTN4_Data.Models.DB_CTN4;
using CTN4_Ser.ViewModel;
using CTN4_Serv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ITokenService
    {
        // xong thg này nhận nhanvien thì chả null
        string BuildToken(string key, string issuer, NhanVien user);
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string token);
        string BuildTokens(string key, string issuer, KhachHang user);
    }
}
