using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class EFaxHelperService : IEFaxHelperService
    {
        private readonly IEFaxApi _eFaxApi;
        private readonly ILogger _logger;
        private readonly TimeSpan _maximumWaitTime;
        private readonly TimeSpan _timeIntervalToPingApi;
        private const string EfaxSucessStatus = "Success";

        public EFaxHelperService(IEFaxApi eFaxApi, ILogManager logManager, ISettings settings)
        {
            _eFaxApi = eFaxApi;
            _logger = logManager.GetLogger<EFaxHelperService>();
            _maximumWaitTime = settings.MaximumTimeToWaitApi;
            _timeIntervalToPingApi = settings.TimeIntervalToPingApi;
        }

        public EFaxResponse ServiceNotification(NotificationPhone phone, string emergencyFaxNumber)
        {
            if (string.IsNullOrEmpty(emergencyFaxNumber))
            {
                _logger.Error(string.Format("Phone number can not be null or empty user id: {0} \n", phone.UserId));
                throw new Exception("Phone number can not be null or empty \n");
            }

            var eFaxParmaters = new EFaxParmaters
            {
                CustomerId = phone.RequestedBy.ToString(),
                IsHighPriority = false,
                Message = phone.Message,
                RecipientFax = emergencyFaxNumber.Replace("-", ""),
                SendDuplicate = true,
                TransmissionId = phone.Id.ToString()
            };

            return _eFaxApi.SendCreateEFax(eFaxParmaters);
        }

        public EFaxOutboundResponsStatus WaitForServiceToCompleteSending(NotificationPhone notification)
        {
            var waitForServer = _timeIntervalToPingApi;

            EFaxOutboundResponsStatus status = null;
            _logger.Info(string.Format("Enter to get status from API for NotificationId {0}", notification.Id));

            while (waitForServer <= _maximumWaitTime)
            {
                Thread.Sleep(_timeIntervalToPingApi);
                _logger.Info(string.Format("waked Up for NotificationId {0} ", notification.Id));
                try
                {
                    status = _eFaxApi.GetOutboundStatusResponse(notification.Id);
                }
                catch (Exception exception)
                {
                    status = new EFaxOutboundResponsStatus { Classification = "Testing Time out for Notification", Message = "Testing Time out for Notification", Outcome = "Testing Time out for Notification" };
                    _logger.Error(string.Format("Message : {0} \n Stacktrace: {1} \n", exception.Message, exception.StackTrace));
                }
                if (status.Classification.Contains(EfaxSucessStatus))
                {
                    return status;
                }

                waitForServer += _timeIntervalToPingApi;
            }

            _logger.Info(string.Format("all attempt to get status positive fails for NotificationId {0} ", notification.Id));

            return status;
        }

        public Dictionary<string, List<Notification>> CreateGroupByFaxNumber(IEnumerable<Notification> notifications)
        {
            if (!notifications.Any()) return null;

            var faxNumberList = notifications.Select(x => ((NotificationPhone)x).PhoneCell.ToString()).ToArray();
            var distictFaxNumber = faxNumberList.Distinct();

            var dictionary = new Dictionary<string, List<Notification>>();

            foreach (var number in distictFaxNumber)
            {
                dictionary.Add(number, notifications.Where(x => ((NotificationPhone)x).PhoneCell.ToString() == number).ToList());
            }

            return dictionary;
        }
    }
}
