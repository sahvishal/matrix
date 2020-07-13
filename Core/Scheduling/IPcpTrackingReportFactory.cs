using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPcpTrackingReportFactory
    {
        IEnumerable<PcpTrackingReportViewModel> Create(IEnumerable<Customer> customers, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians,
            IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<Organization> organizations);
    }
}
