using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel.banhangview
{
    public class TinhTienShip
    {
        
            //"service_id":53321,
            //"insurance_value":500000,
            //"coupon": null,
            //"from_district_id":1486,
            //"to_district_id":1493,
            //"to_ward_code":"20314",
            //"height": 25,
            //"length":10,
            //"weight":3000,
            //"width": 30
        public string service_id { get; set; }
        public string insurance_value { get; set; }
        public string coupon { get; set; }
        public string from_district_id { get; set; }
        public string to_district_id { get; set; }
        public string to_ward_code { get; set; }
        public string height { get; set; }
        public string length { get; set; }
        public string weight { get; set; }
        public string width { get; set; }
    }
}
