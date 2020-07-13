using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation]
    public class MedicalVendorListModelFactory : IMedicalVendorListModelFactory
    {
        public MedicalVendorListModel Create(IEnumerable<MedicalVendor> medicalVendors, OrganizationListModel orgListModel,IEnumerable<OrderedPair<long, string>> contracts)
        {
            var model = new MedicalVendorListModel();
            var basicModels = new MedicalVendorModel[medicalVendors.Count()];
            var index = 0;
            foreach (var medicalVendor in medicalVendors)
            {
                basicModels[index++] = new MedicalVendorModel()
                                           {
                                               Contract =
                                                   contracts.Where(c => c.FirstValue == medicalVendor.Id).Select(
                                                       c => c.SecondValue).FirstOrDefault(),
                                               MedicalVendorType = medicalVendor.MedicalVendorType,
                                               OrganizationBasicInfoModel =
                                                   orgListModel.Organizations.Where(o => o.Id == medicalVendor.Id).
                                                   FirstOrDefault()
                                           };
            }
            model.MedicalVendors = basicModels;
            return model;
        }
    }
}
