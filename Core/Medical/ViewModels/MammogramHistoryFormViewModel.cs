using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MammogramHistoryFormViewModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public DateTime? Dob { get; set; }
        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber CellPhoneNumber { get; set; }
    }
}
