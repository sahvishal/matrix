using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
     [DefaultImplementation]
    public class PatientWithNoCustomTagFactory : IPatientWithNoCustomTagFactory
    {
        public PatientWithNoCustomTagViewModel Create(Customer customer, string tests)
        {
            return new PatientWithNoCustomTagViewModel
            {
                CustomerId = customer.CustomerId,
                CorporateTag = customer.Tag,
                PreapprovedTest = tests
            };
        }
    }
}
