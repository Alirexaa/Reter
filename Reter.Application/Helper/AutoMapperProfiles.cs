using AutoMapper;
using Reter.Application.Contracts.User.Commands;

namespace Reter.Application.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterUser, Domain.UserAgg.User>()
                .ForMember(user => user.PasswordHash,
                    expression => expression.MapFrom(src => src.Password));
        }
    }
}