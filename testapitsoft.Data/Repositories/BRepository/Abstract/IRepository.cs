using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace testapitsoft.Data.Repositories.BRepository.Abstract
{
    public interface IRepository<TEntity> where TEntity:class,new()
    {
        Task<IEnumerable<TEntity>> GetAllOrdersAsync();

        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
