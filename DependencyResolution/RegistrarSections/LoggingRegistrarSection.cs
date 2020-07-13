using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class LoggingRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            IoC.Register<ILogManager, NLogLogManager>();
        }
    }
}