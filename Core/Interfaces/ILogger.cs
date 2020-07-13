using System;

namespace Falcon.App.Core.Interfaces
{
    public interface ILogger
    {
        void Error(object message);
        void ErrorFormat(string format, params object[] args);
        void Debug(object message);
        void DebugFormat(string format, params object[] args);
        void Fatal(object message);
        void FatalFormat(string format, params object[] args);
        void Info(object message);
        void InfoFormat(string format, params object[] args);
        void Warn(object message);
        void WarnFormat(string format, params object[] args);

        void Error(string message, Exception exception);
        void Debug(string message, Exception exception);
        void Fatal(string message, Exception exception);
        void Info(string message, Exception exception);
        void Warn(string message, Exception exception);
    }
}