using System;

namespace Public.Framework.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}