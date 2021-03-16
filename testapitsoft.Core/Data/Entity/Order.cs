using System;
using System.Collections.Generic;
using System.Text;

namespace testapitsoft.Core.Data.Entity
{
   public class Order
    {
        public int CustomerId { get; set; }
        public string CustomerUsername { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public decimal OrderTotalPrice { get; set; }
    }
}
