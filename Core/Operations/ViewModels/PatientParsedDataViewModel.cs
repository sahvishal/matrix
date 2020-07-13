using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PatientParsedDataViewModel : ViewModelBase
    {
        [DisplayName("HIPID")]
        public long CustomerId { get; set; }

        [DisplayName("ACESID")]
        public string AcesId { get; set; }

        public string Error { get; set; }
    }
}
