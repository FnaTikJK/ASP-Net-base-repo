using System.Security.Claims;
using ASP_Net_base.DAL;
using ASP_Net_base.Infrastructure;
using ASP_Net_base.Modules.Accounts.Ports;
using AutoMapper;

namespace ASP_Net_base.Modules.Accounts.Adapters
{
    public class AccountsService : IAccountsService
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        // По хорошему нельзя импортить DbContext в сервис на прямую, нужно юзать IRepository, но пока лень это сюда пилить.
        public AccountsService(DataContext dataContext, IPasswordHasher passwordHasher, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.passwordHasher = passwordHasher;
            this.mapper = mapper;
        }

        public async Task<Result<ClaimsIdentity>> RegisterAsync(RegisterRequest registerRequest)
        {
            var cur = await dataContext.Accounts.FindAsync(registerRequest.Login);
            if (cur != null)
                return Result.Fail<ClaimsIdentity>("Такой пользователь уже существует.");
            
            await dataContext.Accounts.AddAsync(mapper.Map<AccountEntity>(registerRequest));
            await dataContext.SaveChangesAsync();
            return await LoginAsync(mapper.Map<LoginRequest>(registerRequest));
        }

        public async Task<Result<ClaimsIdentity>> LoginAsync(LoginRequest loginRequest)
        {
            var cur = await dataContext.Accounts.FindAsync(loginRequest.Login);
            if (cur == null)
                return Result.Fail<ClaimsIdentity>("Такого пользователя не существует.");

            var isPasswordValid = passwordHasher.IsPasswordEqualHashed(cur.PasswordHash, loginRequest.Password);
            if (!isPasswordValid)
                return Result.Fail<ClaimsIdentity>("Неправильный пароль.");

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, loginRequest.Login) };
            return Result.Ok(new ClaimsIdentity(claims, "Cookies"));
        }
    }
}
