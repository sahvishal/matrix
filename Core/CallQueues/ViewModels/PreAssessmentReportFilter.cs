﻿using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.ViewModels
{
   [NoValidationRequired]
  public class PreAssessmentReportFilter : ModelFilterBase
  {
      public DateTime? EventDateFrom { get; set; }

      public DateTime? EventDateTo { get; set; }

      public long HealthPlanId { get; set; }

      public string Disposition { get; set; }
  }
}