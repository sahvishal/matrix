using Falcon.App.Core.CallQueues.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanEventZipRepository
    {
        void Save(HealthPlanEventZip healthPlanEventZip);

        IEnumerable<HealthPlanEventZip> GetAll();

        HealthPlanEventZip GetByAccountID(long accountId);

        HealthPlanEventZip GetByTag(string tag);

        IEnumerable<HealthPlanEventZip> GetByIsQueueGenerated(bool isQueueGenerated);

    }
}
