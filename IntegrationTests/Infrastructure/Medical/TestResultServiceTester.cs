using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class TestResultServiceTester
    {
        private ITestResultService _testResultService;
        private IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private const long ValidEventId = 24344;
        private const long ValidCustomerId = 467374;


        public TestResultServiceTester()
        {
        }

        [SetUp]
        public void SetUp()
        {
            IoC.Register<ISettings, FakeSettings>();
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _testResultService = IoC.Resolve<TestResultService>();
            _organizationRoleUserRepository = IoC.Resolve<OrganizationRoleUserRepository>();
        }

        [Test]
        public void SaveCustomerResultSigned_Tester()
        {
            var model = new MedicareCustomerResultSignedNPViewModel
            {
                EventId = ValidEventId,
                CustomerId = ValidCustomerId,
                IsSigned = true,
                RoleAlias = "NursePractitioner",
                UserName = "cbevan"
            };

            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
                Assert.IsNull(orgRoleUser);
            else
            {
                Assert.IsNotNull(orgRoleUser);
                _testResultService.SaveCustomerResultSigned(model, orgRoleUser);
            }
        }

        [Test]
        public void SaveCustomerResultAfterEvaluation_Tester()
        {
            var model = new MedicareCustomerResultVerifiedViewModel
            {
                EventId = ValidEventId,
                CustomerId = ValidCustomerId,
                RoleAlias = "NursePractitioner",
                UserName = "cbevan"
            };

            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
                Assert.IsNull(orgRoleUser);
            else
            {
                Assert.IsNotNull(orgRoleUser);
                _testResultService.SaveCustomerResultAfterNpReview(model, orgRoleUser);
            }
        }

        //[Test]
        //public void SaveCustomerResultSignedComplete_Tester()
        //{
        //    var model = new MedicareEventCustomerModel
        //    {
        //        EventId = ValidEventId,
        //        CustomerId = ValidCustomerId
        //    };
        //    _testResultService.SaveCustomerResultSignedComplete(model);
        //}

        [Test]
        public void SaveCustomerResultCoded_Tester()
        {
            var model = new MedicareCustomerResultCodedViewModel
            {
                EventId = ValidEventId,
                CustomerId = ValidCustomerId,
                IsCoded = true,
                RoleAlias = "Coder",
                UserName = "cbevan"
            };

            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
                Assert.IsNull(orgRoleUser);
            else
            {
                Assert.IsNotNull(orgRoleUser);
                _testResultService.SaveCustomerResultCoded(model, orgRoleUser);
            }
        }
    }
}
