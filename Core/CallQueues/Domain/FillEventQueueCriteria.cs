using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class FillEventQueueCriteria
    {
        public long CallQueueId { get; set; }
        public decimal FillPercentage { get; set; }
        public int NoOfDays { get; set; }
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
