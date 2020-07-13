using System;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Application.Impl;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberTermByAbsencePublisher : IMemberTermByAbsencePublisher
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        public MemberTermByAbsencePublisher(ISettings settings, ILogManager logManager)
        {
            _settings = settings;
            _logger = logManager.GetLogger("MemberTermByAbsencePublisher");
        }
        public void PublishCorporateUpload(long corporateUploadId)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();

            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(corporateUploadId);
            db.ListLeftPush(RequestSubcriberChannelNames.MemberTermByAbsenceQueue, serialisedObject);

            try
            {
                sub.Publish(RequestSubcriberChannelNames.MemberTermByAbsenceChannel, "", CommandFlags.FireAndForget);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.MemberTermByAbsenceQueue);
                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.MemberTermByAbsenceQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.MemberTermByAbsenceQueue);
                }
                _logger.Error("Exception occurred while publishing Corporate Upload Id. Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }
    }
}