using System;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HafGenerationSubscriber : IHafGenerationSubscriber
    {
        private readonly IHafGenerationService _hafGenerationService;
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
        public HafGenerationSubscriber(ILogManager logManager, ISettings settings, IHafGenerationService hafGenerationService)
        {
            _hafGenerationService = hafGenerationService;
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
            _logger = logManager.GetLogger("HafGenerationSubscriber");
        }

        public void PollForHafGenerationSubscriber()
        {
            _logger.Info("Generate HAF Subscriber  Started");
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.GenerateBulkHafChannel, RequestSubcriberChannelNames.GenerateBulkHafQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.GenerateBulkHafChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.GenerateBulkHafQueue);

                sub.Subscribe(RequestSubcriberChannelNames.GenerateBulkHafChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.GenerateBulkHafQueue);
                    while (item != null)
                    {
                        try
                        {
                            var eventId = Newtonsoft.Json.JsonConvert.DeserializeObject<long>(item);
                            if (eventId > 0)
                            {
                                _logger.Info(string.Format("Thread Starting For HAF Generation Event Id : {0}", eventId));

                                var thread = new Thread(() => _hafGenerationService.GenerateHafAssessment(eventId));
                                thread.Start();

                                _logger.Info(string.Format("Thread Started For HAF Generation Event Id  : {0}", eventId));
                            }
                            else
                            {
                                _logger.Info(string.Format("json is null for HAF printing"));
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Generating HAF Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                        }
                        item = _db.ListRightPop(RequestSubcriberChannelNames.GenerateBulkHafQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error("Generating HAF For Failed. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }
    }
}