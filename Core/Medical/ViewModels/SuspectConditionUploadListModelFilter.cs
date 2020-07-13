﻿using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Enum;
using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class SuspectConditionUploadListModelFilter : ModelFilterBase
    {
        public string Name { get; set; }
        public long? UploadedBy { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public SuspectConditionUploadStatus? Status { get; set; }

        public bool IsEmpty()
        {
            return FromDate == null && ToDate == null && string.IsNullOrWhiteSpace(Name) && Status == null && UploadedBy == null;
        }
    }
}