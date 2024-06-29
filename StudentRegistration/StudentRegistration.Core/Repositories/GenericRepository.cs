using Serilog;
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
                Log.Logger.Error($"GenericRepository - GetAll - Couldn't find entity: {ex.Message}");
                return Enumerable.Empty<T>();
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
                Log.Logger.Error($"GenericRepository - GetById - Couldn't find entity: {ex.Message}");
                return null;
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
                Log.Logger.Error($"GenericRepository - Where - Couldn't retrieve entities: {ex.Message}");
                return null;
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
                Log.Logger.Error($"GenericRepository - ToQueryable - Couldn't retrieve entities: {ex.Message}");
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public T Create(T entity)
        {
            if (entity is null)
            {
                Log.Logger.Error($"GenericRepository - Create - {nameof(entity)} entity must not be null");
                return null;
            }
            try
            {
                this.Entities.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"GenericRepository - Create - {nameof(entity)} could not be insert: {ex.Message}");
                return null;
            }
        }

        public bool Create(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    this.Entities.AddOrUpdate(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"GenericRepository - Create - List of {nameof(T)} could not be insert: {ex.Message}");
                return false;
            }
        }

        public bool Update(T entity)
        {
            if (entity is null)
            {
                Log.Logger.Error($"GenericRepository - Update - {nameof(entity)} entity must not be null");
                return false;
            }
            try
            {
                this.Entities.AddOrUpdate(entity);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"GenericRepository - Update - {nameof(entity)} could not be insert: {ex.Message}");
                return false;
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
                Log.Logger.Error($"GenericRepository - Delete - Couldn't delete entity: {ex.Message}");
                return false;
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
                Log.Logger.Error($"GenericRepository - Delete - Couldn't delete entity: {ex.Message}");
                return false;
            }
        }
    }
}
