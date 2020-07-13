using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class FraminghamCalculationSource : DomainObjectBase
    {
        public ReadingLabels Reading { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

        public int MaleScore { get; set; }
        public int FemaleScore { get; set; }

        public FraminghamCalculationSource() { }
        public FraminghamCalculationSource(long id) : base(id) { }
    }
}
