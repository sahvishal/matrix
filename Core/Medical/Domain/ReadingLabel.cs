using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ReadingLabel
    {
        public ReadingLabels ReadingId { get; set; }
        public string Label { get; set; }
        public ReadingSource ReadingSource { get; set; }
        public string MeasurementUnit { get; set; }

        public ReadingLabel(int id)
        {
            ReadingId = (ReadingLabels) id;
        }
    }
}