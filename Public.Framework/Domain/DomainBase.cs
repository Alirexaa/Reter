using System;

namespace Public.Framework.Domain
{
    public class DomainBase<T>
    {
        public T Id { get; protected set; }
        public DateTime CreationTime { get; private set; }

        public DomainBase()
        {
            CreationTime = DateTime.Now;
        }
    }
}