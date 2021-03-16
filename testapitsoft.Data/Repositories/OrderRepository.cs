using System;
using System.Collections.Generic;
using System.Text;
using testapitsoft.Core.Data.Entity;
using testapitsoft.Core.Data.Repository;

namespace testapitsoft.Data.Repositories
{
   public class OrderRepository: Repository<Order,AppDbContext>,IOrderRepository
    {
    }
}
