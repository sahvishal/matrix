using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Application.Impl;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class MedicalReportsPollingAgent : BaseReportPollingAgent, IMedicalReportsPollingAgent
    {
        private IDatabase _db;
        private ConnectionMultiplexer _redis;
        private readonly ILogger _logger;

        public MedicalReportsPollingAgent(ILogManager logManager, ISettings settings)
            : base(settings)
        {
            _logger = logManager.GetLogger("Medical Reports");
        }

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

        public void PollForMedicalReports()
        {
            PollForTechnicalLimitedScreeningReport();
            PollForCustomerEventCriticalDataReport();
            PollForPhysicianTestReviewReport();
            PollForPhysicianReviewSummaryReports();
            PollForPhysicianReviewReports();
            PollForPhysicianQueueReports();
            PollForPhysicianEventQueueReports();
            PollForTestPerformedReports();
            PollForTestNotPerformedReports();
            PollForKynCustomersReports();
            PollForGapsClosureReports();
            PollForEventArchiveStatsReports();
            PollForDisqualifiedTestReports();
        }

        private void PollForTechnicalLimitedScreeningReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateTechnicalLimitedScreeningReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateTechnicalLimitedScreeningReportChannel, RequestSubcriberChannelNames.GenerateTechnicalLimitedScreeningReportQueue);
        }

        private void PollForCustomerEventCriticalDataReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateCustomerEventCriticalDataReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateCustomerEventCriticalDataReportChannel, RequestSubcriberChannelNames.GenerateCustomerEventCriticalDataReportQueue);
        }

        private void PollForPhysicianTestReviewReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GeneratePhysicianTestReviewReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GeneratePhysicianTestReviewReportChannel, RequestSubcriberChannelNames.GeneratePhysicianTestReviewReportQueue);
        }

        private void PollForPhysicianReviewSummaryReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PhysicianReviewSummaryQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.PhysicianReviewSummaryChannel, RequestSubcriberChannelNames.PhysicianReviewSummaryQueue);
        }

        private void PollForPhysicianReviewReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PhysicianReviewQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.PhysicianReviewChannel, RequestSubcriberChannelNames.PhysicianReviewQueue);
        }

        private void PollForPhysicianQueueReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PhysicianQueueQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.PhysicianQueueChannel, RequestSubcriberChannelNames.PhysicianQueueQueue);
        }

        private void PollForPhysicianEventQueueReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PhysicianEventQueueQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.PhysicianEventQueueChannel, RequestSubcriberChannelNames.PhysicianEventQueueQueue);
        }

        private void PollForTestPerformedReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.TestPerformedQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.TestPerformedChannel, RequestSubcriberChannelNames.TestPerformedQueue);
        }

        private void PollForTestNotPerformedReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.TestNotPerformedQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.TestNotPerformedChannel, RequestSubcriberChannelNames.TestNotPerformedQueue);
        }

        private void PollForKynCustomersReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.KynCustomersQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.KynCustomersChannel, RequestSubcriberChannelNames.KynCustomersQueue);
        }

        private void PollForGapsClosureReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GapsClosureReportQueue);
            ReportsPollingAgent(RequestSubcriberChannelNames.GapsClosureReportChannel, RequestSubcriberChannelNames.GapsClosureReportQueue);
        }

        private void PollForEventArchiveStatsReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.EventArchiveStatsQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.EventArchiveStatsChannel, RequestSubcriberChannelNames.EventArchiveStatsQueue);
        }

        private void PollForDisqualifiedTestReports()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.DisqualifiedTestReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.DisqualifiedTestReportChannel, RequestSubcriberChannelNames.DisqualifiedTestReportQueue);
        }
    }
}
