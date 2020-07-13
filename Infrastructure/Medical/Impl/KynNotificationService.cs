using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynNotificationService : IKynNotificationService
    {
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventService _eventService;
        private readonly IEmailNotificationModelsFactory _notificationModelsFactory;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IKynHealthAssessmentHelper _kynHealthAssessmentHelper;

        public KynNotificationService(IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService, ICustomerRepository customerRepository, IAppointmentRepository appointmentRepository, 
            IEventService eventService, IEmailNotificationModelsFactory notificationModelsFactory, IEventPodRepository eventPodRepository, IKynHealthAssessmentHelper kynHealthAssessmentHelper)
        {
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _customerRepository = customerRepository;
            _appointmentRepository = appointmentRepository;
            _eventService = eventService;
            _notificationModelsFactory = notificationModelsFactory;
            _eventPodRepository = eventPodRepository;
            _kynHealthAssessmentHelper = kynHealthAssessmentHelper;
        }

        public KynNotificationViewModel IsApplicableForNotification(EventCustomer eventCustomer)
        {
            if (!eventCustomer.AppointmentId.HasValue)
                return null;

            var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventCustomer.EventId);
            if (!isKynIntegrationEnabled)
                return null;

            var tests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventCustomer.EventId, eventCustomer.CustomerId);
            var isKynTestPurchased = tests != null && tests.Any(t => t.Id == (long)TestType.Kyn);
            if (!isKynTestPurchased)
                return null;

            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

            var isDemographicInfoFilled = CheckDemographicInfo(customer);

            var isHafFilled = _kynHealthAssessmentHelper.IsKynHafFilled(eventCustomer.EventId, eventCustomer.CustomerId);

            if (isDemographicInfoFilled && isHafFilled)
                return null;

            var eventHostViewData = _eventService.GetById(eventCustomer.EventId);
            var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

            return _notificationModelsFactory.GetKynNotificationViewModel(customer, eventHostViewData, appointment, isDemographicInfoFilled, isHafFilled);
        }

        private bool CheckDemographicInfo(Customer customer)
        {
            if (customer.Height == null || customer.Height.Inches <= 0)
                return false;
            if (customer.Weight == null || customer.Weight.Pounds <= 0)
                return false;
            if (customer.Gender == Gender.Unspecified)
                return false;
            if (!customer.DateOfBirth.HasValue)
                return false;
            if (!customer.Waist.HasValue || customer.Waist.Value <= 0)
                return false;

            return true;
        }
    }
}
