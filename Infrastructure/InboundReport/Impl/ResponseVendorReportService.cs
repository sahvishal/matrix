using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class ResponseVendorReportService : IResponseVendorReportService
    {
        private readonly IResponseVendorReportFactory _responseVendorReportFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICallCenterCallRepository _callRepository;
        private readonly IPcpDispositionRepository _pcpDispositionRepository;
        private readonly IPcpAppointmentRepository _pcpAppointmentRepository;
        private readonly IBarrierRepository _barrierRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;
        private readonly IChaseCampaignTypeRepository _chaseCampaignTypeRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;
        private readonly ISettings _settings;
        private readonly IXmlSerializer<ResultPdfPostedXml> _resultPdfPostedSerializer;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;

        public ResponseVendorReportService(IResponseVendorReportFactory responseVendorReportFactory, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository, IUniqueItemRepository<Event> eventRepository,
            ILanguageRepository languageRepository, IAppointmentRepository appointmentRepository, ICallCenterCallRepository callRepository, IPcpDispositionRepository pcpDispositionRepository, IPcpAppointmentRepository pcpAppointmentRepository,
            IBarrierRepository barrierRepository, IChaseOutboundRepository chaseOutboundRepository, IChaseCampaignRepository chaseCampaignRepository, IChaseCampaignTypeRepository chaseCampaignTypeRepository,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository, ISettings settings, IXmlSerializer<ResultPdfPostedXml> resultPdfPostedSerializer,
            ICustomerEligibilityRepository customerEligibilityRepository)
        {
            _responseVendorReportFactory = responseVendorReportFactory;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _languageRepository = languageRepository;
            _appointmentRepository = appointmentRepository;
            _callRepository = callRepository;
            _pcpDispositionRepository = pcpDispositionRepository;
            _pcpAppointmentRepository = pcpAppointmentRepository;
            _barrierRepository = barrierRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
            _chaseCampaignTypeRepository = chaseCampaignTypeRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;
            _settings = settings;
            _resultPdfPostedSerializer = resultPdfPostedSerializer;
            _customerEligibilityRepository = customerEligibilityRepository;
        }

        public ListModelBase<ResponseVendorReportViewModel, ResponseVendorReportFilter> GetResponseVendorReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new ResponseVendorReportFilter();
            var responseVendorReportFilter = filter as ResponseVendorReportFilter ?? new ResponseVendorReportFilter();

            var customerIds = _customerRepository.GetCustomersByCustomTag(filter as ResponseVendorReportFilter, pageNumber, pageSize, out totalRecords);
            //var customerIds = _callRepository.GetForResponseVendorReport(filter as ResponseVendorReportFilter, pageNumber, pageSize, out totalRecords);
            if (customerIds.IsNullOrEmpty()) return null;

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);
            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();

            var corporateAccount = _corporateAccountRepository.GetById(((ResponseVendorReportFilter)filter).AccountId);

            var calls = _callRepository.GetCallsForResponseVendorReport(filter as ResponseVendorReportFilter, customerIds);

            var customers = customerIds.Any() ? _customerRepository.GetCustomers(customerIds.ToArray()) : new List<Customer>();

            var eventCustomers = _eventCustomerRepository.GetByEventIdsOrCustomerIds(responseVendorReportFilter.StartDate, customerIds) ?? new List<EventCustomer>();

            var eventIds = eventCustomers.Select(x => x.EventId).ToArray();
            var events = _eventRepository.GetByIds(eventIds);

            var languages = _languageRepository.GetAll();

            var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);
            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            var eventCustomerIds = eventCustomers.Select(x => x.Id);
            var pcpAppointments = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomerIds);
            var pcpDispositions = _pcpDispositionRepository.GetByEventCustomerIds(eventCustomerIds);

            var eventCustomerBarriers = _barrierRepository.GetCustomerBarrierByEventCustomerIds(eventCustomerIds);

            var barrierIds = eventCustomerBarriers.Select(x => x.BarrierId).ToArray();
            var barriers = _barrierRepository.GetByIds(barrierIds);

            var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

            var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds.ToArray());
            var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
            var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

            var campaignTypeIds = chaseCampaigns.Select(x => x.ChaseCampaignTypeId).ToArray();
            var campaignTypes = _chaseCampaignTypeRepository.GetByIds(campaignTypeIds);

            var eventAppointmentCancellatonLogs = _eventAppointmentCancellationLogRepository.GetByEventCustomerIds(eventCustomerIds);

            var resultPostedToPlanFileName = Path.Combine(_settings.ResultPostedToPlanPath, string.Format("resultPostedto_{0}.xml", corporateAccount.Tag));
            var resultPosted = _resultPdfPostedSerializer.Deserialize(resultPostedToPlanFileName);

            var resultPostedCustomers = resultPosted != null ? resultPosted.Customer : new List<CustomerInfo>();

            return _responseVendorReportFactory.Create(customers, languages, eventCustomers, appointments, events, calls, pcpAppointments, pcpDispositions, eventCustomerBarriers, barriers, chaseOutbounds, customerChaseCampaigns,
                chaseCampaigns, campaignTypes, eventAppointmentCancellatonLogs, resultPostedCustomers, customerEligibilities);
        }
    }
}
