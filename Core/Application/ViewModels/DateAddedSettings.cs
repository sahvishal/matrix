using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.Application.ViewModels
{
    public class DateAddedSettings
    {
        public long CustomerId { get; set; }
        [Format("MM/dd/yyyy")]
        public DateTime? AddedDate { get; set; }
    }
}
