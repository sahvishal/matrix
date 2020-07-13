using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPotentialPcpChangeReportFactory
    {
        PotentialPcpChangeReportViewModel CreateModel(PrimaryCarePhysician oldPcpDetails, PrimaryCarePhysician newPcpDetails, Customer customerInfo);
    }
}
