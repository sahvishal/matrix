using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallQueue : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attempts { get; set; }
        public bool IsActive { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public bool IsQueueGenerated { get; set; }
        public int? QueueGenerationInterval { get; set; }
        public DateTime? LastQueueGeneratedDate { get; set; }
        public long? ScriptId { get; set; }
        public bool IsManual { get; set; }
        public string Category { get; set; }

        public bool IsHealthPlan { get; set; }
        public CallQueue()
        { }

        public CallQueue(long id)
            : base(id)
        { }
    }
}