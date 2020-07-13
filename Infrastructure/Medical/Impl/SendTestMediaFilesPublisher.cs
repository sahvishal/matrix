using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Application.Impl;
using StackExchange.Redis;
using System;
using System.Threading;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SendTestMediaFilesPublisher : ISendTestMediaFilesPublisher
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        public SendTestMediaFilesPublisher(ISettings settings, ILogManager logManager)
        {
            _settings = settings;
            _logger = logManager.GetLogger("SendTestMediaFilesPublisher");
        }

        public void PublishSendTestMediaFiles(long eventId, long customerId)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();

            var orderedPair = new OrderedPair<long, long>()
            {
                FirstValue = eventId,
                SecondValue = customerId
            };
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(orderedPair);

            db.ListLeftPush(RequestSubcriberChannelNames.IpCopyMediaFilesQueue, serialisedObject);

            try
            {
                sub.Publish(RequestSubcriberChannelNames.IpCopyMediaFilesChannel, "", CommandFlags.FireAndForget);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.IpCopyMediaFilesQueue);

                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.IpCopyMediaFilesQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.IpCopyMediaFilesQueue);
                }
                _logger.Error("Exception occurred while publishing Send Test Media Files. Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }
    }
}
