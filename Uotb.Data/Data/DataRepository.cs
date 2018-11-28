using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Uotb.Data.Entities;

namespace Uotb.Data.Data
{
    public class DataRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, new()
        where TKey : IComparable
    {
        private readonly DataContext _context;
        private bool _disposed;

        public DataRepository(DataContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public TEntity Insert(TEntity entity)
        {
            _context.Add(entity);
            return entity;
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Dispose()
        {
            _disposed = true;
        }
    }
}
