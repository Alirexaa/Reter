namespace Reter.Application.Contracts.User.Commands
{
    public class LoginUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}