
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapitsoft.Core.Data.Entity;
using testapitsoft.Core.Dtos;

namespace testapitsoft.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Orders = new List<OrderDto>();
        }

        public List<OrderDto> Orders { get; set; }
    }
}
