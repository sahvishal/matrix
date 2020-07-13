using System.Collections.Generic;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Users.Impl
{
    public class OrganizationBasicInfoBinder
    {
        public OrganizationBasicInfoModel ToModel(Organization organization, Address businessAddress)
        {
            return new OrganizationBasicInfoModel()
            {
                Address = businessAddress,
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,
                PhoneNumber = organization.PhoneNumber != null ? organization.PhoneNumber.ToString() : string.Empty               
            };
        }

        // Might need a seperate Binder class
        public OrganizationListModel ToModel(IEnumerable<OrganizationBasicInfoModel> basicInfoModels){
            return new OrganizationListModel() { Organizations = basicInfoModels };
        }

    }
}
