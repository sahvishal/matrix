using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Users.ViewModels
{
    [NoValidationRequired]
    public class AccountCallCenterOrganizationEditModel
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string OrganizationName { get; set; }
    }
}
