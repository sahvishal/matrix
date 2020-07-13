using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPatientWorksheetService
    {
        PatientWorksheet GetPatientWorksheetModel(long customerId, long eventId);
        PatientWorksheet GetPatientWorksheetModel(Customer customer, Event theEvent, EventCustomer eventCustomer);
    }
}
