using EcommerceProkoders.Core.Contract.Repository;
using EcommerceProkoders.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProkoders.DB.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcommerceContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EcommerceContext context)
        {
            _context = context;
          
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
          await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int StartIndex=0,int PageSize=10)
        {

            return await _dbSet
                .Skip(StartIndex)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
         
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await GetAsync(predicate);


            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
