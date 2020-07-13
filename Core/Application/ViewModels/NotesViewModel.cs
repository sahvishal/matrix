using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.Application.ViewModels
{
    [NoValidationRequired]
    public class NotesViewModel
    {
        public string Note { get; set; }
        public DateTime? EnteredOn { get; set; }
        public string CreatedByUser { get; set; }
    }
}