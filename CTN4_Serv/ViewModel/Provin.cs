using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class Provin
    {
        public int code { get; set; }
        public string? message { get; set; }
        public IEnumerable<Data>? data { get; set; }
        public class Data
        {
            public int ProvinceID { get; set; }
            public string? ProvinceName { get; set; }
        }
    }
}
