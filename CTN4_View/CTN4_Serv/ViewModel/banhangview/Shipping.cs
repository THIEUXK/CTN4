using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel.banhangview
{
    public class Shipping
    {
        public int code { get; set; }
        public string message { get; set; }
        public float totaloder { get; set; }
        public float tienGiam { get; set; }
        public float TienShip { get; set; }
        public string DiaChichiTiet { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public int total { get; set; }
            public float totaloder { get; set; }
            //public int? service_fee { get; set; }
            //public int? insurance_fee { get; set; }
            //public int? pick_station_fee { get; set; }
            //public int? coupon_value { get; set; }
            //public int? r2s_fee { get; set; }
            //public int? document_return { get; set; }
            //public int? double_check { get; set; }
            //public int? cod_fee { get; set; }
            //public int? pick_remote_areas_fee { get; set; }
            //public int? deliver_remote_areas_fee { get; set; }


        }
    }
}
