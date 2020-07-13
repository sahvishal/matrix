using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IUnableToScreenStatusRepository
    {
        List<UnableScreenReason> GetAllUnableToScreenReasons(long testId);
        IEnumerable<TestUnabletoScreenViewModel> GetUnabletoScreenView(IEnumerable<long> eventCustomerResultIds);
    }
}
