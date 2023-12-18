using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class ProductDiscountViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public float OriginalPrice { get; set; }
        public bool IsSelected { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
