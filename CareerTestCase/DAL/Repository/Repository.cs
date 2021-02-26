using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CareerTestCase.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext dataContext)
        {
            if (dataContext == null)
                throw new ArgumentNullException("dataContext can not be null.");
            _dbContext = dataContext;
            _dbSet = _dbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            _dbSet.Add(entity);
            try
            {
                var res = _dbContext.SaveChanges();
                return res > 0;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex)
            {
                //log yaz
                return false;
            }

        }

        public bool Delete(T entity)
        {
            if (entity == null)
                return false;
            _dbSet.Remove(entity);
            try
            {
                var res = _dbContext.SaveChanges();
                return res > 0;
            }
            catch (Exception ex)
            {
                return false;
                //log write
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
                return false;
            _dbSet.Remove(entity);
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex )
            {
                return false;
            }
          
           
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FindAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public async  Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();

        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await  _dbSet.FindAsync(id);
        }

        public bool Update(T entity)
        {
            if (entity == null)
                return false;
            _dbSet.Update(entity);
            try
            {
                var res = _dbContext.SaveChanges();
                return res > 0;
            }
            catch (Exception ex )
            {

                return false;
            }
          
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
                return false;
            _dbSet.Update(entity);
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex )
            {

                return false;
            }
         
        }

        public async Task<bool> AddRange(IEnumerable<T> entities)
        {
            await  _dbContext.AddRangeAsync(entities);
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex)
            {
                //log yaz
                return false;
            }
        }
    }
}
