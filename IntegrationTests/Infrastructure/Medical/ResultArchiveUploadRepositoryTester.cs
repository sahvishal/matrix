using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;
using Falcon.App.Core.Operations;
using System;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class ResultArchiveUploadRepositoryTester
    {
        private readonly IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private long _validResultArchiveId = 1;
        public ResultArchiveUploadRepositoryTester()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            _resultArchiveUploadRepository = IoC.Resolve<IResultArchiveUploadRepository>();
        }

        [Test]
        public void SaveNew_withoutFileId_Test()
        {
            var resultArchive = new ResultArchive()
                                    {
                                        EventId = 1445,
                                        UploadedByOrgRoleUserId = 1,
                                        UploadStartTime = DateTime.Now,
                                        Status = ResultArchiveUploadStatus.Uploading
                                    };

            resultArchive = _resultArchiveUploadRepository.Save(resultArchive);

            Assert.IsNotNull(resultArchive);
            _validResultArchiveId = resultArchive.Id;

            Assert.Greater(resultArchive.Id, 0);
        }

        [Test]
        public void Update_withoutFileId_Test()
        {

            var resultArchive = _resultArchiveUploadRepository.GetById(_validResultArchiveId);

            resultArchive.Id = _validResultArchiveId;
            
            resultArchive.Status = ResultArchiveUploadStatus.UploadFailed;

            _resultArchiveUploadRepository.Save(resultArchive);
        }
    }
}