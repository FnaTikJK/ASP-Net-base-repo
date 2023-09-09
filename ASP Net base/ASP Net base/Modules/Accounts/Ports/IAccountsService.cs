using System.Security.Claims;
using ASP_Net_base.Infrastructure;

namespace ASP_Net_base.Modules.Accounts.Ports
{
    public interface IAccountsService
    {
        Task<Result<ClaimsIdentity>> RegisterAsync(RegisterRequest registerRequest);
        Task<Result<ClaimsIdentity>> LoginAsync(LoginRequest loginRequest);
    }
}
