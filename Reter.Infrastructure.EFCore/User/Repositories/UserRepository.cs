using Microsoft.EntityFrameworkCore;
using Public.Framework.Infrastructure;
using Reter.Domain.UserAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.User.Repositories
{
    public class UserRepository:BaseRepository<string,Domain.UserAgg.User>,IUserRepository
    {
        private readonly ReterDbContext _context;

        public UserRepository(ReterDbContext context) : base(context)
        {
            _context = context;
        }
    }
}