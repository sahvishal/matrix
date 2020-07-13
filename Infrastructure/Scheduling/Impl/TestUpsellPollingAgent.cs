using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class TestUpsellPollingAgent : ITestUpsellPollingAgent
    {
        private readonly ILogger _logger;

        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;

        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;

        public TestUpsellPollingAgent(ILogManager logManager, INotificationTypeRepository notificationTypeRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier,
            IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IEventTestRepository eventTestRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository)
        {
            _logger = logManager.GetLogger<TestUpsellPollingAgent>();
            _notificationTypeRepository = notificationTypeRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;

            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _eventTestRepository = eventTestRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
        }

        public void PollForTestUpsell()
        {
            var notificationTypes = _notificationTypeRepository.GetAll();

            var notificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.TestUpsellNotification) && nt.IsActive);

            if (!notificationIsActive)
                return;

            var eventCustomers = _eventCustomerRepository.GetEventCustomersForTestUpsellNotification(1).ToArray();

            if (!eventCustomers.Any())
                return;
            eventCustomers = eventCustomers.OrderBy(ec => ec.EventId).ToArray();

            long eventId = 0;
            IEnumerable<EventTest> eventTests = null;
            foreach (var eventCustomer in eventCustomers)
            {
                try
                {
                    if (eventId != eventCustomer.EventId)
                    {
                        eventId = eventCustomer.EventId;
                        eventTests = _eventTestRepository.GetTestsForEvent(eventId);
                        if (eventTests != null && eventTests.Any())
                            eventTests = eventTests.Where(et => et.Test.ShowInAlaCarte).Select(et => et).ToArray();
                    }

                    if (!eventTests.Any())
                        return;
                    var order = _orderRepository.GetOrder(eventCustomer.CustomerId, eventId);

                    var purchasedEventTestIds = new List<long>();
                    var packagePurchased = _eventPackageRepository.GetPackageForOrder(order.Id);
                    if (packagePurchased != null)
                    {
                        purchasedEventTestIds.AddRange(packagePurchased.Tests.Select(t=>t.Id).ToList());
                    }

                    var testPurchased = _eventTestRepository.GetTestsForOrder(order.Id);
                    if (testPurchased != null && testPurchased.Any())
                    {
                        purchasedEventTestIds.AddRange(testPurchased.Select(t=>t.Id));
                    }

                    var sendNotification = false;
                    IEnumerable<EventTest> notpurchasedEventTests = null;
                    if (purchasedEventTestIds == null || !purchasedEventTestIds.Any())
                    {
                        notpurchasedEventTests = eventTests;
                        sendNotification = true;
                    }
                    else
                    {
                        notpurchasedEventTests = eventTests.Where(et => !purchasedEventTestIds.Contains(et.Id)).Select(et => et).ToArray();
                        if (notpurchasedEventTests != null && notpurchasedEventTests.Any())
                            sendNotification = true;
                    }

                    if (sendNotification)
                    {
                        var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
                        var tests = notpurchasedEventTests.Select(et => et.Test).ToArray();
                        var testUpsellNotificationModel = _emailNotificationModelsFactory.GetTestUpsellNotificationModel(customer, tests);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.TestUpsellNotification, EmailTemplateAlias.TestUpsellNotification, testUpsellNotificationModel, customer.Id, customer.CustomerId, "TestUpsellNotification");

                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Test Upsell Notification Error For Customer Id : {0} and Event Id {1} \nMessage:{2} \nStackTrace: {3}", eventCustomer.CustomerId, eventCustomer.EventId, ex.Message, ex.StackTrace));
                }
            }
        }
    }
}
