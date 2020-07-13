using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PodRoomEditModel>))]
    public class PodRoomEditModelValidator : AbstractValidator<PodRoomEditModel>
    {
        public PodRoomEditModelValidator()
        {
            RuleFor(x => x.Duration).NotNull().NotEmpty().WithMessage("(required)").GreaterThan(0).WithMessage("(should be grater than zero)");
            RuleFor(x => x.RoomTests).Must((x, y) => x.RoomTests.Any(rt => rt.IsSelected)).WithMessage("atleast one test needs to be selected");
        }
    }
}
