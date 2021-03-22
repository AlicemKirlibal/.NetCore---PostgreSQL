using System;
using System.Collections.Generic;
using System.Text;
using testapitsoft.Core.Data.Entity;
using testapitsoft.Data.Repositories.BRepository.Concrete;
using testapitsoft.Data.Repositories.OrderRepository.Abstract;

namespace testapitsoft.Data.Repositories.OrderRepository.Concrete
{
   public class OrderRepository: Repository<Order,AppDbContext>,IOrderRepository
    {
    }
}
