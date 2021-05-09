using Reter.Application.Contracts.User.Commands;

namespace Reter.Application.Contracts.User
{
    public interface IUserApplication
    {
        void Register(RegisterUser command);
        LoginResult Login(LoginUserCommand command);
    }
}