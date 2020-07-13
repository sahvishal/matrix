using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PhysicianEvaluation : DomainObjectBase
    {
        public long PhysicianId { get; set; }
        public long EventCustomerId { get; set; }
        public DateTime EvaluationStartTime { get; set; }
        public DateTime? EvaluationEndTime { get; set; }
        public string IpAddress { get; set; }
        public bool IsPrimaryEvaluator { get; set; }

        public PhysicianEvaluation()
        { }

        public PhysicianEvaluation(long id)
            : base(id)
        { }
    }
}
