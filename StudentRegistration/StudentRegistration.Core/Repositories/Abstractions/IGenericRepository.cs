using StudentRegistration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudentRegistration.Core.Repositories.Abstractions
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> condition);
        IQueryable<T> ToQueryable();
        T Create(T entity);
        bool Create(IEnumerable<T> entities);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);
    }
}
