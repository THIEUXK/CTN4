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
		public SanPham sanPham { get; set; }
		public List<SanPham> sanPhams { get; set; }
		public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
		public List<SanPhamChiTiet> sizect { get; set; }
		public List<Mau> maus { get; set; }
		public List<Anh> anhs { get; set; }
		public Guid idmau { get; set; }
		//public Guid idsize { get; set; }
		public int soluong { get; set; }
	}
}
