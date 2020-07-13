using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class CompoundResultReading<T> : ResultReading<T>
    {
        public StandardFinding<T> Finding { get; set; }
        public CompoundResultReading(ReadingLabels readingLabel) : base(readingLabel) { }
        public CompoundResultReading(long id) : base(id) { }
        public CompoundResultReading() { }
    }
}