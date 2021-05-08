﻿namespace Public.Framework.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}