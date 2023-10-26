using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class District
    {
        public int code { get; set; }
        public string? message { get; set; }
        public IEnumerable<Data>? data { get; set; }
        public class Data
        {
            public int DistrictID { get; set; }
            public int ProvinceID { get; set; }
            public string? DistrictName { get; set; }
        }
    }
}
