using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class KynHealthAssessmentEditModel
    {
        public string TotalCholesterol { get; set; } //Lipid TotalCholestrol Reading
        public string HDLCholesterol { get; set; } //Lipid HDL Reading
        public string Triglycerides { get; set; } //Lipid Triglycerides Reading
        public int? Glucose { get; set; } //Lipid Glucose Reading
        public double? HeightInFeet { get; set; } //Customer Edit Model
        public double? HeightInInches { get; set; } //Customer Edit Model
        public double? KynWeight { get; set; }//Customer Edit Model
        public decimal? WaistSize { get; set; }
        public int? PulseRate { get; set; }//ASI pressure Reading Pulse reading
        public int? SystolicPressure { get; set; } //Basic Biometric
        public int? DiastolicPressure { get; set; } //Basic Biometric
        public string Notes { get; set; } //Test Result
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public long FastingStatus { get; set; }
        public int? ManualSystolic { get; set; }
        public int? ManualDiastolic { get; set; }
        public decimal? A1c { get; set; }
        public long TestId { get; set; }
        public long? LdlCholestrol { get; set; }
        public string BodyFat { get; set; }
        public string BoneDensity { get; set; }
        public string Psa { get; set; }
        public string NonHdlCholestrol { get; set; }
        public string Nicotine { get; set; }
        public string Cotinine { get; set; }
        public string Smoker { get; set; }
    }
}