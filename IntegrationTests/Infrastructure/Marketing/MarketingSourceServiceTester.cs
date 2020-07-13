using System.Linq;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    public class MarketingSourceServiceTester
    {
        private IMarketingSourceService _marketingSourceService;
        [SetUp]
        public void SetUp()
        {

            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
            DependencyRegistrar.RegisterDependencies();
            _marketingSourceService = IoC.Resolve<IMarketingSourceService>();
        }

        [Test]
        public void Save()
        {
            var model = new MarketingSourceEditModel()
                            {
                                Id = 0,
                                Description = "Some Description",
                                Name = "Newsletter",
                                SelectedTerritories = null
                            };

            model = _marketingSourceService.Save(model);
            Assert.IsNotNull(model);
            Assert.Greater(model.Id, 0);
        }

        [Test]
        public void GetMarketingSourceByTerritoryTesterForZipAssociatedToAdvTerritory()
        {
            var zipCode = "78705";

            var markettingSources = _marketingSourceService.FetchMarketingSourceByZip(zipCode);
            Assert.IsNotNull(markettingSources);
            Assert.Greater(markettingSources.Count(), 0);
        }

        [Test]
        public void GetMarketingSourceByTerritoryTesterForZipNOTAssociatedToAdvTerritory()
        {
            var zipCode = "11785";

            var markettingSources = _marketingSourceService.FetchMarketingSourceByZip(zipCode);
            Assert.IsNotNull(markettingSources);
            Assert.Greater(markettingSources.Count(), 0);
        }


    }
}