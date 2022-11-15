using Forum_API.ForumAPILogger;

namespace Forum_API.Configuration
{
    public class LoggerConfig
    {
        public void ConfigureLogger (WebApplicationBuilder builder)
        {
            builder.Services.Configure<ForumAPIFileLoggerOptions>(builder.Configuration.GetSection("LoggerOptions"));
            builder.Services.Configure<ILoggerProvider>(builder.Configuration.GetSection("Logging"));
        }
    }
}
