using System;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CustomerCallNotesViewModel
    {
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public long? EventId { get; set; }
        public CustomerRegistrationNotesType NotesType { get; set; }
        public string Reason { get; set; }
    }
}