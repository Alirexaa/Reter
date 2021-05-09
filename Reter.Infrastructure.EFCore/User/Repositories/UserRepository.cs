using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.User;
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

        public CryptoPassword GetCryptoPassword(string email)
        {
           return _context.Users.Where(p => p.Email == email).Select(
                user => new CryptoPassword()
                {
                    PasswordSalt = user.PasswordSalt,
                    PasswordHash = user.PasswordHash
                }).FirstOrDefault();
        }

        public UserViewModel GetUserViewModel(string email)
        {
            return _context.Users.Select(x => new UserViewModel()
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                UserName = x.UserName
            }).FirstOrDefault();
        }
    }
}