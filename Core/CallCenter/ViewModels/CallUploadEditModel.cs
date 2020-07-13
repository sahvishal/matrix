using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallUploadEditModel: ViewModelBase
    {       
        public string UploadCsvMediaUrl { get; set; }        
    }
}
