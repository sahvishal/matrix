using System.Collections.Generic;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareUserEditModel
    {

        public long EhrUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string UserName { get; set; }

        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string StateCode { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }

        public string OfficeNumber { get; set; }
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
        public string DefaultRoleAlias { get; set; }

        public List<string> RoleAlias { get; set; }

        public string OrganizationName { get; set; }
        public string Npi { get; set; }
        public string Credential { get; set; }

        public List<string> RemovedRoleAlias { get; set; }

        public string EmployeeId { get; set; }
    }
}
