

using Microsoft.Extensions.Options;

namespace Forum_API.ForumAPILogger
{
    public class ForumAPIFileLoggerProvider : ILoggerProvider
    {
        public readonly IOptions<ForumAPIFileLoggerOptions> options;

        public ForumAPIFileLoggerProvider(IOptions<ForumAPIFileLoggerOptions> _options)
        {
            options = _options;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ForumAPIFileLogger(this);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
