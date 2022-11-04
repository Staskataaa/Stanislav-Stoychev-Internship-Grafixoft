﻿namespace Forum_API.ForumAPILogger
{
    public class ForumAPIFileLogger : ILogger
    {
        private readonly ForumAPIFileLoggerProvider _forumAPIFileLoggerProvider;

        public ForumAPIFileLogger(ForumAPIFileLoggerProvider forumAPIFileLoggerProvider)
        {
            _forumAPIFileLoggerProvider = forumAPIFileLoggerProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                string path = string.Format("{0}/{1}", _forumAPIFileLoggerProvider.options.Value.FolderPath,
                    _forumAPIFileLoggerProvider.options.Value.FilePath);

                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                string logDescription = string.Format("{0} {1} {2}",
                DateTime.Now.ToString(Constants.dateFormat),
                logLevel.ToString(),
                Environment.StackTrace);

                FileStream fileStream = new FileStream(path, FileMode.Append);

                using StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(logDescription);
            }
        }
    }
}
