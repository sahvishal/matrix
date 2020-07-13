using System;
using System.Linq;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Org.BouncyCastle.Asn1.X509;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HafGenerationPublisher : IHafGenerationPublisher
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;

        private readonly ILogger _logger;

        public HafGenerationPublisher(IEventRepository eventRepository, ILogManager logManager, ISettings settings)
        {
            _eventRepository = eventRepository;
            _settings = settings;
            _logger = logManager.GetLogger("HafGenerationPublisher");

        }

        public void PollHafForPublish()
        {
            var events = _eventRepository.GetEventsforGenerateHealthAssesmentForm();

            if (events.IsNullOrEmpty())
            {
                _logger.Info("No Event Found for Generate HealthAssessmentForm");
                return;
            }
            var hafInProgressCount = events.Count(x => x.GenerateHealthAssesmentFormStatus == (long)GenerateHealthAssesmentFormStatus.InProgress);

            var pendingHafEvents = events.Where(x => x.GenerateHealthAssesmentFormStatus == (long)GenerateHealthAssesmentFormStatus.Pending).ToArray();

            if (hafInProgressCount >= _settings.NumberOfMaximumPrintInProgress)
            {
                _logger.Info("Maximum Number of Thread already opened. ");
                return;
            }

            if (pendingHafEvents.IsNullOrEmpty())
            {
                _logger.Info("No Event Waiting for HAF Generation");
                return;
            }

            var newThreadToBeOpend = (_settings.NumberOfMaximumPrintInProgress - hafInProgressCount);

            pendingHafEvents = pendingHafEvents.Take(newThreadToBeOpend).ToArray();

            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();

            foreach (var eventData in pendingHafEvents)
            {

                var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(eventData.Id);
                db.ListLeftPush(RequestSubcriberChannelNames.GenerateBulkHafQueue, serialisedObject);

                try
                {
                    sub.Publish(RequestSubcriberChannelNames.GenerateBulkHafChannel, "", CommandFlags.FireAndForget);
                    _eventRepository.SetGenrateHealthAssesmentFormStatus(eventData.Id, true, (long)GenerateHealthAssesmentFormStatus.InProgress);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    var length = db.ListLength(RequestSubcriberChannelNames.GenerateBulkHafQueue);
                    if (length > 0)
                    {
                        _logger.Error("Queue name:" + RequestSubcriberChannelNames.GenerateBulkHafQueue + " and Length:" + length);
                        db.ListLeftPop(RequestSubcriberChannelNames.GenerateBulkHafQueue);
                    }
                    _logger.Error("Exception occurred while publishing HAF Bulk. Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }
            }
        }
    }
}
