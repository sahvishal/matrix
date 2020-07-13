using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class KynLabValues
    {
        public long EventCustomerResultId { get; set; }
        public int? Glucose { get; set; }
        public int? TotalCholesterol { get; set; }
        public int? Triglycerides { get; set; }
        public int? Hdl { get; set; }
        public long? FastingStatus { get; set; }
        public int? ManualSystolic { get; set; }
        public int? ManualDiastolic { get; set; }
        public decimal? A1c { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long TestId { get; set; }

        public string BodyFat { get; set; }
        public string BoneDensity { get; set; }
        public string Psa { get; set; }
        public string NonHdlCholestrol { get; set; }
        public string Nicotine { get; set; }
        public string Cotinine { get; set; }
        public string Smoker { get; set; }
        public long? LdlCholestrol { get; set; }
        public string Notes { get; set; }
    }
}
