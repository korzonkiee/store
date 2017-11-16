using System;
using System.Linq;

namespace Store.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
         IQueryable<TEntity> GetAll();
         TEntity GetById(Guid id);
         void Add(TEntity entity);
    }
}