
using Falcon.App.Core.Interfaces;
namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanEventZipService
    {
        void SaveHealthPlanEventZip(ILogger logger);
        void SaveHealthPlanEventZipForQueueNotGenerated(ILogger logger);
    }
}
