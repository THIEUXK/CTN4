using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Ser.ViewModel;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class LoginServices: ILoginService
    { 
       public  DB_CTN4_ok context ;
        
        public LoginServices()
        {
            context = new DB_CTN4_ok(); 
        }
        public NhanVien GetUserNV(LoginAdmin userModel)
        {
            return context.NhanViens.Where(x => x.TenDangNhap.ToLower() == userModel.User.ToLower()
                && x.MatKhau == userModel.Password).FirstOrDefault();
        }
        public KhachHang GetUserKH(Loginviewmodel userModel)
        {
            return context.KhachHangs.Where(x => x.TenDangNhap.ToLower() == userModel.User.ToLower()
                && x.MatKhau == userModel.Password).FirstOrDefault();
        }
    }
}
