using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Infrastructure.Application.Impl;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class SchedulingReportsPollingAgent : BaseReportPollingAgent, ISchedulingReportsPollingAgent
    {
        private IDatabase _db;
        private ConnectionMultiplexer _redis;
        private readonly ILogger _logger;

        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    var config = ConfigurationOptions.Parse(Host);
                    config.ConnectTimeout = 5000;
                    _redis = ConnectionMultiplexer.Connect(config);
                }
                return _redis;
            }
        }

        public SchedulingReportsPollingAgent(ILogManager logManager, ISettings settings)
            : base(settings)
        {
            _logger = logManager.GetLogger("Scheduling Reports");
        }

        private void ReportsPollingAgent(string channel, string queue)
        {
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(channel);
                _db = redis.GetDatabase(RedisDatabaseKey);
                _db.KeyDelete(queue);

                sub.Subscribe(channel, delegate
                {
                    string item = _db.ListRightPop(queue);
                    while (item != null)
                    {
                        var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GenericReportRequest>(item);
                        try
                        {
                            ProcessReports(request);
                            _db.StringSet(request.Guid, "Completed");
                        }
                        catch (Exception)
                        {
                            _db.StringSet(request.Guid, "Failed");
                        }
                        item = _db.ListRightPop(queue);
                    }
                });
                _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", channel, queue));
            }
            catch (Exception ex)
            {
                _logger.Info("Process Appointment Booked Report. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }

        public void PollForSchedulingReports()
        {
            PollForAppointmentBookedReport();
            PollForCancelledCustomerReport();
            PollForPublicEventVolumeReport();
            PollForCorporateEventVolumeReport();
            PollForCustomerScheduleReport();
            PollForNoShowCustomerReports();
            PollForCustomerExportReports();
            PollForRescheduleAppointmentReports();
            PollForEventCancelationReports();
            PollForTestBookedReports();
            PollForPcpAppointmentDispositionReports();
            PollForClientEventVolumeReports();
            PollForMemberStatusReports();
            PollFoDailyVolumeReports();
            PollForCustomerLeftWithoutScreeningReports();
            PollForVoiceMailReminderReports();
            PollForTextReminderReports();
            PollForHealthPlanEventReports();
            PollForCorporateEventCustomerReport();
            PollForPcpTrackingReport();
        }

        private void PollForAppointmentBookedReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateAppointmentBookedReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateAppointmentBookedReportChannel, RequestSubcriberChannelNames.GenerateAppointmentBookedReportQueue);
        }

        private void PollForCancelledCustomerReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateCancelledCustomerReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateCancelledCustomerReportChannel, RequestSubcriberChannelNames.GenerateCancelledCustomerReportQueue);
        }

        private void PollForPublicEventVolumeReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GeneratePublicEventVolumeReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GeneratePublicEventVolumeReportChannel, RequestSubcriberChannelNames.GeneratePublicEventVolumeReportQueue);
        }

        private void PollForCorporateEventVolumeReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateCorporateEventVolumeReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateCorporateEventVolumeReportChannel, RequestSubcriberChannelNames.GenerateCorporateEventVolumeReportQueue);
        }

        private void PollForCustomerScheduleReport()
        {

            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateCustomerScheduleReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateCustomerScheduleReportChannel, RequestSubcriberChannelNames.GenerateCustomerScheduleReportQueue);


        }

        //Generic  
        private void PollForNoShowCustomerReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.NoShowCustomerQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.NoShowCustomerChannel, RequestSubcriberChannelNames.NoShowCustomerQueue);
        }

        private void PollForCustomerExportReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CustomerExportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.CustomerExportChannel, RequestSubcriberChannelNames.CustomerExportQueue);
        }

        private void PollForRescheduleAppointmentReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.RescheduleAppointmentQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.RescheduleAppointmentChannel, RequestSubcriberChannelNames.RescheduleAppointmentQueue);
        }

        private void PollForEventCancelationReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.EventCancelationQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.EventCancelationChannel, RequestSubcriberChannelNames.EventCancelationQueue);
        }

        private void PollForTestBookedReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.TestBookedQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.TestBookedChannel, RequestSubcriberChannelNames.TestBookedQueue);
        }

        private void PollForPcpAppointmentDispositionReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PcpAppointmentDispositionQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.PcpAppointmentDispositionChannel, RequestSubcriberChannelNames.PcpAppointmentDispositionQueue);
        }

        private void PollForClientEventVolumeReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateClientEventVolumeReportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateClientEventVolumeReportChannel, RequestSubcriberChannelNames.GenerateClientEventVolumeReportQueue);
        }

        private void PollForMemberStatusReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.MemberStatusReportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.MemberStatusReportChannel, RequestSubcriberChannelNames.MemberStatusReportQueue);
        }

        private void PollFoDailyVolumeReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.DailyVolumeReportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.DailyVolumeReportChannel, RequestSubcriberChannelNames.DailyVolumeReportQueue);
        }

        private void PollForCustomerLeftWithoutScreeningReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CustomerLeftWithoutScreeningQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.CustomerLeftWithoutScreeningChannel, RequestSubcriberChannelNames.CustomerLeftWithoutScreeningQueue);
        }

        private void PollForVoiceMailReminderReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.VoiceMailReminderQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.VoiceMailReminderChannel, RequestSubcriberChannelNames.VoiceMailReminderQueue);
        }

        private void PollForTextReminderReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.TextReminderQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.TextReminderChannel, RequestSubcriberChannelNames.TextReminderQueue);
        }

        private void PollForHealthPlanEventReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.EventReportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.EventReportQueue, RequestSubcriberChannelNames.EventReportQueue);
        }

        private void PollForCorporateEventCustomerReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CorporateEventCustomersQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.CorporateEventCustomersChannel, RequestSubcriberChannelNames.CorporateEventCustomersQueue);
        }

        private void PollForPcpTrackingReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PcpTrackingReportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.PcpTrackingReportChannel, RequestSubcriberChannelNames.PcpTrackingReportQueue);
        }
    }
}
