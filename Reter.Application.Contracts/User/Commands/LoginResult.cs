namespace Reter.Application.Contracts.User.Commands
{
    public class LoginResult
    {
        public bool IsLogged { get; set; }
        public UserViewModel UserViewModel { get; set; }
    }
}