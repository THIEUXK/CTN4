using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.ViewModel
{
	public class SanPhamBan
	{
		public List<Anh> Anh { get; set; }
		public SanPhamChiTiet SanPhamChiTiet { get; set; }
	}
}
