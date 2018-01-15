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
        /// <param name="message"></param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Error messages - most of the time these are Exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public void Error(Exception exception, string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Information messages, which are normally enabled in production environment
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Very serious errors!
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public void LogFatal(Exception exception, string message)
        {
            logger.Fatal(exception, message);
        }

        /// <summary>
        /// Very detailed logs, which may include high-volume information such as protocol payloads.
        /// This log level is typically only enabled during development
        /// </summary>
        /// <param name="message"></param>
        public void Trace(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Warning messages, typically for non-critical issues,
        /// which can be recovered or which are temporary failures
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {
            logger.Error(message);
        }
    }
}