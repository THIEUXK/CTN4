using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class Ward
    {
        public int code { get; set; }
        public string message { get; set; }
        public IEnumerable<Data> data { get; set; }
        public class Data
        {
            public dynamic WardCode { get; set; }
            public int DistrictID { get; set; }
            public string WardName { get; set; }

            //public List<string> NameExtension { get; set; }
            //public string CanUpdateCOD { get; set; }

            //public string CreatedAt { get; set; }
            //public string UpdatedAt { get; set; }
            //public int Status { get; set; }
            //public int SupportType { get; set; }
        }
    }
}
