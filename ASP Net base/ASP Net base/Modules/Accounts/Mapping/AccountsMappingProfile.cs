using ASP_Net_base.Modules.Accounts.Ports;
using AutoMapper;

namespace ASP_Net_base.Modules.Accounts.Mapping
{
    public class AccountsMappingProfile : Profile
    {
        public AccountsMappingProfile()
        {
            CreateMap<RegisterRequest, LoginRequest>();
            CreateMap<RegisterRequest, AccountEntity>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.ConvertUsing<PasswordConverter, string>(src => src.Password));
        }

        private class PasswordConverter : IValueConverter<string, string>
        {
            private readonly IPasswordHasher passwordHasher;

            public PasswordConverter(IPasswordHasher passwordHasher)
            {
                this.passwordHasher = passwordHasher;
            }

            public string Convert(string notHashedPassword, ResolutionContext context)
            {
                return passwordHasher.CalculateHash(notHashedPassword);
            }
        }
    }
}
