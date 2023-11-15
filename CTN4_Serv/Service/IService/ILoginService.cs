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
    public interface ILoginService
    {
        NhanVien GetUserNV(LoginAdmin userModel);
        KhachHang GetUserKH(Loginviewmodel userModel);
    }
}
