using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;

namespace Falcon.App.Infrastructure.Repositories
{
    public class SystemInformationRepository : ISystemInformationRepository
    {
        private readonly ISystemInformationFactory _systemInformationFactory;

        public SystemInformationRepository()
            : this(new SystemInformationFactory())
        { }

        public SystemInformationRepository(ISystemInformationFactory systemInformationFactory)
        {
            _systemInformationFactory = systemInformationFactory;
        }

        public string GetSystemVersionNumber()
        {
            string versionNumber = Assembly.GetAssembly(typeof(DomainObjectBase)).GetName().Version.ToString();
            return _systemInformationFactory.GetFormattedVersionString(versionNumber);
        }

        public string GetBuildNumber()
        {
            return Assembly.GetAssembly(typeof(DomainObjectBase)).GetName().Version.Revision.ToString();
        }
    }
}