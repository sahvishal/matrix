using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ILabFormService
    {
        LabFormViewModel GetIfobtLabFormViewModel(long eventid, long customerid);
        LabFormViewModel GetIfobtLabFormViewModel(Event eventData, Customer customer, Host host);
        LabFormViewModel GetMicroalbumineLabFormViewModel(long eventid, long customerid);
        LabFormViewModel GetMicroalbumineLabFormViewModel(Event eventData, Customer customer, Host host);
    }

}
