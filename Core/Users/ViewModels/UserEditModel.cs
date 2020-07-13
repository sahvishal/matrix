using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserEditModel : BaseUserEditModel
    {

        public IEnumerable<OrganizationRoleUserModel> UsersRoles { get; set; }


        [Bindable(false)]
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public TechnicianModel TechnicianProfile { get; set; }

        public PhysicianModel PhysicianProfile { get; set; }

        public CustomerEditModel CustomerProfile { get; set; }

        public AccountCoordinatorProfileModel AccountCoordinatorProfile { get; set; }

        public string Npi { get; set; }

        public string Credential { get; set; }

        public UserEditModel()
        {
            IsLocked = false;
            Address = new AddressEditModel();
            TechnicianProfile = new TechnicianModel();
            PhysicianProfile = new PhysicianModel();
            AccountCoordinatorProfile = new AccountCoordinatorProfileModel();
        }
    }

}