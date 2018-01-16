using NLog;
using System;

namespace Translator
{
    /// <summary>
    /// Logger impementation using <see cref="NLog"/>
    /// </summary>
    /// <seealso cref="Translator.ILogger" />
    /// <inheritdoc />
    public class CustomLogger : ILogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Debugging information, less detailed than trace,
        /// typically not enabled in production environment.
        /// </summary>
        /// <param name="messageText"></param>
        public void Debug(string messageText)
        {
            logger.Debug(messageText);
        }

        /// <summary>
        /// Error messages - most of the time these are Exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageText"></param>
        public void Exception(Exception exception, string messageText)
        {
            logger.Error(messageText);
        }

        /// <summary>
        /// Information messages, which are normally enabled in production environment
        /// </summary>
        /// <param name="messageText"></param>
        public void Info(string messageText)
        {
            logger.Info(messageText);
        }

        /// <summary>
        /// Very serious errors!
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageText"></param>
        public void Fatal(Exception exception, string messageText)
        {
            logger.Fatal(exception, messageText);
        }

        /// <summary>
        /// Very detailed logs, which may include high-volume information such as protocol payloads.
        /// This log level is typically only enabled during development
        /// </summary>
        /// <param name="messageText"></param>
        public void Trace(string messageText)
        {
            logger.Trace(messageText);
        }

        /// <summary>
        /// Warning messages, typically for non-critical issues,
        /// which can be recovered or which are temporary failures
        /// </summary>
        /// <param name="messageText"></param>
        public void Warning(string messageText)
        {
            logger.Warn(messageText);
        }
    }
}