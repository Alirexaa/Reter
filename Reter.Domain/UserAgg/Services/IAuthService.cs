namespace Reter.Domain.UserAgg.Services
{
    public interface IAuthService
    {
        bool CheckEmailAndPasswordValid(string email, string password);
    }
}