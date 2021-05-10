using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Public.Framework.Domain;

namespace Public.Framework.Infrastructure
{
    public class BaseRepository<TKey,T>:IRepository<TKey,T> where T : DomainBase<TKey>
    {

        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public T Get(TKey id)
        {
          return  _context.Find<T>(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Any(expression);
        }

        #region dispose

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void  Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                // TODO: dispose managed state(managed object)
                _context.Dispose();
            }


            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null
            _disposed = true;
        }

        ~BaseRepository() => Dispose(false);

        #endregion
    }
}