using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.Service
{
    public class BestSellingProductModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantitySold { get; set; }
    }
}
