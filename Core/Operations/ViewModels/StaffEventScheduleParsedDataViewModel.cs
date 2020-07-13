using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventScheduleParsedDataViewModel
    {
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string Pod { get; set; }
        public string Role { get; set; }
        public DateTime EventDate { get; set; }
        public bool? IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}