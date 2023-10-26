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
            //public int CountryID { get; set; }
            //public string Code { get; set; }
            //public List<string> NameExtension { get; set; }
            //public int IsEnable { get; set; }
            //public int RegionID { get; set; }
            //public int RegionCPN { get; set; }
            //public int UpdatedBy { get; set; }
            //public string CreatedAt { get; set; }
            //public string UpdatedAt { get; set; }
            //public bool CanUpdateCOD { get; set; }
            //public int Status { get; set; }
        }
    }
}
