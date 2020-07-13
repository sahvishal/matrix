
namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareSuspectConditionListModel
    {
        public string OrganizationName { get; set; }
        public string Token { get; set; }
        public MedicareSuspectConditionViewModel[] SuspectConditions { get; set; }
    }
}
