using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class StandardFinding<T> : DomainObjectBase 
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public long? ResultInterpretation { get; set; }
        public long? PathwayRecommendation { get; set; }

        public T MinValue { get; set; }
        public T MaxValue { get; set; }
        public long CustomerEventStandardFindingId { get; set; }

        public int? WorstCaseOrder { get; set; }
        
        public StandardFinding()
        {}

        public StandardFinding(long id)
            : base(id)
        {}

    }
}
