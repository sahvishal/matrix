using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ResultReading<T> : DomainObjectBase
    {
        public ReadingLabels Label { get; set; }
        public T Reading { get; set; }
        public ReadingSource? ReadingSource { get; set; }
        public DataRecorderMetaData RecorderMetaData { get; set; }
        public string LableText { get; set; }

        public ResultReading(ReadingLabels readingLabel)
        {
            Label = readingLabel;
        }
        public ResultReading(long id) : base(id) { }
        public ResultReading() { }
    }
}