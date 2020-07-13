using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanFillEventCallQueueRepository
    {
        HealthPlanFillEventCallQueue Save(HealthPlanFillEventCallQueue healthPlanFillEventCallQueue);

        IEnumerable<HealthPlanFillEventCallQueue> GetByCriteriaId(long criteriaId);

        bool DeleteByCriteriaId(long criteriaId);

        IEnumerable<long> GetEventIdsByHealthPlanIds(long healthPlanId, long callqueueId);

        void SaveEventZips(long eventId, long zipId);
        void DeleteEventZipByEventIds(IEnumerable<long> eventIds);
        void DeleteEventZipByEventId(long eventId);

        bool IsEventZipAlreadyGenerated(long eventId);
    }
}