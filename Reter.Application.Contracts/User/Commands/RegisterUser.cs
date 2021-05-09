namespace Reter.Application.Contracts.User.Commands
{
    public class RegisterUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Email { get;  set; }
    }
}