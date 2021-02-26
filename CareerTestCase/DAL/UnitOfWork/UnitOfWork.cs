using CareerTestCase.DAL;
using CareerTestCase.DAL.Repository;
using CareerTestCase.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            if (dataContext == null)
                throw new ArgumentNullException("dataContext can not be null.");
            _dataContext = dataContext;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_dataContext);
        }
    }
}
