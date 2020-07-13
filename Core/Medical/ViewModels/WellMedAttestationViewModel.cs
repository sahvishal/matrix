using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class WellMedAttestationViewModel : ViewModelBase
    {
        public long Id { get; set; }
        public long EventCustomerResultId { get; set; }
        public string DiagnosisCode { get; set; }
        public DateTime ReferenceDate { get; set; }
        public long StatusId { get; set; }
        public long ProviderSignatureFileId { get; set; }
        public string FullPrintedName { get; set; }
        public DateTime DiagnosisDate { get; set; }

        public string ProviderSignaturePath { get; set; }
        public FileModel ProviderSignatureImage { get; set; }
    }
}
