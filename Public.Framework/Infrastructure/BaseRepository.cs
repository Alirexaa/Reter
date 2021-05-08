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

        public bool Exists(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Any(expression);
        }
    }
}