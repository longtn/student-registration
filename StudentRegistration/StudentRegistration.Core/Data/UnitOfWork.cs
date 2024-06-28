using System;

namespace StudentRegistration.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentRegistrationContext _dbContext;
        private bool _disposed;

        public UnitOfWork(StudentRegistrationContext context)
        {
            this._dbContext = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
