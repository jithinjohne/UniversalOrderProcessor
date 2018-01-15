using System;

namespace Translator
{
    public interface ILogger
    {
        void LogException(Exception exception, string message);
    }
}