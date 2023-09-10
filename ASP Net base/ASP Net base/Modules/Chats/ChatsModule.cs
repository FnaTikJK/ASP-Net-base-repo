using ASP_Net_base.Infrastructure;

namespace ASP_Net_base.Modules.Chats
{
    public class ChatsModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            return services;
        }

        public void ConfigureHubs(WebApplication app)
        {
            app.MapHub<ChatsHub>("/Chats");
        }
    }
}
