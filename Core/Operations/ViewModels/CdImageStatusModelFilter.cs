using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CdImageStatusModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Vehicle { get; set; }

        public CdImageStatusModelFilter()
        {
            Vehicle = string.Empty;
        }
    }
}