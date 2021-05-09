using AutoMapper;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.User;
using Reter.Application.Contracts.User.Commands;
using Reter.Domain.UserAgg;

namespace Reter.Application.User
{
    public class UserApplication:IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserApplication(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Register(RegisterUser command)
        {
            _unitOfWork.BeginTran();
            var user = _mapper.Map<Domain.UserAgg.User>(command);
            _userRepository.Create(user);
            _unitOfWork.CommitTran();
        }
    }
}