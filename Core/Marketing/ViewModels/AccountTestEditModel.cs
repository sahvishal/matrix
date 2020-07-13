using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Marketing.ViewModels
{
    [NoValidationRequired]
    public class AccountTestEditModel
    {
        public long TestId { get; set; }
        public string TestName { get; set; }
        public bool IsRecommended { get; set; }
        public Gender Gender { get; set; }
    }
}
