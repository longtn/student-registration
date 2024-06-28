using System;

namespace StudentRegistration.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
