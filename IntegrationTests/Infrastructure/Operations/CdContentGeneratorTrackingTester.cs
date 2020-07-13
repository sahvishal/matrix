using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Operations.Mappers;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    public class CdContentGeneratorTrackingTester
    {
        private ICdContentGeneratorTrackingRepository _cdContentGeneratorTrackingRepository;
        private CdContentGeneratorTracking _cdContentGeneratorTracking;
        private const long ValidEventCustomerResultId = 494734;

        [SetUp]
        public void Init()
        {
            IoC.Register<ICdContentGeneratorTrackingRepository, CdContentGeneratorTrackingRepository>();
            IoC.Register<IMapper<CdContentGeneratorTracking, CdcontentGeneratorTrackingEntity>, CdContentGeneratorTrackingMapper>();
            IoC.Register<IPersistenceLayer, SqlPersistenceLayer>();

            _cdContentGeneratorTrackingRepository = IoC.Resolve<ICdContentGeneratorTrackingRepository>();
            _cdContentGeneratorTracking = new CdContentGeneratorTracking
                                              {
                                                  EventCustomerResultId = ValidEventCustomerResultId,
                                                  IsContentGenerated = true,
                                                  IsContentDownloaded = false,
                                                  DownloadedByOrgRoleUserId = null,
                                                  DownloadedDate = null
                                              };
        }

        [Test]
        public void SaveCdContentGenatorTracking()
        {
            var cdContentGeneratorTracking = _cdContentGeneratorTrackingRepository.Save(_cdContentGeneratorTracking);

            Assert.IsNotNull(cdContentGeneratorTracking);
        }
    }
}
