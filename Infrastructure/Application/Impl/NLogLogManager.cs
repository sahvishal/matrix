using Falcon.App.Core.Interfaces;
using NLog;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class NLogLogManager : ILogManager
    {
        public ILogger GetLogger<T>()
        {
            return new NLogLogger(LogManager.GetLogger(typeof(T).FullName));
        }

        public ILogger GetLogger(string name)
        {
            return new NLogLogger(LogManager.GetLogger(name));
        }
    }
}