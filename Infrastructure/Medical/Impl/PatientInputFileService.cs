using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PatientInputFileService : IPatientInputFileService
    {
        private readonly IPatientInputFileFactory _patientInputFileFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ITestResultRepository _testResultRepository;
        private readonly ISettings _settings;

        public PatientInputFileService(IPatientInputFileFactory patientInputFileFactory, IEventCustomerResultRepository eventCustomerResultRepository, ICustomerRepository customerRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ISettings settings)
        {
            _patientInputFileFactory = patientInputFileFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerRepository = customerRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _settings = settings;
            _testResultRepository = new IFOBTTestRepository();
        }

        public IEnumerable<PatientInputFileViewModel> GetPatientFileInputByEvent(Event eventData, string tag)
        {
            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsByEventIdTestId(eventData.Id, (long)TestType.IFOBT, tag);
            if (eventCustomerResults.IsNullOrEmpty())
                return null;

            var listModel = new List<PatientInputFileViewModel>();
            var customerIds = eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);
            var pcps = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;
            foreach (var eventCustomerResult in eventCustomerResults)
            {
                var ifobtTestResult = _testResultRepository.GetTestResults(eventCustomerResult.CustomerId, eventData.Id, isNewResultFlow) as IFOBTTestResult;
                if (ifobtTestResult == null)
                    continue;

                if (ifobtTestResult.TestNotPerformed != null && ifobtTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                    continue;

                var customer = customers.Single(c => c.CustomerId == eventCustomerResult.CustomerId);
                var pcp = pcps.SingleOrDefault(p => p.CustomerId == eventCustomerResult.CustomerId);

                var serialKey = ifobtTestResult.SerialKey != null ? ifobtTestResult.SerialKey.Reading : "";
                var model = _patientInputFileFactory.Create(customer, eventData, serialKey, pcp);

                listModel.Add(model);

            }

            return listModel;
        }
    }
}
