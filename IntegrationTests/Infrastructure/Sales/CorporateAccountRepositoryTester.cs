using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Sales
{
    [TestFixture]
    public class CorporateAccountRepositoryTester
    {
        private IOrganizationService _organizationService;
        private ICorporateAccountRepository _corporateAccountRepository;
        private CorporateAccountEditModel _corporateAccountEditModel;

        [SetUp]
        public void Init()
        {
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            DependencyRegistrar.RegisterDependencies();

            _organizationService = IoC.Resolve<IOrganizationService>();
            _corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();

            var organizationEditModel = new OrganizationEditModel
                                            {
                                                Name = "TestOrg",
                                                Description = "TestOrg Description",
                                                BusinessAddress =
                                                    new AddressEditModel()
                                                        {
                                                            StreetAddressLine1 = "StreetAddressLine1",
                                                            StreetAddressLine2 = "StreetAddressLine1",
                                                            City = "Austin",
                                                            StateId = 123,
                                                            CountryId = 1,
                                                            ZipCode = "78705"
                                                        },
                                                BillingAddress =
                                                    new AddressEditModel()
                                                        {
                                                            StreetAddressLine1 = "StreetAddressLine11",
                                                            StreetAddressLine2 = "StreetAddressLine11",
                                                            City = "Austin",
                                                            StateId = 123,
                                                            CountryId = 1,
                                                            ZipCode = "78701"
                                                        },
                                                PhoneNumber = new PhoneNumber() { AreaCode = "+1", Number = "232131" },
                                                FaxNumber = new PhoneNumber() { AreaCode = "+1", Number = "232131" },
                                                Email = "asdasdas@asdsa.com"
                                            };
            _corporateAccountEditModel = new CorporateAccountEditModel
                                                {
                                                    OrganizationEditModel = organizationEditModel,
                                                    ContractNotes = "Some Contract",
                                                    DefaultPackages =
                                                        new List<Package>
                                                            {
                                                              new Package()
                                                              {
                                                                  Id = 1,Name = "abc temp"
                                                              }
                                                            }
                                                };
        }


        [Test]
        public void CreateCorporateAccountTester()
        {

            _corporateAccountEditModel.OrganizationEditModel.OrganizationType = OrganizationType.CooperateAccount;

            var corporateAccount = Mapper.Map<CorporateAccountEditModel, CorporateAccount>(_corporateAccountEditModel);

            var accountId = _organizationService.Create(_corporateAccountEditModel.OrganizationEditModel);
            corporateAccount.Id = accountId;
            var customerTestDependency = _corporateAccountRepository.GetAccountCustomerResultTestDependency(accountId);
            var pcpTestDependency = _corporateAccountRepository.GetAccountPcpResultTestDependency(accountId);
            var healthPlanResultTestDependency = _corporateAccountRepository.GetAccountHealthPlanResultTestDependency(accountId);
            _corporateAccountRepository.SaveAccount(corporateAccount, _corporateAccountEditModel.ShippingOptionIds, customerTestDependency, pcpTestDependency, healthPlanResultTestDependency);

        }
    }
}