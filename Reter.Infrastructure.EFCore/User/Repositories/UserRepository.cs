using Microsoft.EntityFrameworkCore;
using Public.Framework.Infrastructure;
using Reter.Domain.UserAgg;

namespace Reter.Infrastructure.EFCore.User.Repositories
{
    public class UserRepository:BaseRepository<string,Domain.UserAgg.User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}