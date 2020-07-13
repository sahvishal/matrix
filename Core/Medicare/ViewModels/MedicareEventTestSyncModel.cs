using System.Collections.Generic; 

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareEventTestSyncModel
    {
        public string OrganizationName { get; set; }
        public string TimeToken { get; set; }
        public string Tag { get; set; }
        public List<MedicareEventTestModel> EventTestAliases { get; set; } 
    }
}
