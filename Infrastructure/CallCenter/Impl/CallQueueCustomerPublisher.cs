using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallQueueCustomerPublisher : ICallQueueCustomerPublisher
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        public CallQueueCustomerPublisher(ISettings settings, ILogManager logManager)
        {
            _settings = settings;
            _logger = logManager.GetLogger("CallQueueCustomerPublisher");
        }

        public bool UpdateCustomerDetailOnCallQueueResponse(CallQueueCustomerPubViewModel pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();

            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue, serialisedObject);
            try
            {
                sub.Publish(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagChannel, "");
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue);
                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateCustomerFlagQueue);
                }

                _logger.Error("Exception occurred while publishing Update Customer Detail. Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            return true;
        }

        public bool UpdateFutreAppointmentFlag(FutureAppointmentFlagViewModel pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();

            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue, serialisedObject);
            try
            {
                sub.Publish(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagChannel, "");
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue);
                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateAppointmentFlagQueue);
                }

                _logger.Error("Exception occurred while publishing Future Appointment Detail. Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            return true;
        }

        public bool UpdateAppointmentCancellationFlag(CancelAppointmentFlagViewModel pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();

            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue, serialisedObject);
            try
            {
                sub.Publish(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagChannel, "");
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue);
                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.CallQueueCustomerUpdateCancellationFlagQueue);
                }

                _logger.Error("Exception occurred while publishing Appointment Cancellation Detail. Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            return true;
        }
    }
}