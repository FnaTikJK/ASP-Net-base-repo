using System.Security.Claims;
using ASP_Net_base.Modules.Accounts.Ports;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_base.Modules.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody]RegisterRequest registerRequest)
        {
            var response = await accountsService.RegisterAsync(registerRequest);

            return response.IsSuccess ? NoContent()
                : BadRequest(response.Error);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromBody]LoginRequest loginRequest)
        {
            var response = await accountsService.LoginAsync(loginRequest);
            if (!response.IsSuccess)
                return BadRequest(response.Error);

            var principal = new ClaimsPrincipal(response.Value);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return NoContent();
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return NoContent();
        }
    }
}
