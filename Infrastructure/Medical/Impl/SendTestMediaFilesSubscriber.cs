using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using StackExchange.Redis;
using System;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SendTestMediaFilesSubscriber : ISendTestMediaFilesSubscriber
    {
        private readonly ISendTestMediaFilesService _sendTestMediaFilesService;
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

        public SendTestMediaFilesSubscriber(ILogManager logManager, ISettings settings, ISendTestMediaFilesService sendTestMediaFilesService)
        {
            _logger = logManager.GetLogger("SendTestMediaFilesSubscriber");
            _sendTestMediaFilesService = sendTestMediaFilesService;
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
        }
        public void PollForSendTestMediaFilesSubscriber()
        {
            _logger.Info("Send Test Media Files Subscriber  Started");
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.IpCopyMediaFilesChannel, RequestSubcriberChannelNames.IpCopyMediaFilesQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.IpCopyMediaFilesChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.IpCopyMediaFilesQueue);

                sub.Subscribe(RequestSubcriberChannelNames.IpCopyMediaFilesChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.IpCopyMediaFilesQueue);
                    while (item != null)
                    {
                        try
                        {
                            var orderedPair = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderedPair<long, long>>(item);
                            if (orderedPair.FirstValue > 0 && orderedPair.SecondValue > 0)
                            {
                                _logger.Info(string.Format("Starting Send Test Media Files for EventId : {0}, CustomerId: {1}", orderedPair.FirstValue, orderedPair.FirstValue));

                                _sendTestMediaFilesService.SubscriberForSendTestMediaFiles(orderedPair.FirstValue, orderedPair.SecondValue);

                                _logger.Info(string.Format("Completed For Send Test Media Files for EventId : {0}, CustomerId: {1}", orderedPair.FirstValue, orderedPair.FirstValue));
                            }
                            else
                            {
                                _logger.Info(string.Format("JSON is null for Send Test Media Files"));
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Sending Test Media Files Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                        }
                        item = _db.ListRightPop(RequestSubcriberChannelNames.IpCopyMediaFilesQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error("Sending Test Media Files For Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }
    }
}
