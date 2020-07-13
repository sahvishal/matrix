using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Medicare
{
    public interface ISyncMedicationPollingAgent
    {
        void Sync();
        void SyncMedicationData(ILogger logger, long modifiedBy, bool? syncAfterUpload = null, long? customerId = null);
    }
}
