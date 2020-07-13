using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class LoincLabDataModel
    {
        public string MemberId { get; set; }
        public string Gmpi { get; set; }
        public string Loinc { get; set; }
        public string LoincDescription { get; set; }
        public string ResultValue { get; set; }
        public string ResultUnits { get; set; }
        public string RefRange { get; set; }
        public string LongDescription { get; set; }
        public DateTime? DoS { get; set; }
    }
}
