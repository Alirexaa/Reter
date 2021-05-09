using Public.Framework.Infrastructure;

namespace Reter.Domain.UserAgg
{
    public interface IUserRepository:IRepository<string,User>
    {
        
    }
}