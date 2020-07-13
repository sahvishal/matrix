using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPatientInputFileFactory
    {
        PatientInputFileViewModel Create(Customer customer, Event eventData, string serialKey, PrimaryCarePhysician primaryCarePhysician);
    }
}
