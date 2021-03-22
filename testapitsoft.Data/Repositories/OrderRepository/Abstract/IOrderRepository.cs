using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using testapitsoft.Core.Data.Entity;
using testapitsoft.Core.Dtos;
using testapitsoft.Data.Repositories.BRepository.Abstract;

namespace testapitsoft.Data.Repositories.OrderRepository.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
    
    }
}
