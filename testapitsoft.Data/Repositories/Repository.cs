using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using testapitsoft.Core.Data.Repository;

namespace testapitsoft.Data.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity:class,new()
        where TContext:DbContext,new()
     
    {

        public readonly DbContext _context;


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context =new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
            return entity;
           
        }

        public async Task<IEnumerable<TEntity>> GetAllOrdersAsync()
        {
           using(var context =new TContext())
            {
              return await  context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter)
        {
            using(var context=new TContext())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
           
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using(var context= new TContext())
            {
                  context.Entry(entity).State = EntityState.Modified;
                  await context.SaveChangesAsync();
            }

            return entity;
        }
      

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context= new TContext())
            {
                context.Remove(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}
