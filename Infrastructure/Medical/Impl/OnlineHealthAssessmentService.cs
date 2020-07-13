using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class OnlineHealthAssessmentService : IOnlineHealthAssessmentService
    {
        private readonly ICustomerHafQuestionService _customerHafQuestionService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IHealthAssessmentService _healthAssessmentService;
        private readonly ITempcartService _tempcartService;
        private readonly ICustomerService _customerService;

        public OnlineHealthAssessmentService(ICustomerHafQuestionService customerHafQuestionService, ICustomerRepository customerRepository,
            IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService,
            IEventPodRepository eventPodRepository, IHealthAssessmentService healthAssessmentService, ITempcartService tempcartService, ICustomerService customerService)
        {
            _customerHafQuestionService = customerHafQuestionService;
            _customerRepository = customerRepository;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _eventPodRepository = eventPodRepository;
            _healthAssessmentService = healthAssessmentService;
            _tempcartService = tempcartService;
            _customerService = customerService;
        }

        public OnlineHealthAssessmentQuestionModel Get(OnlineHealthAssessmentQuestionModel model)
        {
            var tempCart = model.RequestValidationModel.TempCart;
            var eventId = tempCart.EventId.Value;
            var customerId = tempCart.CustomerId.Value;

            var customer = _customerRepository.GetCustomer(customerId);
            var iskynPurchased = IsTestPurchased(eventId, tempCart.CustomerId.Value, (long)TestType.Kyn);
            var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventId);

            model.HafModel = _customerHafQuestionService.Get(new HafFilter
            {
                CustomerId = tempCart.CustomerId.Value,
                EventId = tempCart.EventId.Value,
                SetChildQuestion = true,
                VersionNumber = 0
            });

            model.Height = customer.Height != null ? (int)customer.Height.TotalInches : 0;
            model.Weight = customer.Weight != null ? (int)customer.Weight.Pounds : 0;
            model.Race = (int)customer.Race;
            model.Waist = customer.Waist;
            model.IsKynPurchased = isKynIntegrationEnabled && iskynPurchased;

            return model;
        }

        public void SaveOnlineHealthAssessment(OnlineHealthAssessmentQuestionAnswer model, TempCart tempCart)
        {
            _healthAssessmentService.Save(new HealthAssessmentEditModel
            {
                CustomerId = tempCart.CustomerId.Value,
                EventId = tempCart.EventId.Value,
                QuestionEditModels = model.QuestionEditModels
            }, 0);

            var customer = _customerRepository.GetCustomer(tempCart.CustomerId.Value);
            customer.Height = model.Height > 0 ? new Height { TotalInches = model.Height } : null;
            customer.Weight = model.Weight > 0 ? new Weight(model.Weight) : null;

            customer.Race = (Race)model.Race;
            customer.Waist = model.Waist;

            _customerService.SaveCustomer(customer,customer.CustomerId);

            if ((!tempCart.IsHafFilled.HasValue || !tempCart.IsHafFilled.Value) && !model.QuestionEditModels.IsNullOrEmpty())
            {
                tempCart.IsHafFilled = true;
            }

            _tempcartService.SaveTempCart(tempCart);
        }

        public bool IsTestPurchased(long eventId, long customerId, long testId)
        {
            var eventTests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);
            var isTestPurchased = eventTests.Any(et => et.Id == testId);
            return isTestPurchased;
        }

    }
}