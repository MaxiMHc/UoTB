using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Uotb.Data.Entities;

namespace Uotb.Data.Data
{
    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity : BaseEntity<TKey>
        where TKey : IComparable
    {
        void Delete(TEntity entity);

        TEntity Insert(TEntity entity);

        IQueryable<TEntity> Query();

        TEntity Update(TEntity entity);
    }
}
