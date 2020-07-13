using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface ICustomerScreeningViewDataFactory
    {
        CustomerScreeningViewData Create(List<TestResult> testResults, Customer customer, Appointment appointment, Event theEvent, Package package, IEnumerable<Test> tests, Host host, Physician primaryPhysician, Physician overreadPhysician, Core.Finance.Domain.Order order, BasicBiometric basicBiometric);
    }
}
