using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query { get; set; }

        TEntity Get(int Id);
        IQueryable<TEntity> GetAll(int page, int pageSize);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);

        bool Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);

        bool Remove(TEntity entity);
        void RemoveAll();
        int Remove(Expression<Func<TEntity, bool>> expression);
    }
}