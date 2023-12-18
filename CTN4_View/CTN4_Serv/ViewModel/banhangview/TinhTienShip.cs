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
        public int service_id { get; set; }
        public int insurance_value { get; set; }
        public int from_district_id { get; set; }
        public int to_district_id { get; set; }
        public string to_ward_code { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public int weight { get; set; }
        public int width { get; set; }
    }
}
