using StudentRegistration.Core.Data;
using StudentRegistration.Core.Entities;
using StudentRegistration.Core.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace StudentRegistration.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StudentRegistrationContext _dbContext;
        private IDbSet<T> _entities;
        private IDbSet<T> Entities => _entities ?? (_entities = _dbContext.Set<T>());

        public GenericRepository(StudentRegistrationContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return this.Entities.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find entity: {ex.Message}");
            }
        }

        public T GetById(int id)
        {
            try
            {
                return this.Entities.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find entity: {ex.Message}");
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> condition)
        {
            try
            {
                return this.Entities.Where(condition);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public IQueryable<T> ToQueryable()
        {
            try
            {
                return this.Entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public T Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            try
            {
                this.Entities.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be insert: {ex.Message}");
            }
        }

        public bool Create(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    Entities.AddOrUpdate(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"List of {nameof(T)} could not be insert: {ex.Message}");
            }
        }

        public bool Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            try
            {
                this.Entities.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be insert: {ex.Message}");
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                this.Entities.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete entity: {ex.Message}");
            }
        }

        public bool Delete(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    this.Entities.Remove(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete entity: {ex.Message}");
            }
        }
    }
}
