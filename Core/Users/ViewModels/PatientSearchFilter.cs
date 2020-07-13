using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Users.ViewModels
{
    [NoValidationRequired]
    public class PatientSearchFilter
    {
        public long? CustomerId { get; set; }

        public string MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
