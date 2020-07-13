using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IMedicalVendorListModelFactory
    {
        MedicalVendorListModel Create(IEnumerable<MedicalVendor> medicalVendors, OrganizationListModel orgListModel,
                                      IEnumerable<OrderedPair<long, string>> contracts);
    }
}
