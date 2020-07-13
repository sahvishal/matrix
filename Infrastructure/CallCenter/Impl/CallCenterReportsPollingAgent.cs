using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class CallCenterReportsPollingAgent : BaseReportPollingAgent, ICallCenterReportsPollingAgent
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

        public CallCenterReportsPollingAgent(ILogManager logManager, ISettings settings)
            : base(settings)
        {
            _logger = logManager.GetLogger("Call Center Reports");
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
                _logger.Info("Process Report. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }
        // Call Center

        public void PollForCallQueueReportReports()
        {
            PollForCallQueueReport();
            PollForOutreachCallReport();
            PollForUncontactedCustomersReport();
            PollForCallQueueSchedulingReport();
            PollForCallQueueExcludedCustomerReport();
            PollForAgentConversionReport();
            PollForCallQueueCustomersReport();
            PollForCustomerWithNoEventsInAreaReport();
            PollForCallCenterCallReport();
            PollForConfirmationReport();
            PollForCallSkippedReport();
            PollForExcludedCustomerReport();
            PollForPreAssessmentReport();
        }

        private void PollForCallQueueReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallQueueReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallQueueReportChannel, RequestSubcriberChannelNames.CallQueueReportQueue);
        }

        private void PollForOutreachCallReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.OutreachCallReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.OutreachCallReportChannel, RequestSubcriberChannelNames.OutreachCallReportQueue);
        }

        private void PollForUncontactedCustomersReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.UncontactedCustomersReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.UncontactedCustomersReportChannel, RequestSubcriberChannelNames.UncontactedCustomersReportQueue);
        }

        private void PollForCallQueueSchedulingReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallQueueSchedulingReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallQueueSchedulingReportChannel, RequestSubcriberChannelNames.CallQueueSchedulingReportQueue);
        }

        private void PollForCallQueueExcludedCustomerReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallQueueExcludedCustomerReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallQueueExcludedCustomerReportChannel, RequestSubcriberChannelNames.CallQueueExcludedCustomerReportQueue);
        }

        private void PollForAgentConversionReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.AgentConversionReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.AgentConversionReportChannel, RequestSubcriberChannelNames.AgentConversionReportQueue);
        }

        private void PollForCallQueueCustomersReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallQueueCustomersReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallQueueCustomersReportChannel, RequestSubcriberChannelNames.CallQueueCustomersReportQueue);
        }

        private void PollForCustomerWithNoEventsInAreaReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CustomerWithNoEventsInAreaReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CustomerWithNoEventsInAreaReportChannel, RequestSubcriberChannelNames.CustomerWithNoEventsInAreaReportQueue);
        }

        private void PollForCallCenterCallReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallCenterCallReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallCenterCallReportChannel, RequestSubcriberChannelNames.CallCenterCallReportQueue);
        }

        private void PollForConfirmationReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.ConfirmationReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.ConfirmationReportChannel, RequestSubcriberChannelNames.ConfirmationReportQueue);
        }

        private void PollForCallSkippedReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.CallSkippedReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.CallSkippedReportChannel, RequestSubcriberChannelNames.CallSkippedReportQueue);
        }

        private void PollForExcludedCustomerReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.ExcludedCustomerReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.ExcludedCustomerReportChannel, RequestSubcriberChannelNames.ExcludedCustomerReportQueue);
        }

        private void PollForPreAssessmentReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.PreAssessmentReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.PreAssessmentReportChannel, RequestSubcriberChannelNames.PreAssessmentReportQueue);
        }
    }
}
