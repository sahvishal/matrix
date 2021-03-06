﻿using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class HealthPlanCustomerExportFilter
    {
        public string CorporateTag { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public CallStatus CallStatus { get; set; }

        public ProspectCustomerTag Tag { get; set; }

        public string[] CustomTags { get; set; }

        public bool ExcludeCustomerWithCustomTag { get; set; }
    }
}
