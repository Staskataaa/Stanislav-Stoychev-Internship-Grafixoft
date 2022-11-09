using System.Diagnostics;

namespace Forum_API.ForumAPILogger
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
                var date = DateTime.Now.ToString(Constants.dateFormat);

                var filePath = _forumAPIFileLoggerProvider.options.Value.FilePath.Replace("{date}", date);
                var folderPath = _forumAPIFileLoggerProvider.options.Value.FolderPath;

                string path = string.Format("{0}/{1}", folderPath, filePath);

                if (!File.Exists(path))
                {
                    var logsFile = File.Create(path);
                    logsFile.Close();
                }
                
                string logDescription = string.Format("{0} {1} {2}",
                date,
                logLevel.ToString(),
                Environment.StackTrace); 

                FileStream fileStream = new FileStream(path, FileMode.Append);

                using StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(logDescription);
            }
        }
    }
}
