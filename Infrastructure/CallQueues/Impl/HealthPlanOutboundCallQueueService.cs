using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanOutboundCallQueueService : IHealthPlanOutboundCallQueueService
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly IOutboundCallQueueListModelFactory _outboundCallQueueListModelFactory;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IAccountCallQueueSettingRepository _accountCallQueueSettingRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISettings _settings;

        public HealthPlanOutboundCallQueueService(ICallQueueCustomerRepository callQueueCustomerRepository, ICustomerRepository customerRepository, ICallCenterCallRepository callCenterCallRepository,
            ICallCenterNotesRepository callCenterNotesRepository, IOutboundCallQueueListModelFactory outboundCallQueueListModelFactory,
            IProspectCustomerRepository prospectCustomerRepository, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, ISettings settings,
            IAccountCallQueueSettingRepository accountCallQueueSettingRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _customerRepository = customerRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _outboundCallQueueListModelFactory = outboundCallQueueListModelFactory;
            _prospectCustomerRepository = prospectCustomerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _settings = settings;
            _accountCallQueueSettingRepository = accountCallQueueSettingRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public OutboundCallQueueListModel GetOutboundCallRoundCallQueue(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetOutboundCallRoundCallQueue(filter, filter.PageNumber, pageSize, callQueue, criteriaId, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);

        }

        public OutboundCallQueueListModel GetOutboundFillEventCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomerForHealthPlanFillEvents(filter, filter.PageNumber, pageSize, criteriaId, callQueue, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);
        }

        public OutboundCallQueueListModel GetnOutboundNoshowCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetNoShowCallQueueCustomer(filter, filter.PageNumber, pageSize, criteriaId, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);
        }

        public OutboundCallQueueListModel GetnOutboundZipRadiusCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetZipRadiusCallQueueCustomer(filter, filter.PageNumber, pageSize, criteriaId, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);
        }

        public OutboundCallQueueListModel GetnOutboundUncontactedCustomersCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetUncontactedCallQueueCustomers(filter, filter.PageNumber, pageSize, criteriaId, _settings.NeverBeenCalledInDays, _settings.NoPastAppointmentInDaysUncontactedCustomers, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);
        }

        public OutboundCallQueueListModel GetOutboundMailRoundCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetMailRoundCallqueueCustomer(filter, filter.PageNumber, pageSize, criteriaId, callQueue, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);
        }

        public OutboundCallQueueListModel GetOutboundLanuageBarrierCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords)
        {
            var callQueueCustomers = _callQueueCustomerRepository.GetLanguageBarrierCallQueueCustomer(filter, filter.PageNumber, pageSize, criteriaId, callQueue, out totalRecords);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new OutboundCallQueueListModel { IsQueueGenerated = true };
            }

            return OutboundCallQueueListModel(callQueueCustomers, filter.CustomCorporateTag);
        }

        private OutboundCallQueueListModel OutboundCallQueueListModel(IEnumerable<CallQueueCustomer> callQueueCustomers, string customerTags)
        {
            var customerIds = callQueueCustomers.Where(cqc => cqc.CustomerId.HasValue && cqc.CustomerId.Value > 0).Select(cqc => cqc.CustomerId.Value).ToArray();
            IEnumerable<Customer> customers = null;

            if (customerIds.Any())
            {
                customerIds = customerIds.Distinct().ToArray();
                customers = _customerRepository.GetCustomers(customerIds);
            }

            var prospectCustomers = _prospectCustomerRepository.GetProspectCustomersByCustomerIds(customerIds);

            var callQueueCustomerCalls = _callCenterCallRepository.GetCallForHealtPlanCallQueueCustomer(customerIds, customerTags);

            IEnumerable<CallCenterNotes> callCenterNotes = null;

            if (callQueueCustomerCalls != null && callQueueCustomerCalls.Any())
            {
                callCenterNotes = _callCenterNotesRepository.GetByCallIds(callQueueCustomerCalls.Select(s => s.CallId));
            }

            var corporateCustomTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

            return _outboundCallQueueListModelFactory.SystemGeneratedCallQueueCustomers(callQueueCustomers, customers, prospectCustomers, callQueueCustomerCalls, callCenterNotes, null, null, corporateCustomTags);
        }

        public void GetAccountCallQueueSettingForCallQueue(OutboundCallQueueFilter filter)
        {
            filter.NumberOfDays = filter.NumberOfDaysForOthers = filter.NumberOfDaysForLeftVoiceMail = _settings.CustomerReturnInCallQueue;
            filter.NumberOfDaysForRefusedCustomer = _settings.RefusedCustomerReturnInCallQueue;

            if (filter.HealthPlanId > 0 && filter.CallQueueId > 0)
            {
                var accountCallQueueSettings = _accountCallQueueSettingRepository.GetByAccountIdAndCallQueueId(filter.HealthPlanId, filter.CallQueueId);

                var callQueueSetting = accountCallQueueSettings.FirstOrDefault(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.Others);
                if (callQueueSetting != null && callQueueSetting.NoOfDays > 0)
                {
                    filter.NumberOfDaysForOthers = callQueueSetting.NoOfDays;
                }

                callQueueSetting = accountCallQueueSettings.FirstOrDefault(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.LeftVoiceMail);
                if (callQueueSetting != null && callQueueSetting.NoOfDays > 0)
                {
                    filter.NumberOfDaysForLeftVoiceMail = callQueueSetting.NoOfDays;
                }
                else
                {
                    filter.NumberOfDaysForLeftVoiceMail = filter.NumberOfDaysForOthers;
                }

                callQueueSetting = accountCallQueueSettings.FirstOrDefault(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.RefuseCustomer);
                if (callQueueSetting != null && callQueueSetting.NoOfDays > 0)
                {
                    filter.NumberOfDaysForRefusedCustomer = callQueueSetting.NoOfDays;
                }

                var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(filter.HealthPlanId);
                filter.IsMaxAttemptPerHealthPlan = account.IsMaxAttemptPerHealthPlan;
                if (account.IsMaxAttemptPerHealthPlan)
                {
                    filter.MaxAttempt = account.MaxAttempt.HasValue ? account.MaxAttempt.Value : 0;
                }
                else
                {
                    callQueueSetting = accountCallQueueSettings.FirstOrDefault(x => x.SuppressionTypeId == (long)CallQueueSuppressionType.MaxAttempts);
                    if (callQueueSetting != null && callQueueSetting.NoOfDays > 0)
                    {
                        filter.MaxAttempt = callQueueSetting.NoOfDays;
                    }
                }

                filter.DaysForAppointmentConfirmation = account.EventConfirmationBeforeDays.HasValue ? account.EventConfirmationBeforeDays.Value : 0;
                filter.ConfirmationBeforeAppointmentMinutes = account.ConfirmationBeforeAppointmentMinutes.HasValue ? account.ConfirmationBeforeAppointmentMinutes.Value : 0;
            }

        }
    }

}