using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class CustomLogger : ILogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogException(Exception exception, string message)
        {
            logger.LogException(LogLevel.Error, message, exception);
        }
    }
}
