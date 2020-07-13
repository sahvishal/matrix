using Falcon.App.Core.CCD.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CCD
{
    public interface IClinicalDocumentFactory
    {
        ClinicalDocument Create(EventCustomerResult eventCustomerResult, Customer customer, PrimaryCarePhysician pcp, Event theEventData);
    }
}
