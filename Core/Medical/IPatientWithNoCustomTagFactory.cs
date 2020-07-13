using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPatientWithNoCustomTagFactory
    {
        PatientWithNoCustomTagViewModel Create(Customer customer,string tests);
    }
}
