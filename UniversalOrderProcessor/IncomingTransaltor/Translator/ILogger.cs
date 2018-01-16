using System;

namespace Translator
{
    /// <summary>
    /// For Logging 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Very detailed logs, which may include high-volume information such as protocol payloads. 
        /// This log level is typically only enabled during development
        /// </summary>
        void Trace(string messageText);

        /// <summary>
        /// Debugging information, less detailed than trace, 
        /// typically not enabled in production environment.
        /// </summary>
        void Debug(string messageText);

        /// <summary>
        /// Information messages, which are normally enabled in production environment
        /// </summary>
        void Info(string messageText);

        /// <summary>
        ///  Warning messages, typically for non-critical issues, 
        ///  which can be recovered or which are temporary failures
        /// </summary>
        void Warning(string messageText);

        /// <summary>
        /// Error messages - most of the time these are Exceptions
        /// </summary>
        void Exception(Exception exception, string messageText);

        /// <summary>
        /// Very serious errors!
        /// </summary>
        void Fatal(Exception exception, string messageText);
    }
}