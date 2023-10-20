using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        //public int TotalPages
        //{
        //    get
        //    {
        //        if (ItemsPerPage <= 0 || TotalItems <= 0)
        //        {
        //            return 0; // Hoặc xử lý trường hợp khác tùy theo yêu cầu của bạn
        //        }

        //        return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        //    }
        //}
    }
}
