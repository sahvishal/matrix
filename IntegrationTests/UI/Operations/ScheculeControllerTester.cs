using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Areas.Operations.Controllers;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.UI.Operations
{
    [TestFixture]
    public class ScheculeControllerTester
    {
        private readonly ScheduleController _scheduleController;
        private readonly IEventStaffAssignmentService _assignmentService;
        private readonly IPodRepository _podRepository;
        private readonly IEventService _eventService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IUniqueItemRepository<Falcon.App.Core.Application.Domain.File> _fileRepository;
        private readonly IStaffEventScheduleUploadRepository _staffEventScheduleUploadRepository;
        private readonly ILogManager _logManager;
        private readonly ISettings _settings;

        public ScheculeControllerTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _assignmentService = IoC.Resolve<IEventStaffAssignmentService>();
            _podRepository = IoC.Resolve<IPodRepository>();
            _organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            _eventService = IoC.Resolve<IEventService>();
            _mediaRepository = IoC.Resolve<IMediaRepository>();
            _csvReader = IoC.Resolve<ICsvReader>();
            _fileRepository = IoC.Resolve<IUniqueItemRepository<App.Core.Application.Domain.File>>();
            _staffEventScheduleUploadRepository = IoC.Resolve<IStaffEventScheduleUploadRepository>();
            _logManager = IoC.Resolve<ILogManager>();
            _settings = IoC.Resolve<ISettings>();
            _scheduleController = new ScheduleController(_assignmentService, _eventService, new FakeSessionContext(),
                _mediaRepository, _logManager, _csvReader, _fileRepository, _staffEventScheduleUploadRepository, _settings);
        }

        [Test]
        public void GetStaffScheduleFor_ReturnValidJsonData()
        {

            var actual = _scheduleController.GetStaffScheduleFor(new EventStaffAssignmentListModelFilter(new DateTime(2011, 6, 1)));   //new EventStaffAssignmentListModelFilter(new DateTime(2011, 6, 1)));

            Assert.IsNotNull(actual.Data);
        }

    }
}