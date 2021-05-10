using System;
using Microsoft.EntityFrameworkCore;

namespace Public.Framework.Infrastructure
{
    public class UnitOfWorkEf<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWorkEf(TContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }

        #region dispose

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
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

        ~UnitOfWorkEf() => Dispose(false);


        #endregion
    }
}