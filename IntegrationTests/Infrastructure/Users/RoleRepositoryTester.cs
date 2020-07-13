using System.Collections;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class RoleRepositoryTester
    {
        private readonly IRoleRepository _roleRepository;

        public RoleRepositoryTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _roleRepository = IoC.Resolve<IRoleRepository>();
        }
        
        [Test]
        public void GetAll_ReturnsAllRoles()
        {
            var roles = _roleRepository.GetAll();
            
            Assert.IsNotEmpty((ICollection) roles);
        }
    }
}