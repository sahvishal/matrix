using System;
using Falcon.App.Core.Interfaces;
using NLog;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger;

        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        public void Debug(string message, Exception exception)
        {
            _logger.DebugException(message, exception);
        }

        public void Debug(object message)
        {
            _logger.Debug(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Info(object message)
        {
            _logger.Info(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public void Warn(object message)
        {
            _logger.Warn(message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.Warn(format, args);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.Error(format, args);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.Fatal(format, args);
        }

        public void Fatal(string message, Exception exception)
        {
            _logger.FatalException(message, exception);
        }

        public void Error(string message, Exception exception)
        {
            _logger.ErrorException(message, exception);
        }

        public void Warn(string message, Exception exception)
        {
            _logger.WarnException(message, exception);
        }

        public void Info(string message, Exception exception)
        {
            _logger.InfoException(message, exception);
        }
    }
}