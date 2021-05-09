namespace Reter.Domain.UserAgg.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHashPasswordService _hashPasswordService;
        private readonly IUserRepository _userRepository;

        public AuthService(IHashPasswordService hashPasswordService, IUserRepository userRepository)
        {
            _hashPasswordService = hashPasswordService;
            _userRepository = userRepository;
        }

        public bool CheckEmailAndPasswordValid(string email,string password)
        {
            var cryptoPassword = _userRepository.GetCryptoPassword(email);
            return _hashPasswordService.VerifyPasswordHash(password,cryptoPassword);
        }
    }
}