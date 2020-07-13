using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Infrastructure.Users.Interfaces;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class CallCenterRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            IoC.Register<ICallCenterRepRepository, CallCenterRepRepository>();
            IoC.Register<ICallCenterRepService, CallCenterRepService>();
        }
    }
}