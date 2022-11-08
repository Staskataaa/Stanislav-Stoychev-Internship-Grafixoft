using Forum_API.ForumAPILogger;

namespace Forum_API.Configuration
{
    public class DependenciesConfig
    {
        public void ConfigDependencies(WebApplicationBuilder builder)
        {
            builder.Services.Configure<ILoggerProvider>(builder.Configuration.GetSection("Logging"));
            builder.Services.Configure<ForumAPIFileLoggerOptions>(builder.Configuration.GetSection("LoggerOptions"));
        }
    }
}
