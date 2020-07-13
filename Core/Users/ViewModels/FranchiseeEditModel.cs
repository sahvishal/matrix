using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class FranchiseeEditModel : OrganizationEditModel
    {
        public FranchiseeEditModel()
        {
            OrganizationType = Enum.OrganizationType.Franchisee;
        }

        public Pod[] AllocatedPods { get; set; }

    }
}
