using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CareerTestCase.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task< List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        T Get(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        IQueryable<T> GetAll();

        bool Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        Task<T> GetByIdAsync(int id);

        Task<bool> AddAsync(T entity);

        Task<bool> AddRange(IEnumerable<T> entities);


        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);







    }
}
