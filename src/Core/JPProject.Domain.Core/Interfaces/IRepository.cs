using System;
using System.Linq;

namespace JPProject.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById<T>(T id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove<T>(T id);
        int SaveChanges();
    }
}
