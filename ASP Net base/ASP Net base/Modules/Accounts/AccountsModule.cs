using ASP_Net_base.Infrastructure;
using ASP_Net_base.Modules.Accounts.Adapters;
using ASP_Net_base.Modules.Accounts.Mapping;
using ASP_Net_base.Modules.Accounts.Ports;

namespace ASP_Net_base.Modules.Accounts
{
    public class AccountsModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddAutoMapper(typeof(AccountsMappingProfile));

            return services;
        }
    }
}
