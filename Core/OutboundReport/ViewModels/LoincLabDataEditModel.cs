namespace Falcon.App.Core.OutboundReport.ViewModels
{
    public class LoincLabDataEditModel
    {
        public string MemberId { get; set; }
        public string Gmpi { get; set; }
        public string Loinc { get; set; }
        public string LoincDescription { get; set; }
        public string ResultValue { get; set; }
        public string ResultUnits { get; set; }
        public string RefRange { get; set; }
        public string DoS { get; set; }

        public bool IsEmpty()
        {
            return (string.IsNullOrEmpty(MemberId) && string.IsNullOrEmpty(Gmpi)
                && string.IsNullOrEmpty(Loinc) && string.IsNullOrEmpty(LoincDescription)
                    && string.IsNullOrEmpty(ResultValue) && string.IsNullOrEmpty(ResultUnits)
                    && string.IsNullOrEmpty(RefRange));
        }
    }
}
