using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.Core.Users.ViewModels
{
    public class TechnicianModel
    {
        public bool IsTeamLead { get; set; }
        public bool CanCompletePreAudit { get; set; }
        public string Pin { get; set; }
        public long TechnicianId { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<TechnicianModel>))]
    public class TechnicianModelValidator : AbstractValidator<TechnicianModel>
    {
        public TechnicianModelValidator()
        { }
    }
}
