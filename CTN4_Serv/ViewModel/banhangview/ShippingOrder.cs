using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel.banhangview
{
    public class ShippingOrder
    {
        public int service_id { get; set; }
        public int insurance_value { get; set; }
        public int from_district_id { get; set; }
        public int to_district_id { get; set; }
        public string to_ward_code { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int weight { get; set; }
        public float tienhang { get; set; }
        public float tiengiam { get; set; }
        public float tongtien { get; set; }
        public int idDon { get; set; }

    }
}
