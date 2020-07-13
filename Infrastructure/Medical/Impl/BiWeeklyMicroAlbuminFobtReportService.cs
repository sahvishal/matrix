using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BiWeeklyMicroAlbuminFobtReportService : IBiWeeklyMicroAlbuminFobtReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IPhysicianLabTestRepository _physicianLabTestRepository;
        private readonly IBiWeeklyMicroAlbuminFobtReportFactory _biWeeklyMicroAlbuminFobtReportFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ILogger _logger;

        public BiWeeklyMicroAlbuminFobtReportService(ICustomerRepository customerRepository, IEventRepository eventRepository, IHostRepository hostRepository,
            IPhysicianLabTestRepository physicianLabTestRepository, IBiWeeklyMicroAlbuminFobtReportFactory biWeeklyMicroAlbuminFobtReportFactory,
            IEventCustomerResultRepository eventCustomerResultRepository, ILogManager logManager)
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _physicianLabTestRepository = physicianLabTestRepository;
            _biWeeklyMicroAlbuminFobtReportFactory = biWeeklyMicroAlbuminFobtReportFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _logger = logManager.GetLogger("BiWeeklyMicroAlbuminFobtReport");
        }

        public ListModelBase<BiWeeklyMicroAlbuminFobtReportViewModel, BiWeeklyMicroAlbuminFobtReportModelFilter> GetEventCustomerResultForReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomerResultCollection = _eventCustomerResultRepository.GetLabKitDistributionReport(filter as BiWeeklyMicroAlbuminFobtReportModelFilter, pageNumber, pageSize, out totalRecords);
            return GetBiWeeklyMicroAlbuminFobtReportModel((IReadOnlyCollection<EventCustomerResult>)eventCustomerResultCollection);
        }

        private BiWeeklyMicroAlbuminFobtReportListModel GetBiWeeklyMicroAlbuminFobtReportModel(IReadOnlyCollection<EventCustomerResult> eventCustomerResultCollection)
        {
            if (eventCustomerResultCollection.IsNullOrEmpty())
            {
                _logger.Info("eventCustomerResultCollection provided is null or empty");
                return null;
            }

            var listModel = new BiWeeklyMicroAlbuminFobtReportListModel();
            var collection = new List<BiWeeklyMicroAlbuminFobtReportViewModel>();

            var customerIds = eventCustomerResultCollection.Select(x => x.CustomerId).ToArray();
            var eventIds = eventCustomerResultCollection.Select(x => x.EventId).ToArray();
            var eventCustomerResultIds = eventCustomerResultCollection.Select(x => x.Id).ToArray();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var physicianLabTests = _physicianLabTestRepository.GetPhysicicanLabTestByStateIds(hosts.Select(x => x.Address.StateId));
            var customers = _customerRepository.GetCustomers(customerIds);
            var eventCustomerResultIdIfobtValuePair = _eventCustomerResultRepository.GetLabKitValueByEventCustomerResultId(eventCustomerResultIds, (long)TestType.IFOBT, (long)ReadingLabels.IFOBTSerialKey);
            var eventCustomerResultIdMicroAlbuminValuePair = _eventCustomerResultRepository.GetLabKitValueByEventCustomerResultId(eventCustomerResultIds, (long)TestType.UrineMicroalbumin, (long)ReadingLabels.MicroalbuminSerialKey);

            if (eventCustomerResultIdIfobtValuePair == null)
                eventCustomerResultIdIfobtValuePair = new List<OrderedPair<long, string>>();
            if (eventCustomerResultIdMicroAlbuminValuePair == null)
                eventCustomerResultIdMicroAlbuminValuePair = new List<OrderedPair<long, string>>();

            foreach (var eventCustomerResult in eventCustomerResultCollection)
            {
                var customer = customers.FirstOrDefault(x => x.CustomerId == eventCustomerResult.CustomerId);
                var @event = events.FirstOrDefault(x => x.Id == eventCustomerResult.EventId);
                var host = hosts.FirstOrDefault(x => x.Id == @event.HostId);
                var fobtKit = eventCustomerResultIdIfobtValuePair.Any(x => x.FirstValue == eventCustomerResult.Id && !string.IsNullOrEmpty(x.SecondValue));
                var microAlbuminKit = eventCustomerResultIdMicroAlbuminValuePair.Any(x => x.FirstValue == eventCustomerResult.Id && !string.IsNullOrEmpty(x.SecondValue));
                var physicianLabTest = physicianLabTests.FirstOrDefault(x => x.StateId == host.Address.StateId);

                var viewmodel = _biWeeklyMicroAlbuminFobtReportFactory.CreateModel(customer, @event.EventDate, fobtKit, microAlbuminKit, physicianLabTest);
                collection.Add(viewmodel);
            }

            listModel.Collection = collection;
            return listModel;
        }
    }
}
