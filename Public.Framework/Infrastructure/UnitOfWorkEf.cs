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
    }
}