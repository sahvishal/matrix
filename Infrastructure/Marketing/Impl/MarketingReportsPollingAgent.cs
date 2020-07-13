using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Infrastructure.Application.Impl;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Marketing.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class MarketingReportsPollingAgent : BaseReportPollingAgent, IMarketingReportsPollingAgent
    {
        private IDatabase _db;
        private ConnectionMultiplexer _redis; 
        private readonly ILogger _logger;

        public MarketingReportsPollingAgent(ILogManager logManager, ISettings settings)
            : base(settings)
        {
            _logger = logManager.GetLogger("Marketing Reports");
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

        public void PollForAbandonedProspectCustomerReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateAbandonedProspectCustomerReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateAbandonedProspectCustomerReportChannel, RequestSubcriberChannelNames.GenerateAbandonedProspectCustomerReportQueue);
          
        }
         
    }
}
