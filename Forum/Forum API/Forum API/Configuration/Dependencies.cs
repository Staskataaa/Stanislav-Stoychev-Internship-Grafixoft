using Forum_API.ForumAPILogger;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.Services;

namespace Forum_API.Configuration
{
    public class Dependencies
    {
        public void DefineDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<ILoggerProvider, ForumAPIFileLoggerProvider>();
            builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
            builder.Services.AddScoped<IAccountRoleService, AccountRoleService>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
        }
    }
}
