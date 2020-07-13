using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class LoincCrosswalk : DomainObjectBase
    {
        public string LoincNumber { get; set; }
        public string Component { get; set; }
        public string System { get; set; }
        public string MethodType { get; set; }
        public string VersionLastChanged { get; set; }
        public string DefinitionDescription { get; set; }
        public string Formula { get; set; }
        public string Species { get; set; }
        public string ExampleAnswers { get; set; }
        public string SurveyQuestionText { get; set; }
        public string SurveyQuestionSource { get; set; }
        public string UnitsRequired { get; set; }
        public string SubmittedUnits { get; set; }
        public string CdiscCommonTests { get; set; }
        public string Hl7FieldSubfieldId { get; set; }
        public string ExternalCopyrightNotice { get; set; }
        public string ExampleUnits { get; set; }
        public string LongCommonName { get; set; }
        public long UploadId { get; set; }
        public int Year { get; set; }
        public DateTime DateCreated { get; set; }

        public bool IsEmpty()
        {
            return (string.IsNullOrEmpty(LoincNumber) && string.IsNullOrEmpty(Component) && string.IsNullOrEmpty(System) && string.IsNullOrEmpty(MethodType) && string.IsNullOrEmpty(VersionLastChanged) && string.IsNullOrEmpty(DefinitionDescription)
                    && string.IsNullOrEmpty(Formula) && string.IsNullOrEmpty(Species) && string.IsNullOrEmpty(ExampleAnswers) && string.IsNullOrEmpty(SurveyQuestionText) && string.IsNullOrEmpty(SurveyQuestionSource)
                    && string.IsNullOrEmpty(UnitsRequired) && string.IsNullOrEmpty(SubmittedUnits) && string.IsNullOrEmpty(CdiscCommonTests) && string.IsNullOrEmpty(Hl7FieldSubfieldId) && string.IsNullOrEmpty(ExternalCopyrightNotice)
                    && string.IsNullOrEmpty(ExampleUnits) && string.IsNullOrEmpty(LongCommonName));
        }
    }
}
