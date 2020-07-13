using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    using Falcon.App.Core.Scheduling;

    [DefaultImplementation]
    public class SurveyEmailPollingAgent : ISurveyEmailPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPodRepository _podRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public SurveyEmailPollingAgent(IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IPodRepository podRepository,
                IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, ILogManager logManager, ICorporateAccountRepository corporateAccountRepository, IEmailTemplateRepository emailTemplateRepository)
        {
            _eventRepository = eventRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _podRepository = podRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger<SurveyEmailPollingAgent>();
            _notifier = notifier;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
        }

        public void PollforSurveyEmails()
        {
            var filter = new EventBasicInfoViewModelFilter { DateFrom = DateTime.Now.Date.AddDays(-1), DateTo = DateTime.Now.Date.AddDays(-1) };

            int totalRecords;
            var events = _eventRepository.GetEventsbyFilters(filter, 1, 100, out totalRecords); // Assuming there will be no mre than 100 events in one single day

            _logger.Info("\n\n");
            _logger.Info("---------------------------- Survey Emails -------------------------------------");

            if (events == null || !events.Any())
            {
                _logger.Info("No Events found!");
                return;
            }
            try
            {
                foreach (var @event in events)
                {
                    if (@event.Status != EventStatus.Active) continue;//|| @event.AccountId.HasValue

                    var account = _corporateAccountRepository.GetbyEventId(@event.Id);
                    if (account != null && !(account.SendSurveyMail && account.SurveyMailTemplateId > 0))
                        continue;

                    _logger.Info(string.Format("Starting for {0} dated {1}", @event.Name, @event.EventDate.ToShortDateString()));
                    var pods = _podRepository.GetPodsForEvent(@event.Id);

                    var eventCustomers = _eventCustomerRepository.GetbyEventId(@event.Id);
                    eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue).ToArray();

                    var customerIds = eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();
                    var customers = _customerRepository.GetCustomers(customerIds);

                    string emailTemplateAlias = EmailTemplateAlias.SurveyEmailNotification;

                    if (account != null && account.SurveyMailTemplateId > 0)
                    {
                        var emailTemplate = ((IUniqueItemRepository<EmailTemplate>)_emailTemplateRepository).GetById(account.SurveyMailTemplateId);
                        emailTemplateAlias = emailTemplate.Alias;
                    }

                    foreach (var customer in customers)
                    {
                        if ((customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail)) || !customer.EnableEmail) //(customer.DoNotContactReasonId.HasValue && customer.DoNotContactReasonId.Value > 0)
                        {
                            continue;
                        }
                        if (customer.Email == null)
                        {
                            _logger.Info(string.Format("{0} has no Email!", customer.NameAsString));
                            continue;
                        }

                        ServiceNotification(customer, @event, pods, emailTemplateAlias);

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }

        private void ServiceNotification(Customer customer, Event @event, IEnumerable<Pod> pods, string emailTemplateAlias)
        {
            _logger.Info(string.Format("{0} is being sent the survey email!", customer.NameAsString));
            var model = _emailNotificationModelsFactory.GetSurveyNotificationModel(customer, @event, pods);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.SurveyEmailNotification, emailTemplateAlias, model, customer.Id, customer.CustomerId, "Survey Email");
        }
    }
}