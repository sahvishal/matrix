using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class CustomerEligibilityUploadService : ICustomerEligibilityUploadService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private const long orgRoleId = 1;

        public CustomerEligibilityUploadService(IMediaRepository mediaRepository, ISettings settings, IPipeDelimitedReportHelper pipeDelimitedReportHelper, ILogManager logManager,
            ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository, ICustomerProfileHistoryRepository customerProfileHistoryRepository,
            ICustomerEligibilityRepository customerEligibilityRepository)
        {
            _mediaRepository = mediaRepository;
            _settings = settings;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _logger = logManager.GetLogger("CustomerEligibilityUploadService");
        }

        public void PollForCustomerEligibilityUpload()
        {
            throw new NotImplementedException();
        }
    }
}
