using AutoMapper;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.User;
using Reter.Application.Contracts.User.Commands;
using Reter.Domain.UserAgg;
using Reter.Domain.UserAgg.Services;

namespace Reter.Application.User
{
    public class UserApplication:IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHashPasswordService _hashPasswordService;
        private readonly IAuthService _authService;
        public UserApplication(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IHashPasswordService hashPasswordService, IAuthService authService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hashPasswordService = hashPasswordService;
            _authService = authService;
        }

        public void Register(RegisterUser command)
        {
            _unitOfWork.BeginTran();
            var user = new Domain.UserAgg.User(command.FirstName, command.LastName, command.Phone, command.UserName,
                command.Email,command.Password,_hashPasswordService);
            _userRepository.Create(user);
            _unitOfWork.CommitTran();
        }

        public LoginResult Login(LoginUserCommand command)
        {
            var isEmailAndPasswordValid = _authService.CheckEmailAndPasswordValid(command.Email, command.Password);
            return new LoginResult()
            {
                IsLogged = isEmailAndPasswordValid,
                UserViewModel = isEmailAndPasswordValid ? _userRepository.GetUserViewModel(command.Email):null,
            };
        }
    }
}