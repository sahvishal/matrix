using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CallCenterAgentProfileModel
    {
        public string DialerUrl { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<CallCenterAgentProfileModel>))]
    public class CallCenterAgentProfileModelValidator : AbstractValidator<CallCenterAgentProfileModel>
    {
        public CallCenterAgentProfileModelValidator()
        { }
    }
}
