using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    // TODO: To be reviewed
    public class ResultScreeningCommunication : DomainObjectBase
    {
        public OrganizationRoleUser Franchisee { get; set; }
        public OrganizationRoleUser Physician { get; set; }

        public Roles InitiatedBy { get; set; }

        public DateTime DateInitiatedOn { get; set; }
        public DateTime DateRespondedOn { get; set; }

        public string FranchiseeComments { get; set; }
        public string PhysicianComments { get; set; }
    }
}
