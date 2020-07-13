﻿using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Infrastructure.Application.Impl;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class SalesReportsPollingAgent : BaseReportPollingAgent, ISalesReportsPollingAgent
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
        
        public SalesReportsPollingAgent(ILogManager logManager, ISettings settings)
            : base(settings)
        {
            _logger = logManager.GetLogger("Sales Reports"); 
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

        public void PollForSalesReport()
        {
            PollForHospitalPartnerCustomerReport();
            PollForHospitalPartnerEventReportReport();
        }

        private void PollForHospitalPartnerCustomerReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateHospitalPartnerCustomerReportQueue); 

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateHospitalPartnerCustomerReportChannel, RequestSubcriberChannelNames.GenerateHospitalPartnerCustomerReportQueue);
        }

        private void PollForHospitalPartnerEventReportReport()
        {
            _logger.Info("Subscribe for Report Started :" + RequestSubcriberChannelNames.GenerateHospitalPartnerEventReportQueue);

            ReportsPollingAgent(RequestSubcriberChannelNames.GenerateHospitalPartnerEventReportChannel, RequestSubcriberChannelNames.GenerateHospitalPartnerEventReportQueue);
            
        }
    }
}