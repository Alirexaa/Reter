using System;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.User;

namespace Reter.Domain.UserAgg
{
    public interface IUserRepository:IRepository<string,User>
    {
        CryptoPassword GetCryptoPassword(string email);
        UserViewModel GetUserViewModel(string email);
    }
}