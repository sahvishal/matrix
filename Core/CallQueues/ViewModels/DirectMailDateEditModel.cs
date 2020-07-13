using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class DirectMailDateEditModel
    {
        public long ActivityId { get; set; }

        public DateTime ActivityDate { get; set; }
    }
}
