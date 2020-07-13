using System.Collections.Generic;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountModel
    {
        public OrganizationBasicInfoModel OrganizationBasicInfoModel { get; set; }
        public string ContractNotes { get; set; }
        public IEnumerable<string> DefaultPackages { get; set; }
        public bool IsHealthPlan { get; set; }

    }
}
