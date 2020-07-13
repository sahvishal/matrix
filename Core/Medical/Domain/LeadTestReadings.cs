namespace Falcon.App.Core.Medical.Domain
{
    public class LeadTestReadings
    {
        public ResultReading<decimal?> CFAPSV { get; set; }
        public ResultReading<decimal?> PSFAPSV { get; set; }
        public StandardFinding<decimal> Finding { get; set; }

        public ResultReading<bool?> NoVisualPlaque { get; set; }
        public ResultReading<bool?> VisuallyDemonstratedPlaque { get; set; }
        public ResultReading<bool?> ModerateStenosis { get; set; }
        public ResultReading<bool?> PossibleOcclusion { get; set; }
    }
}
