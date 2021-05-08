using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Public.Framework.Domain;

namespace Public.Framework.Infrastructure
{
    public interface IRepository<in TKey,T> where T : DomainBase<TKey>
    {
        void Create(T entity);
        T Get(TKey id);
        bool Exists(Expression<Func<T,bool>> expression);
    }
}