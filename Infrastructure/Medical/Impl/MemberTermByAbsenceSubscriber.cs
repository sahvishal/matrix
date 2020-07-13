using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberTermByAbsenceSubscriber : IMemberTermByAbsenceSubscriber
    {
        private readonly IMemberTermByAbsenceService _memberTermByAbsenceService;
        private readonly ILogger _logger;

        private IDatabase _db;
        private ConnectionMultiplexer _redis;
        private readonly string _host;
        private readonly int _redisDatabaseKey;
        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    var config = ConfigurationOptions.Parse(_host);
                    config.ConnectTimeout = 5000;
                    _redis = ConnectionMultiplexer.Connect(config);
                }
                return _redis;
            }
        }

        public MemberTermByAbsenceSubscriber(ILogManager logManager, ISettings settings, IMemberTermByAbsenceService memberTermByAbsenceService)
        {
            _logger = logManager.GetLogger("MemberTermByAbsenceSuscribre");
            _memberTermByAbsenceService = memberTermByAbsenceService;
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
        }

        public void PollForMemerTermByAbsenceSubscriber()
        {
            _logger.Info("Generate HAF Subscriber  Started");
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.MemberTermByAbsenceChannel, RequestSubcriberChannelNames.MemberTermByAbsenceQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.MemberTermByAbsenceChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.MemberTermByAbsenceQueue);

                sub.Subscribe(RequestSubcriberChannelNames.MemberTermByAbsenceChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.MemberTermByAbsenceQueue);
                    while (item != null)
                    {
                        try
                        {
                            var corporateUploadId = Newtonsoft.Json.JsonConvert.DeserializeObject<long>(item);
                            if (corporateUploadId > 0)
                            {
                                _logger.Info(string.Format("Starting Corporate Upload Id : {0}", corporateUploadId));

                                _memberTermByAbsenceService.SubscribeForEligibiltyUpdate(corporateUploadId);
                                
                                _logger.Info(string.Format("Completed For Corporate Upload Id : {0}", corporateUploadId));
                            }
                            else
                            {
                                _logger.Info(string.Format("JSON is null for Corporate Upload Id"));
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Corporate Upload Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                        }
                        item = _db.ListRightPop(RequestSubcriberChannelNames.MemberTermByAbsenceQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to intialize Service. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }
    }
}